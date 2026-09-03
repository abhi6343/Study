namespace SocialNetworklikeFacebook.Entities
{
    public class Comment(User author, string content) : CommentableEntity(author, content)
    {
        public List<Comment> GetReplies()
        {
            return Comments;
        }
    }
}
