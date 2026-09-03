namespace RealtimeInheritanceExample2
{
    //Testing Inheritance Principle
    internal class Program
    {
        static void Main(string[] args)
        {
            //Using the Inheritance
            Car myCar = new Car { Doors = 4 };
            myCar.Start();
            myCar.Accelerate();
            myCar.OpenSunroof();
            myCar.Stop();
            Console.WriteLine();
            Motorcycle myBike = new Motorcycle { HasSideCar = false };
            myBike.Start();
            myBike.Accelerate();
            myBike.UseKickstand();
            myBike.Stop();


            //Using the Inheritance
            Student john = new Student("John Doe", 20, "123 Main St", "S12345");
            john.DisplayDetails();
            john.Enroll("Mathematics");
            Console.WriteLine();

            Teacher mrsSmith = new Teacher("Mrs. Smith", 40, "456 Elm St", "T98765");
            mrsSmith.DisplayDetails();
            mrsSmith.Teach("Physics");


            //Using the Inheritance
            Bird parrot = new Bird("Parrot", 5, "seeds", true);
            parrot.Display();
            Console.WriteLine();
            Mammal lion = new Mammal("Lion", 8, "meat", "roar");
            lion.Display();


            //Using the Inheritance
            MobilePhone nokia3310 = new MobilePhone { Brand = "Nokia" };
            nokia3310.PowerOn();
            nokia3310.MakeCall("123-456-7890");
            nokia3310.ReceiveCall("098-765-4321");
            nokia3310.PowerOff();
            Console.WriteLine();
            SmartPhone iPhone = new SmartPhone { Brand = "Apple" };
            iPhone.PowerOn();
            iPhone.BrowseWeb("www.example.com");
            iPhone.InstallApp("ChatApp");
            iPhone.MakeCall("123-456-7890");
            iPhone.PowerOff();


            //Using the Inheritance
            Book novel = new Book("BK001", "The Great Novel", "John Doe", 320);
            novel.DisplayBookInfo();
            novel.Borrow();
            novel.Return();
            Console.WriteLine();
            DVD movie = new DVD("DV001", "Epic Movie", 120);
            movie.DisplayDVDInfo();
            movie.Borrow();
            movie.Return();


            //Using the Inheritance
            Desktop gamingPC = new Desktop("Intel i9", 32, 1024, "Liquid Cooling");
            gamingPC.DisplayDesktopInfo();
            gamingPC.BootUp();
            Console.WriteLine();

            Laptop ultrabook = new Laptop("Intel i7", 16, 512, 10);
            ultrabook.DisplayLaptopInfo();
            ultrabook.BootUp();


            Console.Read();
        }
    }
}
