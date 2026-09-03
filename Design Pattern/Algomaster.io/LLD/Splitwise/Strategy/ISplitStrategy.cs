using Splitwise.Entities;

namespace Splitwise.Strategy
{
    internal interface ISplitStrategy
    {
        void Validate(List<Split> splits, double totalAmount);
        void CalculateSplits(List<Split> splits, double totalAmount);
    }
}
