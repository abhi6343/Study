namespace RealtimeAbstractionExample
{
    internal class PushNotificationService : IMessagingService
    {
        public void SendMessage(string recipient, string message)
        {
            Console.WriteLine($"Sending Push Notification to {recipient}: {message}");
            // Here, you'd have the actual logic to send a push notification.
        }
    }
}
