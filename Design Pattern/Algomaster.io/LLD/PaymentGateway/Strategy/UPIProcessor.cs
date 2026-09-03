using PaymentGateway.Entities;
using PaymentGateway.Enums;

namespace PaymentGateway.Strategy
{
    internal class UPIProcessor : AbstractPaymentProcessor
    {
        protected override PaymentResponse DoProcess(PaymentRequest request)
        {
            Console.WriteLine($"Processing UPI payment of {request.Amount} {request.Currency}");
            return new(PaymentStatus.SUCCESSFUL, "UPI payment successful.");
        }
    }
}
