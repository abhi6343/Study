using Splitwise.Entities;
using Splitwise.Enums;
using Splitwise.Exceptions;
using Splitwise.Observer;
using Splitwise.Strategy;
using System.Collections.Concurrent;

namespace Splitwise
{
    internal class SplitwiseService
    {
        private static volatile SplitwiseService? instance;
        private static readonly Lock lockObj = new();

        private readonly ConcurrentDictionary<string, User> users = [];
        private readonly ConcurrentDictionary<string, Group> groups = [];
        private readonly ConcurrentDictionary<string, Expense> expenses = [];
        private readonly Dictionary<SplitType, ISplitStrategy> strategies = [];
        private readonly BalanceSheet balanceSheet = new();
        // Thread-safe list for observers, copy-on-read for safe iteration
        private readonly List<IExpenseObserver> observers = [];
        private readonly Lock observerLock = new();

        private SplitwiseService()
        {
            // Register all split strategies
            strategies = new Dictionary<SplitType, ISplitStrategy> 
            {
                { SplitType.Equal, new EqualSplitStrategy() },
                { SplitType.Exact, new ExactSplitStrategy() },
                { SplitType.Percentage, new PercentageSplitStrategy() }
            };
        }

        public static SplitwiseService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        instance ??= new();
                    }
                }
                return instance;
            }
        }

        public void AddUser(User user)
        {
            users[user.Id] = user;
        }

        public Group CreateGroup(string id, string name)
        {
            var group = new Group(id, name);
            groups[id] = group;
            return group;
        }

        public void AddMemberToGroup(string groupId, string userId)
        {
            if (!groups.TryGetValue(groupId, out var group))
            {
                throw new GroupNotFoundException($"Group not found: {groupId}");
            }
            if (!users.ContainsKey(userId))
            {
                throw new UserNotFoundException($"User not found: {userId}");
            }
            group.AddMember(userId);
        }

        public Expense AddExpense(string id, double amount, string description,
                                  string paidByUserId, SplitType splitType,
                                  List<Split> splits, string groupId = null)
        {
            // 1. Validate payer exists
            if (!users.ContainsKey(paidByUserId))
            {
                throw new UserNotFoundException($"User not found: {paidByUserId}");
            }

            // 2. Look up and apply the strategy
            var strategy = strategies[splitType];
            strategy.Validate(splits, amount);
            strategy.CalculateSplits(splits, amount);

            // 3. Create the expense
            var expense = new Expense(id, amount, description, paidByUserId, splitType, splits, groupId);
            expenses[id] = expense;

            // 4. Associate with group if applicable
            if (groupId != null)
            {
                if (!groups.TryGetValue(groupId, out var group))
                {
                    throw new GroupNotFoundException($"Group not found: {groupId}");
                }
                group.AddExpense(id);
            }

            // 5. Update balances - each participant owes the payer their share
            foreach (var split in expense.Splits)
            {
                if (split.UserId != paidByUserId)
                {
                    balanceSheet.UpdateBalance(split.UserId, paidByUserId, split.Amount);
                }
            }

            // 6. Notify observers
            List<IExpenseObserver> snapshot = [];
            lock (observerLock)
            {
                snapshot = [..observers];
            }
            foreach (var observer in snapshot)
            {
                observer.OnExpenseAdded(expense);
            }

            return expense;
        }

        public void SettleUp(string fromUserId, string toUserId, double amount)
        {
            if (!users.ContainsKey(fromUserId))
            {
                throw new UserNotFoundException($"User not found: {fromUserId}");
            }
            if (!users.ContainsKey(toUserId))
            {
                throw new UserNotFoundException($"User not found: {toUserId}");
            }

            balanceSheet.SettleUp(fromUserId, toUserId, amount);

            List<IExpenseObserver> snapshot = [];
            lock (observerLock)
            {
                snapshot = [..observers];
            }
            foreach (var observer in snapshot)
            {
                observer.OnSettlement(fromUserId, toUserId, amount);
            }
        }

        public double GetBalance(string userId1, string userId2)
        {
            return balanceSheet.GetBalance(userId1, userId2);
        }

        public Dictionary<string, double> GetBalancesForUser(string userId)
        {
            return balanceSheet.GetBalancesForUser(userId);
        }

        public void AddObserver(IExpenseObserver observer)
        {
            lock (observerLock)
            {
                observers.Add(observer);
            }
        }

        public static void ResetInstance()
        {
            lock (lockObj)
            {
                instance = null;
            }
        }
    }
}
