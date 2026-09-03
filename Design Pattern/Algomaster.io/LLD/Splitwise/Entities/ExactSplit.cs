namespace Splitwise.Entities
{
    internal class ExactSplit : Split
    {
        public ExactSplit(string userId, double amount) : base(userId)
        {
            Amount = amount;
        }
    }
}
