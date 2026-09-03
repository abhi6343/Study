namespace CarRentalSystem.Strategies
{
    internal interface IPricingStrategy
    {
        double CalculateCost(double dailyRate, int days);
    }
}
