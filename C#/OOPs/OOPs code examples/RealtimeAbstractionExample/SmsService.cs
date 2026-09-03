namespace RealtimeAbstractionExample
{
    internal class SmsService : IMessagingService
    {
        public void SendMessage(string recipient, string message)
        {
            Console.WriteLine($"Sending SMS to {recipient}: {message}");
            // Here, you'd have the actual logic to send an SMS.
        }
    }
}
