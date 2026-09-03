using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Enums;

namespace LibraryManagementSystem.Factory
{
    internal class ItemFactory
    {
        public static LibraryItem CreateItem(ItemType type, string id, string title, string author)
        {
            return type switch
            {
                ItemType.BOOK => new Book(id, title, author),
                ItemType.MAGAZINE => new Magazine(id, title, author),
                _ => throw new ArgumentException("Unknown item type."),
            };
        }
    }
}
