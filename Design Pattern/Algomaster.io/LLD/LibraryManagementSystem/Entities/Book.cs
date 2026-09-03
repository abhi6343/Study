namespace LibraryManagementSystem.Entities
{
    internal class Book(string id, string title, string author) : LibraryItem(id, title)
    {
        public override string GetAuthorOrPublisher() => author;
    }
}
