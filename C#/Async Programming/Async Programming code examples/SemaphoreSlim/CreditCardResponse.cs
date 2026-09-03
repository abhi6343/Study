namespace SemaphoreSlim
{
    //This class will hold the response after processing the Credit card
    internal class CreditCardResponse
    {
        public long CardNumber { get; set; }
        public string Name { get; set; }
        public bool IsProcessed { get; set; }
    }
}
