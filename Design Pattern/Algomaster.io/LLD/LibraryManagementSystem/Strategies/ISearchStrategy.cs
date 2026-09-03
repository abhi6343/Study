using LibraryManagementSystem.Entities;

namespace LibraryManagementSystem.Strategies
{
    internal interface ISearchStrategy
    {
        List<LibraryItem> Search(string query, List<LibraryItem> items);
    }
}
