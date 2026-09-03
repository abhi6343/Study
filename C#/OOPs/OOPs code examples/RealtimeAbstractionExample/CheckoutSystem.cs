namespace RealtimeAbstractionExample
{
    //Using the Abstraction
    //With the abstraction in place, the checkout process becomes simplified
    internal class CheckoutSystem
    {
        public void Checkout(IPaymentMethod paymentMethod, decimal amount)
        {
            if (paymentMethod.ProcessPayment(amount))
            {
                Console.WriteLine("Payment successful!");
            }
            else
            {
                Console.WriteLine("Payment failed.");
            }
        }
    }
}
