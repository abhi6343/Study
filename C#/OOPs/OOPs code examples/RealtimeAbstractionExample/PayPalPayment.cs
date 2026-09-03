namespace RealtimeAbstractionExample
{
    internal class PayPalPayment : IPaymentMethod
    {
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of {amount:C}");
            // Logic to process PayPal payment
            return true;
        }
    }
}
