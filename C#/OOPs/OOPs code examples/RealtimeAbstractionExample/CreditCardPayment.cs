namespace RealtimeAbstractionExample
{
    //Concrete Implementations
    //Implement the interface for each payment method
    internal class CreditCardPayment : IPaymentMethod
    {
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of {amount:C}");
            // Logic to process credit card payment
            return true; // Let's assume the payment is successful for this ex
        }
    }
}
