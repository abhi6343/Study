using ParkingLot.Entities;
using ParkingLot.Enums;

namespace ParkingLot.Strategy.FeeStrategy
{
    internal class VehicleBasedFeeStrategy : IFeeStrategy
    {
        readonly ICollection<KeyValuePair<VehicleSize, double>> HOURLY_RATES = [
        
            new(VehicleSize.SMALL, 10.0),
            new(VehicleSize.MEDIUM, 20.0 ),
            new(VehicleSize.LARGE, 30.0)
        ];
        public double CalculateFee(ParkingTicket parkingTicket)
        {
            return ((long)(parkingTicket.ParkingDuration / (1000.0 * 60.0 * 60.0) + 1)) * HOURLY_RATES.First(rate => rate.Key == parkingTicket.Vehicle.Size).Value;
        }
    }
}
