using SocialNetworklikeFacebook.Entities;
using SocialNetworklikeFacebook.Observers;
using SocialNetworklikeFacebook.Services;

namespace SocialNetworklikeFacebook.Facades
{
    internal class SocialNetworkFacade
    {
        readonly UserService userService;
        readonly PostService postService;
        readonly NewsFeedService newsFeedService;

        public SocialNetworkFacade()
        {
            this.userService = new();
            this.postService = new();
            this.newsFeedService = new();
            // Wire up the observer
            postService.AddObserver(new UserNotifier());
        }

        public User CreateUser(string name, string email)
        {
            return userService.CreateUser(name, email);
        }

        public void AddFriend(string userId1, string userId2)
        {
            userService.AddFriend(userId1, userId2);
        }

        public Post CreatePost(string authorId, string content)
        {
            var author = userService.GetUserById(authorId);
            return postService.CreatePost(author, content);
        }

        public void AddComment(string userId, string postId, string content)
        {
            var user = userService.GetUserById(userId);
            postService.AddComment(user, postId, content);
        }

        public void LikePost(string userId, string postId)
        {
            var user = userService.GetUserById(userId);
            postService.LikePost(user, postId);
        }

        public List<Post> GetNewsFeed(string userId)
        {
            var user = userService.GetUserById(userId);
            return newsFeedService.GetNewsFeed(user);
        }
    }
}
