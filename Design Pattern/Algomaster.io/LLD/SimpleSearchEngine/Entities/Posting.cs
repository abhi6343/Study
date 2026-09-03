namespace SimpleSearchEngine.Entities
{
    internal class Posting(string documentId, int frequency)
    {
        public string DocumentId => documentId;
        public int Frequency => frequency;
    }
}
