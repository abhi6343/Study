using SimpleSearchEngine.Entities;

namespace SimpleSearchEngine.Strategy
{
    internal interface IRankingStrategy
    {
        void Rank(List<SearchResult> results);
    }
}
