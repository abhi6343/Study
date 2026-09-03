namespace SearchAutocompleteSystem.Strategy
{
    internal class AlphabeticalRanking : IRankingStrategy
    {
        public IEnumerable<Suggestion> Rank(IEnumerable<Suggestion> suggestions)
        {
            return suggestions.OrderBy(s => s.Word);
        }
    }
}
