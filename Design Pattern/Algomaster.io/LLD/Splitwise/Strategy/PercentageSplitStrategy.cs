using Splitwise.Entities;
using Splitwise.Exceptions;

namespace Splitwise.Strategy
{
    internal class PercentageSplitStrategy : ISplitStrategy
    {
        public void Validate(List<Split> splits, double totalAmount)
        {
            double totalPercentage = 0;
            foreach (var split in splits)
            {
                if (split is not PercentageSplit)
                {
                    throw new InvalidSplitException("All splits must be PercentageSplit for percentage split type");
                }
                totalPercentage += ((PercentageSplit)split).Percentage;
            }
            if (Math.Abs(totalPercentage - 100.0) > 0.01)
            {
                throw new InvalidSplitException($"Percentages ({totalPercentage:F2}%) don't sum to 100%");
            }
        }

        public void CalculateSplits(List<Split> splits, double totalAmount)
        {
            double allocated = 0;
            for (int i = 0; i < splits.Count - 1; i++)
            {
                var ps = (PercentageSplit)splits[i];
                double amount = Math.Round(totalAmount * ps.Percentage / 100.0, 2);
                ps.Amount = amount;
                allocated += amount;
            }
            // Last person gets the remainder to handle rounding
            double remainder = Math.Round(totalAmount - allocated, 2);
            splits[^1].Amount = remainder;
        }
    }
}
