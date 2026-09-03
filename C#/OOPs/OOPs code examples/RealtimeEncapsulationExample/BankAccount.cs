namespace RealtimeEncapsulationExample
{
    internal class BankAccount
    {
        // This private field is encapsulated and can't be directly accessed from outside the class.
        private decimal balance;
        public decimal Balance
        {
            // Only provides a way to read the balance but not modify it directly.
            get { return balance; }
        }
        public BankAccount(decimal initialBalance)
        {
            if (initialBalance < 0)
            {
                throw new ArgumentException("Initial balance cannot be negative.");
            }
            balance = initialBalance;
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount should be positive.");
            }
            balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount should be positive.");
            }
            if (balance - amount < 0)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
            balance -= amount;
        }
    }
}
