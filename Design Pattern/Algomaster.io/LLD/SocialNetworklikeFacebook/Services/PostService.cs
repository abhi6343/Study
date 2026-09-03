using SocialNetworklikeFacebook.Entities;
using SocialNetworklikeFacebook.Observers;
using SocialNetworklikeFacebook.Repositeries;
using System.Xml.Linq;

namespace SocialNetworklikeFacebook.Services
{
    internal class PostService
    {
        private readonly PostRepository postRepository = PostRepository.Instance;
        private readonly List<IPostObserver> observers = [];

        public void AddObserver(IPostObserver observer)
        {
            observers.Add(observer);
        }

        public Post CreatePost(User author, string content)
        {
            var post = new Post(author, content);
            postRepository.Save(post);
            author.AddPost(post);
            foreach (var observer in observers)
            {
                observer.OnPostCreated(post);
            }
            return post;
        }

        public void LikePost(User user, string postId)
        {
            var post = postRepository.FindById(postId);
            post.AddLike(user);
            foreach (var observer in observers)
            {
                observer.OnLike(post, user);
            }
        }

        public void AddComment(User author, string commentableId, string content)
        {
            var comment = new Comment(author, content);
            var post = postRepository.FindById(commentableId);
            post.AddComment(comment);
            foreach (var observer in observers)
            {
                observer.OnComment(post, comment);
            }
        }
    }
}
