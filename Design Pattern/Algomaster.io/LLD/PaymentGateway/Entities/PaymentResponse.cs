using PaymentGateway.Enums;

namespace PaymentGateway.Entities
{
    internal class PaymentResponse(PaymentStatus status, string message)
    {
        public PaymentStatus Status => status;
        public string Message => message;
    }
}
