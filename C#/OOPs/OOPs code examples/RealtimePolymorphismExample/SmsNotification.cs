namespace RealtimePolymorphismExample
{
    // Derived class: SmsNotification
    internal class SmsNotification : Notification
    {
        public SmsNotification(string phoneNumber, string message)
            : base(phoneNumber, message) { }
        public override void Send()
        {
            Console.WriteLine($"Sending SMS to {Recipient} with message: {Message}");
        }
    }
}
