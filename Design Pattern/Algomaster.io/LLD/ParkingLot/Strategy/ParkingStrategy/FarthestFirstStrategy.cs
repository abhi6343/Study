using ParkingLot.Entities.Parking;
using ParkingLot.Entities.Vechicle;

namespace ParkingLot.Strategy.ParkingStrategy
{
    internal class FarthestFirstStrategy : IParkingStrategy
    {
        public ParkingSpot? FindSpot(IEnumerable<ParkingFloor> floors, Vehicle vehicle)
        {
            using var enumerator = floors.Reverse().GetEnumerator();
            while (enumerator.MoveNext())
            {                
                if (enumerator.Current.FindAvailableSpot(vehicle) is var spot && spot != null)
                {
                    return spot;
                }
            }
            return null;
        }
    }
}
