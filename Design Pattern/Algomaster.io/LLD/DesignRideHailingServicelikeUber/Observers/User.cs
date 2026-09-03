using RideHailingServicelikeUber.Entities;

namespace RideHailingServicelikeUber.Observers
{
    internal abstract class User(string name, string contact) : ITripObserver
    {
        readonly string id = $"user_{++idCounter}";
        readonly List<Trip> tripHistory = [];

        static int idCounter = 0;

        public void AddTripToHistory(Trip trip)
        {
            tripHistory.Add(trip);
        }

        public List<Trip> TripHistory => tripHistory;
        public string Id => id;
        public string Name => name;
        public string Contact => contact;

        public abstract void OnUpdate(Trip trip);
    }
}
