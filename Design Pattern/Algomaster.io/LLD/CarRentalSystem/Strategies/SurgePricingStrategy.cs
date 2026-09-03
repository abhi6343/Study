namespace CarRentalSystem.Strategies
{
    internal class SurgePricingStrategy(double surgeMultiplier) : IPricingStrategy
    {
        public double CalculateCost(double dailyRate, int days)
        {
            return dailyRate * days * surgeMultiplier;
        }
    }
}
