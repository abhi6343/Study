using ChatApplication.Observers;

namespace ChatApplication.Entities
{
    internal class GroupChat : Chat
    {
        readonly string groupName;

        public GroupChat(string groupName, ICollection<User> initialMembers)
        {
            this.groupName = groupName;
            members.AddRange(initialMembers);
        }

        public void AddMember(User user)
        {
            if (!members.Contains(user))
            {
                members.Add(user);
            }
        }

        public void RemoveMember(User user)
        {
            members.Remove(user);
        }

        public override string GetName(User perspectiveUser)
        {
            return groupName;
        }
    }
}
