using SimpleSearchEngine.Entities;

namespace SimpleSearchEngine.Strategy
{
    internal class TermFrequencyScoringStrategy : IScoringStrategy
    {
        public double CalculateScore(string term, Posting posting, Document document)
        {
            return posting.Frequency;
        }
    }
}
