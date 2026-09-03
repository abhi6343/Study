namespace SimpleSearchEngine.Entities
{
    internal class SearchResult(Document document, double score)
    {
        public Document Document => document;
        public double Score => score;

        public override string ToString()
        {
            return "  - " + document.Title + " (Score: " + score.ToString("F2") + ")";
        }
    }
}
