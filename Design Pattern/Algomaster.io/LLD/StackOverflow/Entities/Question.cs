namespace StackOverflow.Entities
{
    internal class Question(string title, string body, User? author, HashSet<Tag> tags) : Post(Guid.NewGuid().ToString(), body, author)
    {
        private readonly ICollection<Answer> answers = [];
        private Answer? acceptedAnswer;

        public void AddAnswer(Answer answer)
        {
            answers.Add(answer);
        }

        public void AcceptAnswer(Answer answer)
        {
            lock (this)
            {
                if (!author.Id.Equals(answer.Author.Id) && acceptedAnswer == null)
                {
                    acceptedAnswer = answer;
                    answer.IsAcceptedAnswer = true;
                    NotifyObservers(new(EventType.ACCEPT_ANSWER, answer.Author, answer));
                }
            }
        }

        public string Title { get { return title; } }
        public HashSet<Tag> Tags { get { return tags; } }
        public ICollection<Answer> Answers { get { return answers; } }
    }
}
