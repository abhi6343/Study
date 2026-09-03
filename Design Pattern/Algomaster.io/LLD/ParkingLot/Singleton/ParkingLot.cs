using ParkingLot.Entities;
using ParkingLot.Entities.Parking;
using ParkingLot.Entities.Vechicle;
using ParkingLot.Strategy.FeeStrategy;
using ParkingLot.Strategy.ParkingStrategy;
using System.Collections.Concurrent;

namespace ParkingLot.Singleton
{
    internal class ParkingLot
    {
        static ParkingLot? instance;
        static readonly Lock instanceLock = new();
        static readonly Lock mainLock = new();

        readonly ICollection<ParkingFloor> floors;
        readonly ConcurrentDictionary<string, ParkingTicket> activeTickets;
        IFeeStrategy feeStrategy;
        IParkingStrategy parkingStrategy;
        public ParkingLot()
        {
            floors = [];
            activeTickets = [];
            feeStrategy = new FlatRateFeeStrategy();
            parkingStrategy = new NearestFirstStrategy();
        }
        public static ParkingLot GetInstance()
        {
            if (instance == null)
            {
                lock (instanceLock)
                {
                    instance ??= new ParkingLot();
                }
            }
            return instance;
        }
        public void AddFloor(ParkingFloor floor)
        {
            floors.Add(floor);
        }
        public void SetFeeStrategy(IFeeStrategy feeStrategy)
        {
            this.feeStrategy = feeStrategy;
        }
        public void SetParkingStrategy(IParkingStrategy parkingStrategy)
        {
            this.parkingStrategy = parkingStrategy;
        }
        public ParkingTicket? ParkVehicle(Vehicle vehicle)
        {
            lock (mainLock)
            {
                var spot = parkingStrategy.FindSpot(floors, vehicle);
                if (spot == null)
                {
                    Console.WriteLine($"No available spot for vehicle {vehicle.LicenseNumber}");
                    return null;
                }
                spot.ParkVehicle(vehicle);
                var ticket = new ParkingTicket(spot, vehicle);
                activeTickets.TryAdd(vehicle.LicenseNumber, ticket);
                Console.WriteLine($"Vehicle {vehicle.LicenseNumber} parked at spot {spot.SpotId}");
                return ticket;
            }
        }
        public double? UnparkVehicle(string licenseNumber)
        {
            lock (mainLock)
            {
                if (!activeTickets.TryRemove(licenseNumber, out var ticket))
                {
                    Console.WriteLine($"Ticket not found for vehicle {licenseNumber}");
                    return null;
                }
                ticket.ParkingSpot.UnparkVehicle();               
                Console.WriteLine($"Vehicle {licenseNumber} unparked from spot {ticket.ParkingSpot.SpotId}");
                return feeStrategy.CalculateFee(ticket);
            }
        }
    }
}
