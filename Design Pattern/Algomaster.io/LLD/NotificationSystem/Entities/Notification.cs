namespace NotificationSystem.Entities
{
    internal class Notification(Notification.Builder builder)
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public Recipient Recipient { get { return builder.recipient; } }
        public NotificationType Type { get { return builder.type; } }
        public string? Message { get { return builder.message; } }
        public string? Subject { get { return builder.subject; } }

        public class Builder(Recipient recipient, NotificationType type)
        {
            internal readonly Recipient recipient = recipient;
            internal readonly NotificationType type = type;
            internal string? message;
            internal string? subject;

            public Builder Message(string message)
            {
                this.message = message;
                return this;
            }

            public Builder Subject(string subject)
            {
                this.subject = subject;
                return this;
            }

            public Notification Build()
            {
                return new(this);
            }
        }
    }
}
