namespace RealtimeInterfaceExample
{
    // StripePaymentGateway.cs
    internal class StripePaymentGateway : IPaymentGateway
    {
        public bool ProcessPayment(decimal amount)
        {
            // Call Stripe's API to process the payment
            Console.WriteLine($"Processing ${amount} payment using Stripe...");
            return true; // assume success for this example
        }
    }
}
