using ChatApplication.Entities;

namespace ChatApplication.Observers
{
    internal class User(string name) : IMessageListener
    {
        readonly string id = Guid.NewGuid().ToString();

        public string Id => id;

        public string Name => name;

        public void OnMessageReceived(Message message, Chat chatContext)
        {
            Console.WriteLine($"[Notification for {Name} in chat '{chatContext.GetName(this)}'] {message.Sender.Name}: {message.Content}");
        }

        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;
            var user = (User)obj;
            return id.Equals(user.id);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override string ToString()
        {
            return $"User{{id='{id}', name='{name}'}}";
        }
    }
}
