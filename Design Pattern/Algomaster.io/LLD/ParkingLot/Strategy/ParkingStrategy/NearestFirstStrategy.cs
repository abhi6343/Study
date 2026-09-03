using ParkingLot.Entities.Parking;
using ParkingLot.Entities.Vechicle;

namespace ParkingLot.Strategy.ParkingStrategy
{
    internal class NearestFirstStrategy : IParkingStrategy
    {
        public ParkingSpot? FindSpot(IEnumerable<ParkingFloor> floors, Vehicle vehicle)
        {
            using var enumerator = floors.GetEnumerator();
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
