using CarRentalSystem.Enums;

namespace CarRentalSystem.Extensions
{
    internal static class LoyaltyTierExtensions
    {
        public static double GetDiscount(this LoyaltyTier tier)
        {
            return tier switch
            {
                LoyaltyTier.BRONZE => 0.05,
                LoyaltyTier.SILVER => 0.10,
                LoyaltyTier.GOLD => 0.15,
                _ => 0,
            };
        }
    }
}
