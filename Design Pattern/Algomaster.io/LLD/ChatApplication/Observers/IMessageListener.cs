using ChatApplication.Entities;

namespace ChatApplication.Observers
{
    internal interface IMessageListener
    {
        void OnMessageReceived(Message message, Chat chatContext);
    }
}
