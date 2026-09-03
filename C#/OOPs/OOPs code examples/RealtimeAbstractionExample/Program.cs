namespace RealtimeAbstractionExample
{
    //Testing Abstraction Principle
    internal class Program
    {
        static void Main(string[] args)
        {
            // Using the Abstraction
            Vehicle myCar = new Car();
            Vehicle myTrain = new ElectricTrain();
            StartVehicle(myCar);  // Output: Car is starting with a key turn.
            StartVehicle(myTrain); // Output: Electric train is starting by powering up.


            // Using the Abstraction
            // With the Abstraction Principle applied, if you need to send a message, 
            // you don’t need to know if it’s an email, SMS, or push notification.
            // You just call SendMessage() on any service implementing IMessagingService.
            IMessagingService emailService = new EmailService();
            IMessagingService smsService = new SmsService();
            IMessagingService pushService = new PushNotificationService();
            SendAlert(emailService, "example@example.com", "Hello via Email!");
            SendAlert(smsService, "1234567890", "Hello via SMS!");
            SendAlert(pushService, "User123", "Hello via Push Notification!");


            // Using the Abstraction
            // Now, you can use the abstraction to play any media without worrying about its type.
            IMediaPlayer audioPlayer = new AudioPlayer();
            IMediaPlayer videoPlayer = new VideoPlayer();
            PlayMedia(audioPlayer, "song.mp3");
            PlayMedia(videoPlayer, "movie.mp4");


            CheckoutSystem checkoutSystem = new CheckoutSystem();
            IPaymentMethod creditCard = new CreditCardPayment();
            IPaymentMethod payPal = new PayPalPayment();
            IPaymentMethod bitcoin = new BitcoinPayment();
            checkoutSystem.Checkout(creditCard, 99.99M);
            checkoutSystem.Checkout(payPal, 49.99M);
            checkoutSystem.Checkout(bitcoin, 29.99M);


            DataProcessing processor = new DataProcessing();
            IDataFetcher dbFetcher = new DatabaseFetcher();
            IDataFetcher apiFetcher = new ApiFetcher();
            IDataFetcher fileFetcher = new FileFetcher();
            processor.ProcessData(dbFetcher); // Outputs: Data from Database
            processor.ProcessData(apiFetcher); // Outputs: Data from API
            processor.ProcessData(fileFetcher); // Outputs: Data from File


            ZooKeeper zooKeeper = new ZooKeeper();
            IAnimal lion = new Lion();
            IAnimal snake = new Snake();
            IAnimal bird = new Bird();
            zooKeeper.CheckAnimalSound(lion); // Outputs: Lion roars!
            zooKeeper.CheckAnimalSound(snake); // Outputs: Snake hisses!
            zooKeeper.CheckAnimalSound(bird); // Outputs: Bird chirps!


            HotelBooking booking = new HotelBooking();
            IRoom standard = new StandardRoom();
            IRoom deluxe = new DeluxeRoom();
            IRoom suite = new Suite();
            booking.BookRoom(standard);
            booking.BookRoom(deluxe);
            booking.BookRoom(suite);


            Console.Read();
        }
        static void StartVehicle(Vehicle vehicle)
        {
            vehicle.Start();
        }
        static void SendAlert(IMessagingService service, string recipient, string message)
        {
            service.SendMessage(recipient, message);
        }
        static void PlayMedia(IMediaPlayer player, string filePath)
        {
            player.Play(filePath);
        }
    }
}
