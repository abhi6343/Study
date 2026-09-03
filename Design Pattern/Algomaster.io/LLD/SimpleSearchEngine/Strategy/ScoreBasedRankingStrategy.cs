using SimpleSearchEngine.Entities;

namespace SimpleSearchEngine.Strategy
{
    internal class ScoreBasedRankingStrategy : IRankingStrategy
    {
        public void Rank(List<SearchResult> results)
        {
            results.Sort((a, b) => b.Score.CompareTo(a.Score));
        }
    }
}
