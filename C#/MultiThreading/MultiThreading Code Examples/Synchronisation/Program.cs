namespace Synchronisation
{
    internal class Program
    {
        static readonly object lockObject = new object();
        static int Count = 0;
        static void Main(string[] args)
        {
            //BookMyShow bookMyShow = new BookMyShow();
            //Thread t1 = new Thread(bookMyShow.TicketBookig)
            //{
            //    Name = "Thread1"
            //};
            //Thread t2 = new Thread(bookMyShow.TicketBookig)
            //{
            //    Name = "Thread2"
            //};
            //Thread t3 = new Thread(bookMyShow.TicketBookig)
            //{
            //    Name = "Thread3"
            //};

            //var thread1 = new Thread(SomeMethod)
            //{
            //    Name = "Thread 1"
            //};
            //var thread2 = new Thread(SomeMethod)
            //{
            //    Name = "Thread 2"
            //};
            //var thread3 = new Thread(SomeMethod)
            //{
            //    Name = "Thread 3"
            //};

            //thread1.Start();
            //thread2.Start();
            //thread3.Start();

            var t1 = new Thread(IncrementCount);
            var t2 = new Thread(IncrementCount);
            var t3 = new Thread(IncrementCount);
            t1.Start();
            t2.Start();
            t3.Start();
            //Wait for all three threads to complete their execution
            t1.Join();
            t2.Join();
            t3.Join();
            Console.WriteLine(Count);
            Console.ReadKey();
        }
        private static readonly object LockCount = new object();
        static void IncrementCount()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                //Only protecting the shared Count variable.
                lock (LockCount)
                {
                    Count++;
                }
                //Interlocked.Increment(ref Count); //This is an alternative to lock statement
            }
        }
        public static void SomeMethod()
        {
            // Locking the Shared Resource for Thread Synchronization
            lock (lockObject)
            {
                Console.Write("[Welcome To The ");
                Thread.Sleep(1000);
                Console.WriteLine("World of Dotnet!]");
            }
        }
    }
}
