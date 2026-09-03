using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Singletons;

namespace LibraryManagementSystem.States
{
    internal class OnHoldState : IItemState
    {
        public void Checkout(BookCopy copy, Member member)
        {
            if (copy.Item.IsObserver(member))
            {
                TransactionService.Instance.CreateLoan(copy, member);
                copy.Item.RemoveObserver(member);
                copy.CurrentState = new CheckedOutState();
                Console.WriteLine($"Hold fulfilled. {copy.Id} checked out by {member.Name}");
            }
            else
            {
                Console.WriteLine("This item is on hold for another member.");
            }
        }

        public void ReturnItem(BookCopy copy)
        {
            Console.WriteLine("Invalid action. Item is on hold, not checked out.");
        }

        public void PlaceHold(BookCopy copy, Member member)
        {
            Console.WriteLine("Item is already on hold.");
        }
    }
}
