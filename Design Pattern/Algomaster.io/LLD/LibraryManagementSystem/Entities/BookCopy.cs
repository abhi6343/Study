using LibraryManagementSystem.States;

namespace LibraryManagementSystem.Entities
{
    internal class BookCopy
    {
        readonly string id;
        readonly LibraryItem item;
        public IItemState CurrentState { get; set; } = new AvailableState();

        public BookCopy(string id, LibraryItem item)
        {
            this.id = id;
            this.item = item;
            item.AddCopy(this);
        }

        public void Checkout(Member member) { CurrentState.Checkout(this, member); }
        public void ReturnItem() { CurrentState.ReturnItem(this); }
        public void PlaceHold(Member member) { CurrentState.PlaceHold(this, member); }

        public string Id => id;
        public LibraryItem Item => item;
        public bool IsAvailable() => CurrentState is AvailableState;
    }
}
