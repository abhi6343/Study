namespace InterfaceRealtimeExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Saving Account:");
            IBankAccount savingAccount = new SavingAccount();
            savingAccount.DepositAmount(2000);
            savingAccount.DepositAmount(1000);
            savingAccount.WithdrawAmount(1500);
            savingAccount.WithdrawAmount(5000);
            Console.WriteLine($"Saving Account Balanace: { savingAccount.CheckBalance()}");

            Console.WriteLine("\nCurrent Account:");
            IBankAccount currentAccount = new CurrentAccount();
            currentAccount.DepositAmount(500);
            currentAccount.DepositAmount(1500);
            currentAccount.WithdrawAmount(2600);
            currentAccount.WithdrawAmount(1000);
            Console.WriteLine($"Current Account Balanace: { currentAccount.CheckBalance()}");

            
            Console.ReadLine();
        }
    }
}
