namespace LibraryManagementSystem.Entities
{
    internal class Magazine(string id, string title, string publisher) : LibraryItem(id, title)
    {
        public override string GetAuthorOrPublisher() => publisher;
    }
}
