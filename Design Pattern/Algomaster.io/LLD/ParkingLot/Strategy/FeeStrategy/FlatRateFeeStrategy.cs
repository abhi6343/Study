using ParkingLot.Entities;

namespace ParkingLot.Strategy.FeeStrategy
{
    internal class FlatRateFeeStrategy : IFeeStrategy
    {
        private const double RATE_PER_HOUR = 10.0;
        public double CalculateFee(ParkingTicket parkingTicket)
        {
            return ((long)(parkingTicket.ParkingDuration / (1000.0 * 60.0 * 60.0) + 1)) * RATE_PER_HOUR;
        }
    }
}
