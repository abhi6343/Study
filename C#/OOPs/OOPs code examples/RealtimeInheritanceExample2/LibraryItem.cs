namespace RealtimeInheritanceExample2
{
    //Base Class (Parent Class) - LibraryItem
    internal class LibraryItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public LibraryItem(string id, string title)
        {
            Id = id;
            Title = title;
        }
        public void Borrow()
        {
            Console.WriteLine($"'{Title}' has been borrowed.");
        }
        public void Return()
        {
            Console.WriteLine($"'{Title}' has been returned.");
        }
    }
}
