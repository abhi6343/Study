using PaymentGateway.Entities;

namespace PaymentGateway.Strategy
{
    internal interface IPaymentProcessor
    {
        PaymentResponse ProcessPayment(PaymentRequest request);
    }
}
