namespace RealtimeInterfaceExample
{
    //Step 1: Define the IPaymentGateway interface.
    internal interface IPaymentGateway
    {
        bool ProcessPayment(decimal amount);
    }
}
