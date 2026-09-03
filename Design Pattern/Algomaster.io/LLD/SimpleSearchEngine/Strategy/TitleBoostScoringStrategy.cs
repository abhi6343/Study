using SimpleSearchEngine.Entities;

namespace SimpleSearchEngine.Strategy
{
    internal class TitleBoostScoringStrategy : IScoringStrategy
    {
        private static readonly double TITLE_BOOST_FACTOR = 1.5;

        public double CalculateScore(string term, Posting posting, Document document)
        {
            double score = posting.Frequency;
            if (document.Title.Contains(term, StringComparison.CurrentCultureIgnoreCase))
            {
                score *= TITLE_BOOST_FACTOR;
            }
            return score;
        }
    }
}
