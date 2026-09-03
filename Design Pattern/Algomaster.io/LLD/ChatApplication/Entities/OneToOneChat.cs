using ChatApplication.Observers;

namespace ChatApplication.Entities
{
    internal class OneToOneChat : Chat
    {
        public OneToOneChat(User user1, User user2)
        {
            members.AddRange([user1, user2]);
        }

        public override string GetName(User perspectiveUser)
        {
            return members.Except([perspectiveUser]).First()?.Name ?? "Unknown Chat";
        }
    }
}
