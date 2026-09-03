using PubSubSystem.Entities;

namespace PubSubSystem.Observer
{
    internal interface ISubscriber
    {
        string Id { get; }
        void OnMessage(Message message);
    }
}
