using NotificationSystem.Entities;

namespace NotificationSystem.Strategy
{
    internal class EmailGateway : INotificationGateway
    {
        public void Send(Notification notification)
        {
            if (!notification.Recipient.HasEmail())
            {
                throw new ArgumentException("Email address is required for EMAIL notification.");
            }

            string? email = notification.Recipient.Email;
            Console.WriteLine("--- Sending EMAIL ---");
            Console.WriteLine($"To: {email}");
            Console.WriteLine($"Subject: {notification.Subject}");
            Console.WriteLine($"Body: {notification.Message}");
            Console.WriteLine("---------------------\n");
        }
    }
}
