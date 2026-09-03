using Splitwise.Entities;

namespace Splitwise.Observer
{
    internal interface IExpenseObserver
    {
        void OnExpenseAdded(Expense expense);
        void OnSettlement(string fromUserId, string toUserId, double amount);
    }
}
