using StackOverflow.Entities;

namespace StackOverflow.Strategy
{
    internal class KeywordSearchStrategy(string keyword) : ISearchStrategy
    {
        public IEnumerable<Question> Filter(IEnumerable<Question> questions)
        {
            return questions.Where(q => q.Title.Contains(keyword, StringComparison.CurrentCultureIgnoreCase) || q.Body.Contains(keyword, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
