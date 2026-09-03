namespace StackOverflow.Entities
{
    internal class Comment(string body, User author) : Content(Guid.NewGuid().ToString(), body, author)
    {
    }
}
