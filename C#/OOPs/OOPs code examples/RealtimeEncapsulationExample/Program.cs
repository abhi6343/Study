namespace RealtimeEncapsulationExample
{
    //Testing Encapsulation Principle
    internal class Program
    {
        static void Main(string[] args)
        {
            // Starts with a balance of 500
            BankAccount myAccount = new BankAccount(500);
            // Balance becomes 700
            myAccount.Deposit(200);
            Console.WriteLine(myAccount.Balance); // Outputs: 700
            // Balance becomes 600
            myAccount.Withdraw(100);
            Console.WriteLine(myAccount.Balance); // Outputs: 600
            // myAccount.balance = -1000;  // This would be an error, as the balance field is private and inaccessible directly.


            CoffeeMachine myMachine = new CoffeeMachine(1000, 100);  // Initialize with 1000 ml of water and 100 grams of beans
            myMachine.MakeEspresso();  // Outputs: Heating water... Grinding coffee beans... Making Espresso...
            Console.WriteLine($"Beans left: {myMachine.BeansLeft()} grams");  // Outputs: Beans left: 80 grams


            Car myCar = new Car();
            myCar.Drive();  // Outputs: Current speed: 8.4 m/s
            myCar.Drive();  // Outputs: Current speed: 16.8 m/s


            DigitalWallet myWallet = new DigitalWallet("securePass123");
            myWallet.Deposit(200m);
            bool isWithdrawn = myWallet.Withdraw(50m, "securePass123"); // Outputs: true
            decimal currentBalance = myWallet.CheckBalance("securePass123"); // Outputs: 150


            Role adminRole = new Role("Admin", new List<PermissionType> { PermissionType.Read, PermissionType.Write, PermissionType.Delete });
            Role userRole = new Role("User", new List<PermissionType> { PermissionType.Read, PermissionType.Write });
            User alice = new User("Alice", adminRole);
            User bob = new User("Bob", userRole);
            SystemManager manager = new SystemManager();
            manager.AccessResource(alice, PermissionType.Delete); // Outputs: Alice has Delete permission and can access the resource.
            manager.AccessResource(bob, PermissionType.Delete); // Outputs: Bob does not have Delete permission and cannot access the resource.


            LibraryBook book = new LibraryBook("Moby Dick", "1234567890");
            book.CheckOut(); // Outputs: Successfully checked out Moby Dick.
            book.CheckOut(); // Outputs: Moby Dick is already checked out.
            book.ReturnBook(); // Outputs: Successfully returned Moby Dick.


            Console.Read();
        }
    }
}
