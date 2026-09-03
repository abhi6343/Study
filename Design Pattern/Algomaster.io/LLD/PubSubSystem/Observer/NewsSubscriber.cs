using PubSubSystem.Entities;

namespace PubSubSystem.Observer
{
    internal class NewsSubscriber(string id) : ISubscriber
    {
        public string Id { get { return id; }  }

        public void OnMessage(Message message)
        {
            Console.WriteLine($"[Subscriber {id}] received message '{message.Payload}'");
        }
    }
}
