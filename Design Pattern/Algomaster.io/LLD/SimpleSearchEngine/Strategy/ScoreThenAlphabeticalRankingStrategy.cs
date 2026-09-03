using SimpleSearchEngine.Entities;

namespace SimpleSearchEngine.Strategy
{
    internal class ScoreThenAlphabeticalRankingStrategy : IRankingStrategy
    {
        public void Rank(List<SearchResult> results)
        {
            results.Sort((a, b) =>
            {
                int scoreComparison = b.Score.CompareTo(a.Score);
                if (scoreComparison != 0)
                {
                    return scoreComparison;
                }
                return a.Document.Title.CompareTo(b.Document.Title);
            });
        }
    }
}
