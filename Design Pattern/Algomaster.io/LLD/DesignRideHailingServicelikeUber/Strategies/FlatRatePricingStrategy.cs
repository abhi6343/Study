using RideHailingServicelikeUber.Entities;
using RideHailingServicelikeUber.Enums;

namespace RideHailingServicelikeUber.Strategies
{
    internal class FlatRatePricingStrategy : IPricingStrategy
    {
        const double BASE_FARE = 5.0;
        const double FLAT_RATE = 1.5;

        public double CalculateFare(Location pickup, Location dropoff, RideType rideType)
        {
            double distance = pickup.DistanceTo(dropoff);
            return BASE_FARE + distance * FLAT_RATE;
        }
    }
}
