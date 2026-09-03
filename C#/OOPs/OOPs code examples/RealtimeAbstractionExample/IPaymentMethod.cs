namespace RealtimeAbstractionExample
{
    //Abstraction Layer
    //Define an interface representing any payment method
    internal interface IPaymentMethod
    {
        bool ProcessPayment(decimal amount);
    }
}
