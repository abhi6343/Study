using StackOverflow.Entities;

namespace StackOverflow.Strategy
{
    internal class UserSearchStrategy(User user) : ISearchStrategy
    {
        public IEnumerable<Question> Filter(IEnumerable<Question> questions)
        {
            return questions.Where(q => q.Author.Id.Equals(user.Id));
        }
    }
}
