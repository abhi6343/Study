namespace Splitwise.Entities
{
    internal class Group(string id, string name)
    {
        public string Id => id;
        public string Name => name;
        private readonly List<string> memberIds = [];
        private readonly List<string> expenseIds = [];

        public void AddMember(string userId)
        {
            if (!memberIds.Contains(userId))
            {
                memberIds.Add(userId);
            }
        }

        public void AddExpense(string expenseId)
        {
            expenseIds.Add(expenseId);
        }

        public IReadOnlyList<string> MemberIds => memberIds.AsReadOnly();
        public IReadOnlyList<string> ExpenseIds => expenseIds.AsReadOnly();
    }
}
