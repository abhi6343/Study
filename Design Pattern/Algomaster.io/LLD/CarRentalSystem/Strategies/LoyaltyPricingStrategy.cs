using CarRentalSystem.Enums;
using CarRentalSystem.Extensions;

namespace CarRentalSystem.Strategies
{
    internal class LoyaltyPricingStrategy(IPricingStrategy baseStrategy, LoyaltyTier tier) : IPricingStrategy
    {
        public double CalculateCost(double dailyRate, int days)
        {
            double baseCost = baseStrategy.CalculateCost(dailyRate, days);
            return baseCost * (1 - tier.GetDiscount());
        }
    }
}
