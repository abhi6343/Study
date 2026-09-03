namespace SearchAutocompleteSystem.Trie
{
    internal class TrieNode
    {
        readonly TrieNode[] children = new TrieNode[26];
        public bool IsEndOfWord { get; set; }               
        public int Frequency { get; set; }        
        public TrieNode[] Children { get { return children; } }
    }
}
