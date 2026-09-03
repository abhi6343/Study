using PaymentGateway.Entities;
using PaymentGateway.Enums;

namespace PaymentGateway.Strategy
{ 
    internal class CreditCardProcessor : AbstractPaymentProcessor
    {
        protected override PaymentResponse DoProcess(PaymentRequest request)
        {
            Console.WriteLine($"Processing credit card payment of amount {request.Amount} {request.Currency}");
            // Simulate interaction with Visa/Mastercard network
            return new(PaymentStatus.SUCCESSFUL, "Credit Card payment successful.");
        }
    }
}
