namespace RealtimePolymorphismExample
{
    // Derived class for digital wallet payment
    internal class DigitalWallet : PaymentMethod
    {
        public override void ExecutePayment(decimal amount)
        {
            Console.WriteLine($"Processing a digital wallet payment for ${amount}.");
            // Logic specific to digital wallet payment would go here
        }
    }
}
