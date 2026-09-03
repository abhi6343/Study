using RideHailingServicelikeUber.Entities;
using RideHailingServicelikeUber.Enums;

namespace RideHailingServicelikeUber.Strategies
{
    internal class VehicleBasedPricingStrategy : IPricingStrategy
    {
        const double BASE_FARE = 2.50;
        readonly Dictionary<RideType, double> ratePerKm = new()
        {
            { RideType.SEDAN, 1.50 },
            { RideType.SUV, 2.00 },
            { RideType.AUTO, 1.00 }
        };

        public double CalculateFare(Location pickup, Location dropoff, RideType rideType)
        {
            return BASE_FARE + ratePerKm[rideType] * pickup.DistanceTo(dropoff);
        }
    }
}
