using SocialNetworklikeFacebook.Entities;
using System.Xml.Linq;

namespace SocialNetworklikeFacebook.Observers
{
    internal class UserNotifier : IPostObserver
    {
        public void OnPostCreated(Post post)
        {
            var author = post.Author;
            foreach (var friend in author.Friends)
            {
                Console.WriteLine($"Notification for {friend.Name}: {author.Name} created a new post: {post.Content}");
            }
        }

        public void OnLike(Post post, User user)
        {
            var author = post.Author;
            Console.WriteLine($"Notification for {author.Name}: {user.Name} liked your post");
        }

        public void OnComment(Post post, Comment comment)
        {
            var author = post.Author;
            Console.WriteLine($"Notification for {author.Name}: {comment.Author.Name} commented on your post");
        }
    }
}
