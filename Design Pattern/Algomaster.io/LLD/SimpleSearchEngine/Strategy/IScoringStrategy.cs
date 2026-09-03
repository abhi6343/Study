using SimpleSearchEngine.Entities;

namespace SimpleSearchEngine.Strategy
{
    internal interface IScoringStrategy
    {
        double CalculateScore(string term, Posting posting, Document document);
    }
}
