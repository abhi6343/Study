namespace RealtimeInterfaceExample
{
    //Step 4: Testing the application.
    internal class Program
    {
        static void Main(string[] args)
        {
            ChatApp chat = new ChatApp();
            chat.SendMessage("Hello! Please avoid using badword1 in our chat.");
            // Outputs: "Sending Message: HELLO! PLEASE AVOID USING **** IN OUR CHAT."


            List<IMovable> vehicles = new List<IMovable> { new Car(), new Boat(), new Airplane() };
            foreach (var vehicle in vehicles)
            {
                vehicle.Move();
            }


            // Customer selects PayPal as their preferred payment method
            ShoppingCart cart = new ShoppingCart(new PayPalPaymentGateway());
            cart.Checkout(100.00M);
            // Another customer selects Stripe
            cart = new ShoppingCart(new StripePaymentGateway());
            cart.Checkout(200.00M);


            // Using SQL Database
            DatabaseManager dbManager = new DatabaseManager(new SqlDatabase());
            dbManager.AddData("SampleData1");
            // Using NoSQL Database
            dbManager = new DatabaseManager(new NoSqlDatabase());
            dbManager.AddData("SampleData2");


            // Log to console
            Application appWithConsoleLogging = new Application(new ConsoleLogger());
            appWithConsoleLogging.Run();
            // Log to file
            Application appWithFileLogging = new Application(new FileLogger("app.log"));
            appWithFileLogging.Run();


            List<IDrawable> shapes = new List<IDrawable> { new Circle(), new Rectangle(), new Triangle() };
            foreach (var shape in shapes)
            {
                shape.Draw();
            }


            AuthService passwordService = new AuthService(new PasswordAuthenticator());
            passwordService.AuthenticateUser();
            AuthService fingerprintService = new AuthService(new FingerprintAuthenticator());
            fingerprintService.AuthenticateUser();
            AuthService faceService = new AuthService(new FaceRecognitionAuthenticator());
            faceService.AuthenticateUser();


            Console.ReadKey();
        }
    }
}
