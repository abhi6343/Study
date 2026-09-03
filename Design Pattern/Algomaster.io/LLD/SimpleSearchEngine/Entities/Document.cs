namespace SimpleSearchEngine.Entities
{
    internal class Document(string id, string title, string content)
    {
        public string Id => id;
        public string Title => title;
        public string Content => content;

        public override string ToString()
        {
            return "Document(id=" + id + ", title='" + title + "')";
        }
    }
}
