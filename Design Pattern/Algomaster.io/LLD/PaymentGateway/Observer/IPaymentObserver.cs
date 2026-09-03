using PaymentGateway.Entities;

namespace PaymentGateway.Observer
{
    internal interface IPaymentObserver
    {
        void OnTransactionUpdate(Transaction transaction);
    }
}
