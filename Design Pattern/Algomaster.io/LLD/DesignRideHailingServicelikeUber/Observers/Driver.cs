using RideHailingServicelikeUber.Entities;
using RideHailingServicelikeUber.Enums;

namespace RideHailingServicelikeUber.Observers
{
    internal class Driver(string name, string contact, Vehicle v, Location loc) : User(name, contact)
    {
        DriverStatus status = DriverStatus.OFFLINE;
        public Location CurrentLocation { get; set; } = loc;

        public Vehicle Vehicle => v;
        public DriverStatus Status 
        { 
            get 
            { 
                return status; 
            }
            set
            {
                status = value;
                Console.WriteLine($"Driver {Name} is now {value}");
            }
        }   

        public override void OnUpdate(Trip trip)
        {
            Console.WriteLine($"--- Notification for Driver {Name} ---");
            Console.WriteLine($"  Trip {trip.Id} status: {trip.Status}.");
            if (trip.Status == TripStatus.REQUESTED)
            {
                Console.WriteLine("  A new ride is available for you to accept.");
            }
            Console.WriteLine("--------------------------------\n");
        }
    }
}
