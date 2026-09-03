using ParkingLot.Entities;

namespace ParkingLot.Strategy.FeeStrategy
{
    internal interface IFeeStrategy
    {
        double CalculateFee(ParkingTicket parkingTicket);
    }
}
