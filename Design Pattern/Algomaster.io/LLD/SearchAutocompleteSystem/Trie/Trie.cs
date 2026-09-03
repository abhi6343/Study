namespace SearchAutocompleteSystem.Trie
{
    internal class Trie()
    {
        private readonly TrieNode root = new();               
        public void Insert(string word)
        {
            var currentNode = root;
            foreach (var ch in word)
            {
                int index = ch - 'a';
                if (currentNode.Children[index] == null)
                {
                    currentNode.Children[index] = new();
                }
                currentNode = currentNode.Children[index];
            }
            currentNode.IsEndOfWord = true;
            currentNode.Frequency++;
        }
        public TrieNode? SearchPrefix(string prefix)
        {
            var currentNode = root;
            foreach (var ch in prefix)
            {
                if (currentNode.Children[ch - 'a'] == null)
                {
                    return default;
                }
                currentNode = currentNode.Children[ch - 'a'];                
            }
            return currentNode;
        }

        public static IEnumerable<Suggestion> CollectSuggestions(TrieNode prefixNode, string prefix)
        {            
            var suggestions = new List<Suggestion>();
            Collect(prefixNode, prefix, ref suggestions);
            return suggestions;
        }
        static void Collect(TrieNode currentNode, string prefix, ref List<Suggestion> suggestions)
        { 
            if(currentNode == null)
            {
                return;
            }
            if (currentNode.IsEndOfWord) 
            {
                suggestions.Add(new(prefix, currentNode.Frequency));
            }
            for (int i = 0; i < 26; i++)
            {
                if(currentNode.Children[i] != null)
                {                    
                    Collect(currentNode.Children[i], prefix + (char)(i + 'a'), ref suggestions);
                }
            }
        }
    }
}
