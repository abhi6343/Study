using ChatApplication.Observers;

namespace ChatApplication.Entities
{
    internal abstract class Chat
    {
        protected readonly string id = Guid.NewGuid().ToString();
        protected readonly List<User> members = [];
        protected readonly ICollection<Message> messages = [];

        public string Id => id;

        public IEnumerable<User> Members => members;

        public IEnumerable<Message> Messages => messages;

        public void AddMessage(Message message)
        {
            messages.Add(message);
        }

        public abstract string GetName(User perspectiveUser);
    }
}
