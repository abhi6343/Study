namespace InterfaceRealtimeExample
{
    internal class CurrentAccount : IBankAccount
    {
        private decimal Balance = 0;
        public bool DepositAmount(decimal Amount)
        {
            Balance = Balance + Amount;
            Console.WriteLine($"You have Deposited: {Amount}"); Console.WriteLine($"Your Account Balance: {Balance}");
            return true;
        }
        public bool WithdrawAmount(decimal Amount)
        {
            if (Balance < Amount)
            {
                Console.WriteLine("You have Insufficient balance!");
                return false;
            }
            else
            {
                Balance = Balance - Amount;
                Console.WriteLine($"You have Successfully Withdraw: {Amount}")
            Console.WriteLine($"Your Account Balance: {Balance}");
                return true;
            }
        }
        public decimal CheckBalance()
        {
            return Balance;
        }
    }
}
