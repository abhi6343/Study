using LibraryManagementSystem.Entities;

namespace LibraryManagementSystem.Strategies
{
    internal class SearchByAuthorStrategy : ISearchStrategy
    {
        public List<LibraryItem> Search(string query, List<LibraryItem> items)
        {
            return [.. items.Where(item => item.GetAuthorOrPublisher().Contains(query, StringComparison.OrdinalIgnoreCase))];
        }
    }
}
