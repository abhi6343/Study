using SocialNetworklikeFacebook.Entities;

namespace SocialNetworklikeFacebook.Repositeries
{
    internal class PostRepository
    {
        static readonly PostRepository instance = new();
        readonly Dictionary<string, Post> posts = [];

        private PostRepository() { }

        public static PostRepository Instance => instance;

        public void Save(Post post)
        {
            posts[post.Id] = post;
        }

        public Post FindById(string id)
        {
            if (posts.TryGetValue(id, out var post))
            {
                return post;
            }
            return default;
        }
    }
}
