namespace ATM.Entities
{
    internal class Account(string accountNumber, double balance)
    {
        readonly Lock accountLock = new();
        public string AccountNumber => accountNumber;
        public double Balance => balance;
        public Dictionary<string, Card> Cards { get; } = [];

        public void Deposit(double amount)
        {
            lock (accountLock)
            {
                balance += amount;
            }
        }

        public bool Withdraw(double amount)
        {
            lock (accountLock)
            {
                if (balance >= amount)
                {
                    balance -= amount;
                    return true;
                }
                return false;
            }
        }
    }
}
