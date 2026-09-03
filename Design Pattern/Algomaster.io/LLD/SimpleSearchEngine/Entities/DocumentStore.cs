namespace SimpleSearchEngine.Entities
{
    internal class DocumentStore
    {
        private readonly Dictionary<string, Document> store = [];

        public void AddDocument(Document doc)
        {
            store[doc.Id] = doc;
        }

        public Document? GetDocument(string docId)
        {
            store.TryGetValue(docId, out var doc);
            return doc;
        }
    }
}
