using SocialNetworklikeFacebook.Entities;

namespace SocialNetworklikeFacebook.Repositeries
{
    internal class UserRepository
    {
        static readonly UserRepository instance = new();
        readonly Dictionary<string, User> users = [];

        private UserRepository() { }

        public static UserRepository Instance => instance;

        public void Save(User user)
        {
            users[user.Id] = user;
        }

        public User FindById(string id)
        {
            if (users.TryGetValue(id, out var user))
            {
                return user;
            }
            return default;
        }
    }
}
