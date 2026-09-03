namespace SearchAutocompleteSystem
{
    internal class Suggestion(string word, int weight)
    {
        public string Word { get { return word; } }
        public int Weight { get { return weight; } }
    }
}
