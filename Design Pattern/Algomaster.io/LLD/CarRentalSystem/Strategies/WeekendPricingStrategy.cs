namespace CarRentalSystem.Strategies
{
    internal class WeekendPricingStrategy(double weekendMultiplier) : IPricingStrategy
    {
        public double CalculateCost(double dailyRate, int days)
        {
            return dailyRate * days * weekendMultiplier;
        }
    }
}
