using PaymentGateway.Entities;
using PaymentGateway.Enums;

namespace PaymentGateway.Strategy
{
    internal class PayPalProcessor : AbstractPaymentProcessor
    {
        protected override PaymentResponse DoProcess(PaymentRequest request)
        {
            Console.WriteLine($"Redirecting to PayPal for transaction {request.TransactionId}");
            // Simulate PayPal API interaction
            return new(PaymentStatus.SUCCESSFUL, "Paypal payment successful.");
        }
    }
}
