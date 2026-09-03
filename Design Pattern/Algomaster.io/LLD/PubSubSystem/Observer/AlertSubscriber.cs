using PubSubSystem.Entities;

namespace PubSubSystem.Observer
{
    internal class AlertSubscriber(string id) : ISubscriber
    {
        public string Id { get { return id; } }

        public void OnMessage(Message message)
        {
            Console.WriteLine($"!!! [ALERT - {id}] : '{message.Payload}' !!!");
        }
    }
}
