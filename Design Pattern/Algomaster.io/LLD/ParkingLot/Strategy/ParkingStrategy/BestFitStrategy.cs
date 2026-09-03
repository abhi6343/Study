using ParkingLot.Entities.Parking;
using ParkingLot.Entities.Vechicle;

namespace ParkingLot.Strategy.ParkingStrategy
{
    internal class BestFitStrategy : IParkingStrategy
    {
        public ParkingSpot? FindSpot(IEnumerable<ParkingFloor> floors, Vehicle vehicle)
        {
            ParkingSpot? bestSpot = null;

            using (var enumerator = floors.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.FindAvailableSpot(vehicle) is var spotOnThisFloor && spotOnThisFloor != null)
                    {
                        if (bestSpot == null)
                        {
                            bestSpot = spotOnThisFloor;
                        }
                        else
                        {
                            if ((int)spotOnThisFloor.Size < (int)bestSpot.Size)
                            {
                                bestSpot = spotOnThisFloor;
                            }
                        }
                    }
                }
            }
            return bestSpot;
        }
    }
}
