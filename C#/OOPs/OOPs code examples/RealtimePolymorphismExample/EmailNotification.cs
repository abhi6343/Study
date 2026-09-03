namespace RealtimePolymorphismExample
{
    // Derived class: EmailNotification
    internal class EmailNotification : Notification
    {
        public string Subject { get; set; }
        public EmailNotification(string recipient, string subject, string message)
            : base(recipient, message)
        {
            Subject = subject;
        }
        public override void Send()
        {
            Console.WriteLine($"Sending Email to {Recipient} with subject: {Subject} and message: {Message}");
        }
    }
}
