using SocialNetworklikeFacebook.Entities;
using SocialNetworklikeFacebook.Repositeries;

namespace SocialNetworklikeFacebook.Services
{
    internal class UserService
    {
        private readonly UserRepository userRepository = UserRepository.Instance;

        public User CreateUser(string name, string email)
        {
            var user = new User(name, email);
            userRepository.Save(user);
            return user;
        }

        public void AddFriend(string userId1, string userId2)
        {
            var user1 = userRepository.FindById(userId1);
            var user2 = userRepository.FindById(userId2);

            user1.AddFriend(user2);
            user2.AddFriend(user1);
        }

        public User GetUserById(string userId)
        {
            return userRepository.FindById(userId);
        }
    }
}
