using PaymentGateway.Entities;
using PaymentGateway.Enums;

namespace PaymentGateway.Strategy
{
    internal abstract class AbstractPaymentProcessor : IPaymentProcessor
    {
        private const int MAX_RETRIES = 3;

        public PaymentResponse ProcessPayment(PaymentRequest request)
        {
            int attempts = 0;
            PaymentResponse response;
            do
            {
                response = DoProcess(request);
                attempts++;
            } while (response.Status == PaymentStatus.FAILED && attempts < MAX_RETRIES);

            return response;
        }

        protected abstract PaymentResponse DoProcess(PaymentRequest request);
    }
}
