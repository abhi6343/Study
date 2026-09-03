using PaymentGateway.Enums;

namespace PaymentGateway.Entities
{
    internal class PaymentRequest(PaymentRequest.Builder builder)
    {
        private readonly string transactionId = Guid.NewGuid().ToString();
        public string PayerId => builder.payerId;
        public Dictionary<string, string> PaymentDetails => builder.paymentDetails;

        public string TransactionId => transactionId;
        public double Amount => builder.amount;
        public string Currency => builder.currency;
        public PaymentMethod PaymentMethod => builder.paymentMethod;

        public class Builder
        {
            internal string payerId;
            internal double amount;
            internal string currency;
            internal PaymentMethod paymentMethod;
            internal Dictionary<string, string> paymentDetails;

            public Builder PayerId(string payerId)
            {
                this.payerId = payerId;
                return this;
            }

            public Builder Amount(double amount)
            {
                this.amount = amount;
                return this;
            }

            public Builder Currency(string currency)
            {
                this.currency = currency;
                return this;
            }

            public Builder PaymentMethod(PaymentMethod paymentMethod)
            {
                this.paymentMethod = paymentMethod;
                return this;
            }

            public Builder PaymentDetails(Dictionary<string, string> paymentDetails)
            {
                this.paymentDetails = paymentDetails;
                return this;
            }

            public PaymentRequest Build()
            {
                return new(this);
            }
        }
    }
}
