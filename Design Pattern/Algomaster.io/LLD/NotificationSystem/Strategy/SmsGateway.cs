using NotificationSystem.Entities;

namespace NotificationSystem.Strategy
{
    internal class SmsGateway : INotificationGateway
    {
        public void Send(Notification notification)
        {
            if (!notification.Recipient.HasPhoneNumber())
            {
                throw new ArgumentException("Phone number is required for SMS notification.");
            }

            string? phone = notification.Recipient.PhoneNumber;
            Console.WriteLine("--- Sending SMS ---");
            Console.WriteLine($"To: {phone}");
            Console.WriteLine($"Message: {notification.Message}");
            Console.WriteLine("-------------------\n");
        }
    }
}
