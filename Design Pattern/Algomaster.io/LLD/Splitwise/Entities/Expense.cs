using Splitwise.Enums;

namespace Splitwise.Entities
{
    internal class Expense(string id, double amount, string description,
                   string paidByUserId, SplitType splitType,
                   List<Split> splits, string groupId)
    {
        public string Id => id;
        public double Amount => amount;
        public string Description => description;
        public string PaidByUserId => paidByUserId;
        public SplitType SplitType => splitType;
        public IReadOnlyList<Split> Splits => new List<Split>(splits).AsReadOnly();
        public string GroupId => groupId;
        public static DateTime CreatedAt => DateTime.Now;
    }
}
