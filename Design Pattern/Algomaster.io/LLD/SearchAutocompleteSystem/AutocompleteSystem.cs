using SearchAutocompleteSystem.Strategy;

namespace SearchAutocompleteSystem
{
    internal class AutocompleteSystem(IRankingStrategy rankingStrategy, int maxSuggestions)
    {
        readonly Trie.Trie trie = new();
        public void Insert(string word)
        {
            trie.Insert(word.ToLowerInvariant());
        }
        public void InsertWords(IEnumerable<string> words)
        {
            using var enumerator = words.GetEnumerator();
            while(enumerator.MoveNext())
            {
                Insert(enumerator.Current);
            }
        }
        public IEnumerable<string> GetSuggestions(string prefix)
        {
            var prefixNode = trie.SearchPrefix(prefix.ToLowerInvariant());
            if(prefixNode == null)
            {
                return [];
            }
            return rankingStrategy.Rank(Trie.Trie.CollectSuggestions(prefixNode, prefix)).Take(maxSuggestions).Select(s => s.Word);
        }
    }
}
