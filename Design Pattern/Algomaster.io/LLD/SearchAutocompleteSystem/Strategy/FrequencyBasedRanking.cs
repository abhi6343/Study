namespace SearchAutocompleteSystem.Strategy
{
    internal class FrequencyBasedRanking : IRankingStrategy
    {
        public IEnumerable<Suggestion> Rank(IEnumerable<Suggestion> suggestions)
        {
            return suggestions.OrderByDescending(s => s.Weight);
        }
    }
}
