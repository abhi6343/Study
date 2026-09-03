namespace RealtimeInterfaceExample
{
    //Step 2: Implement the interface for different payment providers.
    // PayPalPaymentGateway.cs
    internal class PayPalPaymentGateway : IPaymentGateway
    {
        public bool ProcessPayment(decimal amount)
        {
            // Call PayPal's API to process the payment
            Console.WriteLine($"Processing ${amount} payment using PayPal...");
            return true; // assume success for the sake of this example
        }
    }
}
