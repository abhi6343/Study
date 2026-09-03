using StackOverflow.Entities;

namespace StackOverflow.Strategy
{
    internal interface ISearchStrategy
    {
        IEnumerable<Question> Filter(IEnumerable<Question> questions);
    }
}
