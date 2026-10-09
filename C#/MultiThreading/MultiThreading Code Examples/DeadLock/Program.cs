namespace DeadLock
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("Main Thread Started");
            var Account1001 = new Account(1001, 5000);
            var Account1002 = new Account(1002, 3000);
            var accountManager1 = new AccountManager(Account1001, Account1002, 5000);
            var thread1 = new Thread(accountManager1.FundTransfer)
            {
                Name = "Thread1"
            };
            var accountManager2 = new AccountManager(Account1002, Account1001, 6000);
            var thread2 = new Thread(accountManager2.FundTransfer)
            {
                Name = "Thread2"
            };
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.WriteLine("Main Thread Completed");
            Console.ReadKey();
        }
    }
}
