namespace RealtimeEncapsulationExample
{
    internal class LibraryBook
    {
        private string title;
        private string isbn;
        private bool isCheckedOut;
        public LibraryBook(string title, string isbn)
        {
            this.title = title;
            this.isbn = isbn;
            this.isCheckedOut = false;
        }
        public string Title => title;
        public string ISBN => isbn;
        public bool IsCheckedOut => isCheckedOut;
        public void CheckOut()
        {
            if (isCheckedOut)
            {
                Console.WriteLine($"{title} is already checked out.");
            }
            else
            {
                isCheckedOut = true;
                Console.WriteLine($"Successfully checked out {title}.");
            }
        }
        public void ReturnBook()
        {
            if (!isCheckedOut)
            {
                Console.WriteLine($"{title} is not checked out. No need to return.");
            }
            else
            {
                isCheckedOut = false;
                Console.WriteLine($"Successfully returned {title}.");
            }
        }
    }
}
