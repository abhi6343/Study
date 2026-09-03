using PaymentGateway.Entities;
using PaymentGateway.Enums;

namespace PaymentGateway.Observer
{
    internal class CustomerNotifier : IPaymentObserver
    {
        public void OnTransactionUpdate(Transaction transaction)
        {
            if (transaction.Status == PaymentStatus.SUCCESSFUL)
            {
                Console.WriteLine("--- CUSTOMER EMAIL ---");
                Console.WriteLine($"Your payment of {transaction.Request.Amount} was successful. Transaction ID: {transaction.Id}");
                Console.WriteLine("----------------------");
            }
        }
    }
}
