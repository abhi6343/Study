using RideHailingServicelikeUber.Entities;
using RideHailingServicelikeUber.Enums;

namespace RideHailingServicelikeUber.Strategies
{
    internal interface IPricingStrategy
    {
        double CalculateFare(Location pickup, Location dropoff, RideType rideType);
    }
}
