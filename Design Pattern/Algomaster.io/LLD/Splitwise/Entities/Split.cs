namespace Splitwise.Entities
{
    internal class Split(string userId)
    {
        public string UserId => userId;
        public double Amount { get; set; } = 0;
    }
}
