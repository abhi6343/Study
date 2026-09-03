namespace RealtimePolymorphismExample
{
    // Derived class for bank transfer
    internal class BankTransfer : PaymentMethod
    {
        public override void ExecutePayment(decimal amount)
        {
            Console.WriteLine($"Processing a bank transfer for ${amount}.");
            // Logic specific to bank transfers would be here
        }
    }
}
