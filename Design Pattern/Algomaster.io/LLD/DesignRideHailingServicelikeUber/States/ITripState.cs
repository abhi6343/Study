using RideHailingServicelikeUber.Entities;
using RideHailingServicelikeUber.Observers;

namespace RideHailingServicelikeUber.States
{
    internal interface ITripState
    {
        void Request(Trip trip);
        void Assign(Trip trip, Driver driver);
        void Start(Trip trip);
        void End(Trip trip);
    }
}
