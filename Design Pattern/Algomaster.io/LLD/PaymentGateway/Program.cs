using PaymentGateway;
using PaymentGateway.Entities;
using PaymentGateway.Enums;
using PaymentGateway.Observer;

// 1. Setup the gateway facade
var paymentGateway = PaymentGatewayService.Instance;

// 2. Register observers to be notified of transaction events
paymentGateway.AddObserver(new MerchantNotifier());
paymentGateway.AddObserver(new CustomerNotifier());

Console.WriteLine("----------- SCENARIO 1: Successful Credit Card Payment -----------");
// a. Merchant's backend creates a payment request
var ccRequest = new PaymentRequest.Builder()
        .PayerId("U-123")
        .Amount(150.75)
        .Currency("INR")
        .PaymentMethod(PaymentMethod.CREDIT_CARD)
        .PaymentDetails(new Dictionary<string, string> { { "cardNumber", "1234..." } })
        .Build();

// b. Merchant's backend sends it to the facade
paymentGateway.ProcessPayment(ccRequest);

Console.WriteLine("\n----------- SCENARIO 2: Successful PayPal Payment -----------");
var paypalRequest = new PaymentRequest.Builder()
        .PayerId("U-456")
        .Amount(88.50)
        .Currency("USD")
        .PaymentMethod(PaymentMethod.PAYPAL)
        .PaymentDetails(new Dictionary<string, string> { { "email", "customer@example.com" } })
        .Build();

paymentGateway.ProcessPayment(paypalRequest);