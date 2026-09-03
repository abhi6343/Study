using NotificationSystem.Entities;

namespace NotificationSystem.Strategy
{
    internal class PushGateway : INotificationGateway
    {
        public void Send(Notification notification)
        {
            if (!notification.Recipient.HasPushToken())
            {
                throw new ArgumentException("Push token is required for PUSH notification.");
            }

            string? token = notification.Recipient.PushToken;
            Console.WriteLine("--- Sending PUSH Notification ---");
            Console.WriteLine($"To Device Token: {token}");
            Console.WriteLine($"Title: {notification.Subject}");
            Console.WriteLine($"Body: {notification.Message}");
            Console.WriteLine("---------------------------------\n");
        }
    }
}
