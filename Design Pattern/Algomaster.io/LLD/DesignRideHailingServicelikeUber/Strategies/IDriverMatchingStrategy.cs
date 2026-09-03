using RideHailingServicelikeUber.Entities;
using RideHailingServicelikeUber.Enums;
using RideHailingServicelikeUber.Observers;

namespace RideHailingServicelikeUber.Strategies
{
    internal interface IDriverMatchingStrategy
    {
        List<Driver> FindDrivers(List<Driver> allDrivers, Location pickupLocation, RideType rideType);
    }
}
