using RideHailingServicelikeUber.Entities;

namespace RideHailingServicelikeUber.Observers
{
    internal interface ITripObserver
    {
        void OnUpdate(Trip trip);
    }
}
