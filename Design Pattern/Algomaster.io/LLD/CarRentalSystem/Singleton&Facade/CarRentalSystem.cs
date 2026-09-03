using CarRentalSystem.DataClasses;
using CarRentalSystem.Enums;
using CarRentalSystem.Exceptions;
using CarRentalSystem.Observers;
using CarRentalSystem.Strategies;
using System.Collections.Concurrent;

namespace CarRentalSystem.SingletonAndFacade
{
    internal class CarRentalSystem
    {
        static volatile CarRentalSystem _instance;
        static readonly Lock instanceLock = new();

        readonly ConcurrentDictionary<string, Location> _locations = [];
        readonly ConcurrentDictionary<string, Vehicle> _vehicles = [];
        readonly ConcurrentDictionary<string, Reservation> _reservations = [];
        // Maps location ID to list of vehicles at that location
        readonly ConcurrentDictionary<string, List<Vehicle>> _locationVehicles = [];
        readonly List<IRentalObserver> _observers = [];
        IPricingStrategy _pricingStrategy;
        int _reservationCounter;
        readonly Lock opLock = new();
        const double LateFeePerDay = 50.0;

        private CarRentalSystem()
        {
            _pricingStrategy = new StandardPricingStrategy();
            _reservationCounter = 0;
        }

