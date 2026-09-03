using PaymentGateway.Enums;
using PaymentGateway.Strategy;

namespace PaymentGateway.Factory
{
    internal class PaymentProcessorFactory
    {
        public static IPaymentProcessor GetProcessor(PaymentMethod method)
        {
            return method switch
            {
                PaymentMethod.CREDIT_CARD => new CreditCardProcessor(),
                PaymentMethod.UPI => new UPIProcessor(),
                PaymentMethod.PAYPAL => new PayPalProcessor(),
                _ => throw new ArgumentException($"Unsupported payment method: {method}")
            };
        }
    }
}
