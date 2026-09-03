namespace SearchAutocompleteSystem.Strategy
{
    internal interface IRankingStrategy
    {
        IEnumerable<Suggestion> Rank(IEnumerable<Suggestion> suggestions);
    }
}