        public static CarRentalSystem Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (instanceLock)
                    {
                        _instance ??= new();
                    }
                }
                return _instance;
            }
        }

        public void AddLocation(Location location)
        {
            lock (opLock)
            {
                _locations[location.Id] = location;
                _locationVehicles.TryAdd(location.Id, []);
            }
        }

        public void AddVehicle(Vehicle vehicle)
        {
            lock (opLock)
            {
                _vehicles[vehicle.Id] = vehicle;
                _locationVehicles.AddOrUpdate(vehicle.LocationId, [vehicle], (key, list) => { list.Add(vehicle); return list; });
            }
        }

        public Reservation MakeReservation(Customer customer, VehicleType vehicleType, string pickupLocationId, string returnLocationId, DateTime pickupDate,
                DateTime returnDate, List<Equipment> equipments)
        {
            lock (opLock)
            {
                // Check if any vehicles of this type are available at the pickup location
                if (!_locationVehicles.TryGetValue(pickupLocationId, out var vehiclesAtLocation))
                {
                    vehiclesAtLocation = [];
                }
                var hasAvailable = vehiclesAtLocation.Any(v => v.VehicleType == vehicleType && v.Status == VehicleStatus.AVAILABLE);

                if (!hasAvailable)
                {
                    throw new CarRentalException("No " + vehicleType + " vehicles available at location " + pickupLocationId);
                }

                // Create the reservation
                var reservationId = "RES-" + Interlocked.Increment(ref _reservationCounter);
                var reservation = new Reservation(reservationId, customer, vehicleType, pickupLocationId, returnLocationId, pickupDate, returnDate, equipments);

                _reservations[reservationId] = reservation;

                // Notify observers
                NotifyReservationCreated(reservation);

                return reservation;
            }
        }

        public Vehicle PickupVehicle(string reservationId)
        {
            lock (opLock)
            {
                if (!_reservations.TryGetValue(reservationId, out var reservation))
                {
                    throw new CarRentalException("Reservation not found: " + reservationId);
                }

                if (reservation.Status != ReservationStatus.CONFIRMED)
                {
                    throw new CarRentalException("Reservation is not in CONFIRMED status: " + reservation.Status);
                }

                // Find an available vehicle of the right type at the pickup location
                if (!_locationVehicles.TryGetValue(reservation.PickupLocationId, out var vehiclesAtLocation))
                {
                    vehiclesAtLocation = [];
                }
                var vehicle = vehiclesAtLocation.FirstOrDefault(v => v.VehicleType == reservation.VehicleType && v.Status == VehicleStatus.AVAILABLE)
                    ?? throw new CarRentalException("No available " + reservation.VehicleType + " at pickup location");

                // Assign vehicle and update statuses
                vehicle.Status = VehicleStatus.RENTED;
                reservation.AssignVehicle(vehicle);
                reservation.Activate();

                // Notify observers
                NotifyVehiclePickedUp(reservation);

                return vehicle;
            }
        }

        public Bill ReturnVehicle(string reservationId, string returnLocationId, DateTime actualReturnDate)
        {
            lock (opLock)
            {
                if (!_reservations.TryGetValue(reservationId, out var reservation))
                {
                    throw new CarRentalException("Reservation not found: " + reservationId);
                }

                if (reservation.Status != ReservationStatus.ACTIVE)
                {
                    throw new CarRentalException("Reservation is not ACTIVE: " + reservation.Status);
                }

                var vehicle = reservation.AssignedVehicle;

                // Calculate rental days
                var rentalDays = (reservation.ReturnDate - reservation.PickupDate).Days;
                if (rentalDays <= 0) rentalDays = 1;

                // Calculate base cost using pricing strategy
                var baseCost = _pricingStrategy.CalculateCost(vehicle.DailyRate, rentalDays);

                // Calculate equipment cost
                var equipmentCost = reservation.Equipment.Sum(e => e.DailyRate * rentalDays);

                // Calculate late fee
                var lateFee = 0.0;
                if (actualReturnDate > reservation.ReturnDate)
                {
                    var lateDays = (actualReturnDate - reservation.ReturnDate).Days;
                    lateFee = lateDays * LateFeePerDay;
                }

                // Create bill
                var bill = new Bill(reservation, baseCost, equipmentCost, lateFee);

                // Update vehicle: mark as available at the return location
                vehicle.Status = VehicleStatus.AVAILABLE;
                // Move vehicle to return location if different
                if (vehicle.LocationId != returnLocationId)
                {
                    if (_locationVehicles.TryGetValue(vehicle.LocationId, out var oldList))
                    {
                        oldList.Remove(vehicle);
                    }
                    vehicle.LocationId = returnLocationId;
                    _locationVehicles.AddOrUpdate(returnLocationId, [vehicle], (key, list) => { list.Add(vehicle); return list; });
                }

                // Complete reservation
                reservation.Complete(bill.TotalCost);

                // Notify observers
                NotifyVehicleReturned(reservation, bill);

                return bill;
            }
        }

        public void CancelReservation(string reservationId)
        {
            lock (opLock)
            {
                if (!_reservations.TryGetValue(reservationId, out var reservation))
                {
                    throw new CarRentalException("Reservation not found: " + reservationId);
                }

                // Cancel the reservation (enforces state machine)
                reservation.Cancel();
            }
        }

        public void SetPricingStrategy(IPricingStrategy strategy)
        {
            lock (opLock)
            {
                _pricingStrategy = strategy;
            }
        }

        public void AddObserver(IRentalObserver observer)
        {
            lock (opLock)
            {
                _observers.Add(observer);
            }
        }

        public void RemoveObserver(IRentalObserver observer)
        {
            lock (opLock)
            {
                _observers.Remove(observer);
            }
        }

        private void NotifyReservationCreated(Reservation reservation)
        {
            foreach (var observer in _observers)
            {
                try
                {
                    observer.OnReservationCreated(reservation);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Observer notification failed: " + e.Message);
                }
            }
        }

        private void NotifyVehiclePickedUp(Reservation reservation)
        {
            foreach (var observer in _observers)
            {
                try
                {
                    observer.OnVehiclePickedUp(reservation);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Observer notification failed: " + e.Message);
                }
            }
        }

        private void NotifyVehicleReturned(Reservation reservation, Bill bill)
        {
            foreach (var observer in _observers)
            {
                try
                {
                    observer.OnVehicleReturned(reservation, bill);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Observer notification failed: " + e.Message);
                }
            }
        }
        public void TransferVehicle(string vehicleId, string fromLocationId, string toLocationId)
        {
            lock (opLock)
            {
                if (!_vehicles.TryGetValue(vehicleId, out var vehicle))
                {
                    throw new CarRentalException("Vehicle not found: " + vehicleId);
                }
                if (vehicle.Status != VehicleStatus.AVAILABLE)
                {
                    throw new CarRentalException("Can only transfer AVAILABLE vehicles. Current: " + vehicle.Status);
                }

                // Move vehicle between location lists
                if (_locationVehicles.TryGetValue(fromLocationId, out var fromList))
                {
                    fromList.Remove(vehicle);
                }          
                vehicle.LocationId = toLocationId;
                _locationVehicles.AddOrUpdate(toLocationId, [vehicle], (key, list) => { list.Add(vehicle); return list; });
            }
        }
    }
}
