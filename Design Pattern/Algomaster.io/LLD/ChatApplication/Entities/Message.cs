using ChatApplication.Observers;

namespace ChatApplication.Entities
{
    internal class Message(User sender, string content)
    {
        public string Id { get; } = Guid.NewGuid().ToString();

        public User Sender => sender;

        public string Content => content;

        public DateTime Timestamp { get; } = DateTime.Now;

        public override string ToString() => $"[{Timestamp}] {sender.Name}: {content}";
    }
}
