using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Singletons;

namespace LibraryManagementSystem.States
{
    internal class CheckedOutState : IItemState
    {
        public void Checkout(BookCopy copy, Member member)
        {
            Console.WriteLine($"{copy.Id} is already checked out.");
        }

        public void ReturnItem(BookCopy copy)
        {
            TransactionService.Instance.EndLoan(copy);
            Console.WriteLine($"{copy.Id} returned.");

            if (copy.Item.HasObservers())
            {
                copy.CurrentState = new OnHoldState();
                copy.Item.NotifyObservers();
            }
            else
            {
                copy.CurrentState = new AvailableState();
            }
        }

        public void PlaceHold(BookCopy copy, Member member)
        {
            copy.Item.AddObserver(member);
            Console.WriteLine($"{member.Name} placed a hold on '{copy.Item.Title}'");
        }
    }
}
