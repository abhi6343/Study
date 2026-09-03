namespace RealtimePolymorphismExample
{
    //Testing Polymorphism Principle
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal myDog = new Dog();
            Animal myCat = new Cat();
            MakeAnimalSound(myDog); // Outputs: The dog barks.
            MakeAnimalSound(myCat); // Outputs: The cat meows.


            Shape myCircle = new Circle();
            Shape myRectangle = new Rectangle();
            DrawShape(myCircle);      // Outputs: Drawing a circle on the canvas.
            DrawShape(myRectangle);   // Outputs: Drawing a rectangle on the canvas.


            PaymentMethod creditCardPayment = new CreditCard();
            PaymentMethod bankTransferPayment = new BankTransfer();
            PaymentMethod digitalWalletPayment = new DigitalWallet();
            ProcessPayment(creditCardPayment, 100.00M);      // Outputs: Processing a credit card payment for $100.00.
            ProcessPayment(bankTransferPayment, 250.50M);    // Outputs: Processing a bank transfer for $250.50.
            ProcessPayment(digitalWalletPayment, 75.25M);    // Outputs: Processing a digital wallet payment for $75.25.


            Vehicle myCar = new Car();
            Vehicle myBoat = new Boat();
            Vehicle myBicycle = new Bicycle();
            OperateVehicle(myCar);        // Outputs: Driving a car. Follow road signs!
            OperateVehicle(myBoat);       // Outputs: Piloting a boat. Watch out for waves and other vessels!
            OperateVehicle(myBicycle);    // Outputs: Riding a bicycle. Stay in the bike lane and wear a helmet!


            MediaFile mySong = new AudioFile("song.mp3");
            MediaFile myMovie = new VideoFile("movie.mp4");
            PlayMedia(mySong); // Outputs: Playing audio file: song.mp3.
            PlayMedia(myMovie); // Outputs: Playing video file: movie.mp4.


            Notification email = new EmailNotification("user@example.com", "Hello!", "This is a notification email.");
            Notification sms = new SmsNotification("123-456-7890", "This is an SMS notification.");
            Notification push = new PushNotification("Device123", "This is a push notification.");
            SendNotification(email);  // Outputs: Sending Email to user@example.com with subject: Hello! and message: This is a notification email.
            SendNotification(sms);    // Outputs: Sending SMS to 123-456-7890 with message: This is an SMS notification.
            SendNotification(push);   // Outputs: Sending Push Notification to device Device123 with message: This is a push notification.


            Console.Read();
        }

        // This function showcases polymorphism in action.
        // Even though it accepts a parameter of type 'Animal', 
        // it's able to handle any derived type.
        static void MakeAnimalSound(Animal animal)
        {
            animal.MakeSound();
        }

        // This function showcases polymorphism.
        // Even though it accepts a parameter of type 'Shape', 
        // it's able to handle any shape derived from it.
        static void DrawShape(Shape shape)
        {
            shape.Draw();
        }

        // Demonstrating polymorphism.
        // This function can accept any payment method derived from PaymentMethod.
        static void ProcessPayment(PaymentMethod paymentMethod, decimal amount)
        {
            paymentMethod.ExecutePayment(amount);
        }

        // Function showcasing polymorphism.
        // Accepts any vehicle type and drives it.
        static void OperateVehicle(Vehicle vehicle)
        {
            vehicle.Drive();
        }

        // Function illustrating polymorphism.
        // It can accept any media type derived from MediaFile and play it.
        static void PlayMedia(MediaFile media)
        {
            media.Play();
        }

        // Function illustrating polymorphism.
        // It can send any type of notification derived from the Notification base class.
        static void SendNotification(Notification notification)
        {
            notification.Send();
        }
    }
}
