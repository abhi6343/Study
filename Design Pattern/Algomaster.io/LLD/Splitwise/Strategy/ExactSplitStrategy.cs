using Splitwise.Entities;
using Splitwise.Exceptions;

namespace Splitwise.Strategy
{
    internal class ExactSplitStrategy : ISplitStrategy
    {
        public void Validate(List<Split> splits, double totalAmount)
        {
            double sum = 0;
            foreach (var split in splits)
            {
                sum += split.Amount;
            }
            // Use epsilon comparison for floating point
            if (Math.Abs(sum - totalAmount) > 0.01)
            {
                throw new InvalidSplitException($"Exact split amounts ({sum:F2}) don't sum to total ({totalAmount:F2})");
            }
        }

        public void CalculateSplits(List<Split> splits, double totalAmount)
        {
            // Amounts are already set by the caller, nothing to calculate
        }
    }
}
