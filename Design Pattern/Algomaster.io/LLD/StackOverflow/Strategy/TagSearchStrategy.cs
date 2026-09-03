using StackOverflow.Entities;

namespace StackOverflow.Strategy
{
    internal class TagSearchStrategy(Tag tag) : ISearchStrategy
    {
        public IEnumerable<Question> Filter(IEnumerable<Question> questions)
        {
            return questions.Where(q => q.Tags.Any(t => t.Name.Equals(tag.Name, StringComparison.OrdinalIgnoreCase)));
        }
    }
}
