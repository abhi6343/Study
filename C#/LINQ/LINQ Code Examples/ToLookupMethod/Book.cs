namespace ToLookupMethod
{
    internal class Book
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public Book(string title, string genre)
        {
            Title = title;
            Genre = genre;
        }
    }
}
