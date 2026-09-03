namespace StackOverflow.Entities
{
    internal class Answer(string body, User author) : Post(Guid.NewGuid().ToString(), body, author)
    {
        public bool IsAcceptedAnswer { get; set; }
    }
}
