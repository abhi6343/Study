using LibraryManagementSystem.Entities;

namespace LibraryManagementSystem.Strategies
{
    internal class SearchByTitleStrategy : ISearchStrategy
    {
        public List<LibraryItem> Search(string query, List<LibraryItem> items)
        {
            return [.. items.Where(item => item.Title.Contains(query, StringComparison.OrdinalIgnoreCase))];
        }
    }
}
