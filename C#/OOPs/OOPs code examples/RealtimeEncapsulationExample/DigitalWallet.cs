namespace RealtimeEncapsulationExample
{
    internal class DigitalWallet
    {
        private decimal balance;
        private string walletPassword;
        private List<string> transactionLog = new List<string>();
        public DigitalWallet(string initialPassword)
        {
            balance = 0m;
            walletPassword = initialPassword;
        }
        private void LogTransaction(string transactionDetail)
        {
            // This can be more complex, involving timestamps and other details.
            transactionLog.Add(transactionDetail);
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount should be positive.");
            }
            balance += amount;
            LogTransaction($"Deposited {amount}. Current Balance: {balance}");
        }
        public bool Withdraw(decimal amount, string password)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount should be positive.");
            }
            if (walletPassword != password)
            {
                LogTransaction($"Failed withdrawal attempt of {amount}. Incorrect password.");
                return false;
            }
            if (balance - amount < 0)
            {
                LogTransaction($"Failed withdrawal attempt of {amount}. Insufficient funds.");
                return false;
            }
            balance -= amount;
            LogTransaction($"Withdrew {amount}. Current Balance: {balance}");
            return true;
        }
        public decimal CheckBalance(string password)
        {
            if (walletPassword == password)
            {
                return balance;
            }
            else
            {
                throw new UnauthorizedAccessException("Incorrect password.");
            }
        }
        // This can be used for auditing purposes.
        public List<string> GetTransactionLog(string password)
        {
            if (walletPassword == password)
            {
                return new List<string>(transactionLog);  // Return a copy to maintain encapsulation.
            }
            else
            {
                throw new UnauthorizedAccessException("Incorrect password.");
            }
        }
    }
}
