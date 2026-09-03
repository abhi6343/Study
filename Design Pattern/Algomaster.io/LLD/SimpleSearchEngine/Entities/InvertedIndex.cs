namespace SimpleSearchEngine.Entities
{
    internal class InvertedIndex
    {
        private readonly Dictionary<string, List<Posting>> index = [];

        public void Add(string term, string documentId, int frequency)
        {
            if (!index.TryGetValue(term, out var value))
            {
                index[term] = [];
            }

            value?.Add(new(documentId, frequency));
        }

        public List<Posting> GetPostings(string term)
        {
            return index.TryGetValue(term, out var value) ? value : [];
        }
    }
}
