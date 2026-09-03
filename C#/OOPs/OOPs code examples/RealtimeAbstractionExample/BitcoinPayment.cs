namespace RealtimeAbstractionExample
{
    internal class BitcoinPayment : IPaymentMethod
    {
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing Bitcoin payment of {amount:C}");
            // Logic to process Bitcoin payment
            return true;
        }
    }
}
