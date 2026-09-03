namespace RealtimeInheritanceExample2
{
    //Derived Class (Child Class) - Book
    internal class Book : LibraryItem
    {
        public string Author { get; set; }
        public int Pages { get; set; }
        public Book(string id, string title, string author, int pages)
        : base(id, title)
        {
            Author = author;
            Pages = pages;
        }
        public void DisplayBookInfo()
        {
            Console.WriteLine($"Book: '{Title}' by {Author}, {Pages} pages.");
        }
    }
}
