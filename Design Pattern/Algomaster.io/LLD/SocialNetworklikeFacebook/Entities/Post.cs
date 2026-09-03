namespace SocialNetworklikeFacebook.Entities
{
    public class Post(User author, string content) : CommentableEntity(author, content)
    {
    }
}
