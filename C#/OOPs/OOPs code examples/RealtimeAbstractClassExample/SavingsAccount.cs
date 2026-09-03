namespace RealtimeAbstractClassExample
{
    //SavingsAccount.cs (Concrete Class)
    internal class SavingsAccount : BankAccount
    {
        private double _interestRate = 0.03; // 3% annual interest
        public SavingsAccount(string accountNumber, string accountHolder)
            : base(accountNumber, accountHolder) { }
        public override void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited ${amount} into Savings Account.");
        }
        public override void Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew ${amount} from Savings Account.");
            }
            else
            {
                Console.WriteLine("Insufficient funds for withdrawal.");
            }
        }
        public void AddInterest()
        {
            Balance += Balance * _interestRate;
            Console.WriteLine($"Interest added. New Balance: ${Balance}");
        }
    }
}
