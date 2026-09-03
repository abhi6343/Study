using ParkingLot.Entities.Parking;
using ParkingLot.Entities.Vechicle;

namespace ParkingLot.Strategy.ParkingStrategy
{
    internal interface IParkingStrategy
    {
        ParkingSpot? FindSpot(IEnumerable<ParkingFloor> floors, Vehicle vehicle);
    }
}
