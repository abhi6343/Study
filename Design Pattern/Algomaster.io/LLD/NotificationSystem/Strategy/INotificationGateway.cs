using NotificationSystem.Entities;

namespace NotificationSystem.Strategy
{
    internal interface INotificationGateway
    {
        void Send(Notification notification);
    }
}
