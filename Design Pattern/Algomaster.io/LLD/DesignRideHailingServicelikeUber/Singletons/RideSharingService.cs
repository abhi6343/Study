using RideHailingServicelikeUber.Entities;
using RideHailingServicelikeUber.Enums;
using RideHailingServicelikeUber.Observers;
using RideHailingServicelikeUber.Strategies;

namespace RideHailingServicelikeUber.Singletons
{
    internal class RideSharingService
    {
        private static volatile RideSharingService instance;
        private static readonly Lock lockObject = new();

        private readonly Dictionary<string, Rider> riders = [];
        private readonly Dictionary<string, Driver> drivers = [];
        private readonly Dictionary<string, Trip> trips = [];
        private IPricingStrategy pricingStrategy;
        private IDriverMatchingStrategy driverMatchingStrategy;

        private RideSharingService() { }

        public static RideSharingService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        instance ??= new RideSharingService();
                    }
                }
                return instance;
            }
        }

        public void SetPricingStrategy(IPricingStrategy strategy)
        {
            pricingStrategy = strategy;
        }

        public void SetDriverMatchingStrategy(IDriverMatchingStrategy strategy)
        {
            driverMatchingStrategy = strategy;
        }

        public Rider RegisterRider(string name, string contact)
        {
            var rider = new Rider(name, contact);
            riders[rider.Id] = rider;
            return rider;
        }

        public Driver RegisterDriver(string name, string contact, Vehicle vehicle, Location initialLocation)
        {
            var driver = new Driver(name, contact, vehicle, initialLocation);
            drivers[driver.Id] = driver;
            return driver;
        }

        public Trip RequestRide(string riderId, Location pickup, Location dropoff, RideType rideType)
        {
            if (!riders.TryGetValue(riderId, out var rider))
            {
                throw new ArgumentException("Rider not found");
            }

            Console.WriteLine($"\n--- New Ride Request from {rider.Name} ---");

            // 1. Find available drivers
            var availableDrivers = driverMatchingStrategy.FindDrivers([.. drivers.Values], pickup, rideType);

            if (availableDrivers.Count == 0)
            {
                Console.WriteLine("No drivers available for your request. Please try again later.");
                return null;
            }

            Console.WriteLine($"Found {availableDrivers.Count} available driver(s).");

            // 2. Calculate fare
            double fare = pricingStrategy.CalculateFare(pickup, dropoff, rideType);
            Console.WriteLine($"Estimated fare: ${fare:F2}");

            // 3. Create a trip using the Builder
            var trip = new Trip.TripBuilder()
                .WithRider(rider)
                .WithPickupLocation(pickup)
                .WithDropoffLocation(dropoff)
                .WithFare(fare)
                .Build();

            trips[trip.Id] = trip;

            // 4. Notify nearby drivers
            Console.WriteLine("Notifying nearby drivers of the new ride request...");
            foreach (var driver in availableDrivers)
            {
                Console.WriteLine($" > Notifying {driver.Name} at {driver.CurrentLocation}");
                driver.OnUpdate(trip);
            }

            return trip;
        }

        public void AcceptRide(string driverId, string tripId)
        {
            if (!drivers.TryGetValue(driverId, out var driver) || !trips.TryGetValue(tripId, out var trip))
            {
                throw new ArgumentException("Driver or Trip not found");
            }

            Console.WriteLine($"\n--- Driver {driver.Name} accepted the ride ---");

            driver.Status = DriverStatus.IN_TRIP;
            trip.AssignDriver(driver);
        }

        public void StartTrip(string tripId)
        {
            if (!trips.TryGetValue(tripId, out var trip))
            {
                throw new ArgumentException("Trip not found");
            }
            Console.WriteLine($"\n--- Trip {trip.Id} is starting ---");
            trip.StartTrip();
        }

        public void EndTrip(string tripId)
        {
            if (!trips.TryGetValue(tripId, out var trip))
            {
                throw new ArgumentException("Trip not found");
            }
            Console.WriteLine($"\n--- Trip {trip.Id} is ending ---");
            trip.EndTrip();

            // Update statuses and history
            var driver = trip.Driver;
            driver.Status = DriverStatus.ONLINE;
            driver.CurrentLocation = trip.DropoffLocation;

            var rider = trip.Rider;
            driver.AddTripToHistory(trip);
            rider.AddTripToHistory(trip);

            Console.WriteLine($"Driver {driver.Name} is now back online at {driver.CurrentLocation}");
        }
    }
}
