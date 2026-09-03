namespace Splitwise.Entities
{
    internal class PercentageSplit(string userId, double percentage) : Split(userId)
    {
        public double Percentage => percentage;
    }
}
