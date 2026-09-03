using System.Collections.Concurrent;

namespace Splitwise.Entities
{
    internal class BalanceSheet
    {
        // balances[A][B] = how much A owes B (positive = owes, negative = is owed)
        private readonly ConcurrentDictionary<string, ConcurrentDictionary<string, double>> balances = [];
        private readonly Lock lockObj = new();

        // Increases the debt from fromUserId to toUserId by amount
        // Also mirrors the update: toUserId's record shows they are owed
        public void UpdateBalance(string fromUserId, string toUserId, double amount)
        {
            lock (lockObj)
            {
                // Forward direction: fromUser owes toUser more
                var fromMap = balances.GetOrAdd(fromUserId, _ => []);
                fromMap.AddOrUpdate(toUserId, amount, (_, existing) => existing + amount);

                // Mirror direction: toUser is owed more by fromUser (negative amount)
                var toMap = balances.GetOrAdd(toUserId, _ => []);
                toMap.AddOrUpdate(fromUserId, -amount, (_, existing) => existing - amount);
            }
        }

        // Reduces the debt from fromUserId to toUserId by amount
        // If the settlement exceeds the debt, it creates a reverse debt
        public void SettleUp(string fromUserId, string toUserId, double amount)
        {
            // Settlement is the reverse of a balance update
            UpdateBalance(fromUserId, toUserId, -amount);
        }

        // Returns how much userId1 owes userId2
        // Positive = userId1 owes userId2, Negative = userId2 owes userId1
        public double GetBalance(string userId1, string userId2)
        {
            if (!balances.TryGetValue(userId1, out var userBalances)) return 0.0;
            return userBalances.TryGetValue(userId2, out var balance) ? balance : 0.0;
        }

        // Returns a snapshot of all balances for a user (defensive copy)
        public Dictionary<string, double> GetBalancesForUser(string userId)
        {
            if (!balances.TryGetValue(userId, out var userBalances))
            {
                return [];
            }
            return [];
        }
    }
}
