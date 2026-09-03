using PubSubSystem.Entities;

namespace PubSubSystem.Observer
{
    internal class Topic(string name)
    {
        private readonly HashSet<ISubscriber> subscribers = [];
        private readonly Lock subscribersLock = new();

        public string Name { get { return name; } }

        public void AddSubscriber(ISubscriber subscriber)
        {
            lock (subscribersLock)
            {
                subscribers.Add(subscriber);
            }
        }

        public void RemoveSubscriber(ISubscriber subscriber)
        {
            lock (subscribersLock)
            {
                subscribers.Remove(subscriber);
            }
        }

        public void Broadcast(Message message)
        {
            IEnumerable<ISubscriber> currentSubscribers;
            lock (subscribersLock)
            {
                currentSubscribers = [.. subscribers];
            }

            ICollection<Task> deliveryTasks = [];

            foreach (var subscriber in currentSubscribers)
            {
                deliveryTasks.Add(Task.Run(() =>
                {
                    try
                    {
                        subscriber.OnMessage(message);
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine($"Error delivering message to subscriber {subscriber.Id}: {e.Message}");
                    }
                }));
            }

            Task.WaitAll([.. deliveryTasks]);
        }
    }
}
