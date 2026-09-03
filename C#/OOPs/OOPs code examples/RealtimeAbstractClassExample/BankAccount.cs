namespace RealtimeAbstractClassExample
{
    //BankAccount.cs (Abstract Class)
    internal abstract class BankAccount
    {
        public string AccountNumber { get; private set; }
        public string AccountHolder { get; private set; }
        protected double Balance { get; set; }
        public BankAccount(string accountNumber, string accountHolder)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
        }
        // Abstract methods
        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
        // Virtual method with a default implementation
        public virtual void DisplayBalance()
        {
            Console.WriteLine($"Account Number: {AccountNumber}, Account Holder: {AccountHolder}, Balance: ${Balance}");
        }
    }
}
