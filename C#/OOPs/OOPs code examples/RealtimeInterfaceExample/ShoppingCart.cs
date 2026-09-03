namespace RealtimeInterfaceExample
{
    //Step 3: Use the implementations in a shopping cart scenario.
    internal class ShoppingCart
    {
        private IPaymentGateway _paymentGateway;
        public ShoppingCart(IPaymentGateway paymentGateway)
        {
            _paymentGateway = paymentGateway;
        }
        public void Checkout(decimal amount)
        {
            if (_paymentGateway.ProcessPayment(amount))
            {
                Console.WriteLine("Payment was successful!");
            }
            else
            {
                Console.WriteLine("Payment failed. Please try again.");
            }
        }
    }
}
