using PaymentGateway.Entities;

namespace PaymentGateway.Observer
{
    internal class MerchantNotifier : IPaymentObserver
    {
        public void OnTransactionUpdate(Transaction transaction)
        {
            Console.WriteLine("--- MERCHANT NOTIFICATION ---");
            Console.WriteLine($"Transaction {transaction.Id} status updated to: {transaction.Status}");
            Console.WriteLine("-----------------------------");
        }
    }
}
