namespace RealtimeAbstractClassExample
{
    //Step 4: Testing the application.
    internal class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount johnsSavings = new SavingsAccount("SA123456", "John Doe");
            johnsSavings.Deposit(1000);
            johnsSavings.Withdraw(200);
            johnsSavings.AddInterest();
            johnsSavings.DisplayBalance();

            CurrentAccount janesCurrent = new CurrentAccount("CA654321", "Jane Smith");
            janesCurrent.Deposit(500);
            janesCurrent.Withdraw(1000);
            janesCurrent.DisplayBalance();


            Circle circle = new Circle(5);
            Rectangle rectangle = new Rectangle(4, 7);
            circle.Display();
            rectangle.Display();


            Dog dog = new Dog("Buddy");
            Fish fish = new Fish("Nemo");
            dog.Speak();
            dog.Eat();
            fish.Speak();
            fish.Eat();


            Car toyota = new Car("Toyota");
            Bicycle trek = new Bicycle("Trek");
            toyota.Move();
            toyota.Refuel();
            trek.Move();
            trek.Refuel();


            Manager alice = new Manager("Alice", "M001");
            Developer bob = new Developer("Bob", "D001");
            alice.PerformTask();
            alice.AttendMeeting();
            bob.PerformTask();
            bob.AttendMeeting();


            AudioPlayer music = new AudioPlayer();
            music.LoadFile("song.mp3");
            music.Play();
            music.Pause();
            music.Stop();
            VideoPlayer movie = new VideoPlayer();
            movie.LoadFile("movie.mp4");
            movie.Play();
            movie.Pause();
            movie.Stop();


            Console.ReadKey();

        }
    }
}
