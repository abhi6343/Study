namespace RealtimePolymorphismExample
{
    // Derived class: PushNotification
    internal class PushNotification : Notification
    {
        public PushNotification(string device, string message)
            : base(device, message) { }
        public override void Send()
        {
            Console.WriteLine($"Sending Push Notification to device {Recipient} with message: {Message}");
        }
    }
}
