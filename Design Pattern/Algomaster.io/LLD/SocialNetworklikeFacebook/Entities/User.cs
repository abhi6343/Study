namespace SocialNetworklikeFacebook.Entities
{
    public class User(string name, string email)
    {
        readonly string id = Guid.NewGuid().ToString();
        readonly HashSet<User> friends = [];
        readonly List<Post> posts = [];

        public void AddFriend(User friend)
        {
            friends.Add(friend);
        }

        public void AddPost(Post post)
        {
            posts.Add(post);
        }

        public string Id => id;
        public string Name => name;
        public HashSet<User> Friends => friends;
        public List<Post> Posts => posts;
    }
}