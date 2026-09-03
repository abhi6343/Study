using PubSubSystem.Entities;
using PubSubSystem.Observer;
using System.Collections.Concurrent;

namespace PubSubSystem.Singleton
{
    internal class PubSubService
    {
        private static PubSubService? instance;
        private static readonly Lock instanceLock = new();
        private readonly ConcurrentDictionary<string, Topic> topicRegistry = [];

        private PubSubService() { }

        public static PubSubService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (instanceLock)
                    {
                        instance ??= new();
                    }
                }
                return instance; 
            }
        }

        public void CreateTopic(string topicName)
        {
            topicRegistry.TryAdd(topicName, new(topicName));
            Console.WriteLine($"Topic {topicName} created");
        }

        public void Subscribe(string topicName, ISubscriber subscriber)
        {
            if (!topicRegistry.TryGetValue(topicName, out var topic))
            {
                throw new ArgumentException($"Topic not found: {topicName}");
            }
            topic.AddSubscriber(subscriber);
            Console.WriteLine($"Subscriber '{subscriber.Id}' subscribed to topic: {topicName}");
        }

        public void Unsubscribe(string topicName, ISubscriber subscriber)
        {
            if (topicRegistry.TryGetValue(topicName, out var topic))
            {
                topic.RemoveSubscriber(subscriber);
            }
            Console.WriteLine($"Subscriber '{subscriber.Id}' unsubscribed from topic: {topicName}");
        }

        public void Publish(string topicName, Message message)
        {
            Console.WriteLine($"Publishing message to topic: {topicName}");
            if (!topicRegistry.TryGetValue(topicName, out var topic))
            {
                throw new ArgumentException($"Topic not found: {topicName}");
            }
            topic.Broadcast(message);
        }

        public static void Shutdown()
        {
            Console.WriteLine("PubSubService shutting down...");
            Console.WriteLine("PubSubService shutdown complete.");
        }
    }
}
