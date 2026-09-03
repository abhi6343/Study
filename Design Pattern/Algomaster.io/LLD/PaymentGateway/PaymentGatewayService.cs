using PaymentGateway.Entities;
using PaymentGateway.Enums;
using PaymentGateway.Factory;
using PaymentGateway.Observer;
using PaymentGateway.Strategy;

namespace PaymentGateway
{
    internal class PaymentGatewayService
    {
        private static PaymentGatewayService? instance;
        private readonly List<IPaymentObserver> observers = [];

        private PaymentGatewayService() { }

        public static PaymentGatewayService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance ??= new();
                }
                return instance;
            }
        }

        public void AddObserver(IPaymentObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IPaymentObserver observer)
        {
            observers.Remove(observer);
        }

        private void NotifyObservers(Transaction transaction)
        {
            foreach (var observer in observers)
            {
                observer.OnTransactionUpdate(transaction);
            }
        }

        public Transaction ProcessPayment(PaymentRequest request)
        {
            var transaction = new Transaction(request);
            try
            {
                IPaymentProcessor processor = PaymentProcessorFactory.GetProcessor(request.PaymentMethod);
                var response = processor.ProcessPayment(request);
                transaction.Status = response.Status;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Payment processing failed: {e.Message}");
                transaction.Status = PaymentStatus.FAILED;
            }

            NotifyObservers(transaction);
            return transaction;
        }
    }
}
