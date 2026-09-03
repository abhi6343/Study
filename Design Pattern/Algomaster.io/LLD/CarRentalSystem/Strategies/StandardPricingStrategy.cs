namespace CarRentalSystem.Strategies
{
    internal class StandardPricingStrategy : IPricingStrategy
    {
        public double CalculateCost(double dailyRate, int days)
        {
            return dailyRate * days;
        }
    }
}
