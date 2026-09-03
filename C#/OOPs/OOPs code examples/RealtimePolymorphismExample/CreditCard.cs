namespace RealtimePolymorphismExample
{
    // Derived class for credit card payment
    internal class CreditCard : PaymentMethod
    {
        public override void ExecutePayment(decimal amount)
        {
            Console.WriteLine($"Processing a credit card payment for ${amount}.");
            // Here you'd have logic specific to credit card processing
        }
    }
}
