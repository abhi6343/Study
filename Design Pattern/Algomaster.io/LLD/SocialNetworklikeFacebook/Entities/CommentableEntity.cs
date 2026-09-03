namespace SocialNetworklikeFacebook.Entities
{
    public abstract class CommentableEntity(User author, string content)
    {
        protected readonly string id = Guid.NewGuid().ToString();
        protected readonly User author = author;
        protected readonly string content = content;
        protected readonly DateTime timestamp = DateTime.Now;
        readonly HashSet<User> likes = [];
        protected readonly List<Comment> comments = [];

        public void AddLike(User user)
        {
            likes.Add(user);
        }

        public void AddComment(Comment comment)
        {
            comments.Add(comment);
        }

        public string Id => id;
        public User Author => author;
        public string Content => content;
        public DateTime Timestamp => timestamp;
        public List<Comment> Comments => comments;
        public HashSet<User> Likes => likes;
    }
}
