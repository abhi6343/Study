using PaymentGateway.Enums;

namespace PaymentGateway.Entities
{
    internal class Transaction(PaymentRequest request)
    {
        private readonly DateTime timestamp = DateTime.Now;        

        public string Id => request.TransactionId;
        public PaymentStatus Status {  get; set; } = PaymentStatus.INITIATED;
        public PaymentRequest Request => request; 
    }
}
