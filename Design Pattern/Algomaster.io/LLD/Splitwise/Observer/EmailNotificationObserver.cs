using Splitwise.Entities;

namespace Splitwise.Observer
{
    internal class EmailNotificationObserver : IExpenseObserver
    {
        public void OnExpenseAdded(Expense expense)
        {
            Console.WriteLine($"[Email Notification] New expense: {expense.Description} " +
                $"(${expense.Amount:F2}) paid by {expense.PaidByUserId}, " +
                $"split {expense.SplitType} among {expense.Splits.Count} people");
        }

        public void OnSettlement(string fromUserId, string toUserId, double amount)
        {
            Console.WriteLine($"[Email Notification] Settlement: {fromUserId} paid {toUserId} ${amount:F2}");
        }
    }
}
