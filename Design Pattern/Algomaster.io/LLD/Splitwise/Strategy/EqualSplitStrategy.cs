using Splitwise.Entities;
using Splitwise.Exceptions;

namespace Splitwise.Strategy
{
    internal class EqualSplitStrategy : ISplitStrategy
    {
        public void Validate(List<Split> splits, double totalAmount)
        {
            if (splits == null || splits.Count == 0)
            {
                throw new InvalidSplitException("Splits list cannot be empty for equal split");
            }
        }

        public void CalculateSplits(List<Split> splits, double totalAmount)
        {
            int count = splits.Count;
            double equalShare = Math.Round(totalAmount / count, 2);

            // Assign equal share to all except last
            for (int i = 0; i < count - 1; i++)
            {
                splits[i].Amount = equalShare;
            }

            // Last person absorbs rounding remainder
            double remainder = Math.Round(totalAmount - (equalShare * (count - 1)), 2);
            splits[count - 1].Amount = remainder;
        }
    }
}
