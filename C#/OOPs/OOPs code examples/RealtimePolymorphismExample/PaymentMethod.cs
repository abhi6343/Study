namespace RealtimePolymorphismExample
{
    // Base class
    internal abstract class PaymentMethod
    {
        public abstract void ExecutePayment(decimal amount);
    }
}
