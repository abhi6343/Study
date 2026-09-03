namespace StackOverflow.Entities
{
    internal abstract class Content(string id, string body, User? author)
    {
        protected readonly DateTime creationTime = DateTime.Now;
        public string Id { get { return id; } }
        public string Body { get { return body; } }
        public User? Author { get { return author; } }
    }
}
