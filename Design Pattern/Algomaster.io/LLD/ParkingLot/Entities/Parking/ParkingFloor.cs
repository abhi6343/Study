using ParkingLot.Entities.Vechicle;
using ParkingLot.Enums;

namespace ParkingLot.Entities.Parking
{
    internal class ParkingFloor(int floorNumber)
    {
        readonly ICollection<KeyValuePair<string, ParkingSpot>> parkingSpots = [];
        readonly Lock mainLock = new();

        public void AddSpot(ParkingSpot spot)
        {
            parkingSpots.Add(new(spot.GetHashCode().ToString(), spot));
        }
        public void DisplayAvailability()
        {
            Console.WriteLine($"--- Floor {floorNumber} Availability ---");
            var availableCounts = new Dictionary<VehicleSize, int>
            {
                { VehicleSize.SMALL, 0 },
                { VehicleSize.MEDIUM, 0 },
                { VehicleSize.LARGE, 0 }
            };

            foreach (var spot in parkingSpots)
            {
                if (!spot.Value.IsOccupied)
                {
                    availableCounts[spot.Value.Size]++;
                }
            }

            foreach (VehicleSize size in Enum.GetValues<VehicleSize>())
            {
                Console.WriteLine($"  {size} spots: {availableCounts[size]}");
            }
        }
        public ParkingSpot? FindAvailableSpot(Vehicle vehicle)
        {
            lock (mainLock)
            {                
                return parkingSpots.Where(spot => !spot.Value.IsOccupied && spot.Value.Size <= vehicle.Size).OrderBy(spot => (int)spot.Value.Size).FirstOrDefault().Value;
            }
        }
    }
}
