using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Singletons;

namespace LibraryManagementSystem.States
{
    internal class AvailableState : IItemState
    {
        public void Checkout(BookCopy copy, Member member)
        {
            TransactionService.Instance.CreateLoan(copy, member);
            copy.CurrentState = new CheckedOutState();
            Console.WriteLine($"{copy.Id} checked out by {member.Name}");
        }

        public void ReturnItem(BookCopy copy)
        {
            Console.WriteLine("Cannot return an item that is already available.");
        }

        public void PlaceHold(BookCopy copy, Member member)
        {
            Console.WriteLine("Cannot place hold on an available item. Please check it out.");
        }
    }
}
