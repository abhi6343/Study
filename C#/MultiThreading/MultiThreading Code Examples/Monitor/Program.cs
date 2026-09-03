namespace Monitor
{
    internal class Program
    {
        private static readonly object lockPrintNumbers = new object();
        //static void Main(string[] args)
        //{
        //    Thread[] Threads = new Thread[3];
        //    for (int i = 0; i < 3; i++)
        //    {
        //        Threads[i] = new Thread(PrintNumbers)
        //        {
        //            Name = "Child Thread " + i
        //        };
        //    }
        //    foreach (Thread t in Threads)
        //    {
        //        t.Start();
        //    }
        //    Console.ReadLine();
        //}
        
        //Upto the limit, numbers will be printed on the Console
        const int numberLimit = 20;
        static readonly object _lockMonitor = new object();
        static void Main()
        {
            Thread EvenThread = new Thread(PrintEvenNumbers);
            Thread OddThread = new Thread(PrintOddNumbers);
            //First Start the Even thread.
            EvenThread.Start();
            //Puase for 100 ms, to make sure Even thread has started
            //or else Odd thread may start first resulting different sequence.
            Thread.Sleep(100);
            //Next, Start the Odd thread.
            OddThread.Start();
            //Wait for all the childs threads to complete
            OddThread.Join();
            EvenThread.Join();
            Console.WriteLine("\nMain method completed");
            Console.ReadKey();
        }

        //Printing of Even Numbers Function
        static void PrintEvenNumbers()
        {
            try
            {
                //Implement lock as the Console is shared between two threads
                System.Threading.Monitor.Enter(_lockMonitor);
                for (int i = 0; i <= numberLimit; i = i + 2)
                {
                    //Printing Even Number on Console
                    Console.Write($"{i} ");
                    //Notify Odd thread that I'm done, you do your job
                    //It notifies a thread in the waiting queue of a change in the locked object's state.
                    System.Threading.Monitor.Pulse(_lockMonitor);
                    //I will wait here till Odd thread notify me
                    //System.Threading.Monitor.Wait(_lockMonitor);
                    //Without this logic application will wait forever
                    bool isLast = false;
                    if (i == numberLimit)
                    {
                        isLast = true;
                    }
                    if (!isLast)
                    {
                        //I will wait here till Odd thread notify me
                        //Releases the lock on an object and blocks the current thread
                        //until it reacquires the lock.
                        System.Threading.Monitor.Wait(_lockMonitor);
                    }
                }
            }
            finally
            {
                //Release the lock
                System.Threading.Monitor.Exit(_lockMonitor);
            }
        }
        
        //Printing of Odd Numbers Function
        static void PrintOddNumbers()
        {
            try
            {
                //Hold lock as the Console is shared between two threads
                System.Threading.Monitor.Enter(_lockMonitor);
                for (int i = 1; i <= numberLimit; i = i + 2)
                {
                    //Printing the odd numbers on the console
                    Console.Write($"{i} ");
                    //Notify Even thread that I'm done, you do your job
                    System.Threading.Monitor.Pulse(_lockMonitor);
                    // I will wait here till even thread notify me
                    // Monitor.Wait(monitor);
                    // without this logic application will wait forever
                    bool isLast = false;
                    if (i == numberLimit - 1)
                    {
                        isLast = true;
                    }
                    if (!isLast)
                    {
                        //I will wait here till Even thread notify me
                        System.Threading.Monitor.Wait(_lockMonitor);
                    }
                }
            }
            finally
            {
                //Release lock
                System.Threading.Monitor.Exit(_lockMonitor);
            }
        }
        public static void PrintNumbers()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " Trying to enter in critical section");
            TimeSpan timeout = TimeSpan.FromMilliseconds(1000);
            bool IsLockTaken = false;
            try
            {
                //System.Threading.Monitor.Enter(lockPrintNumbers);
                //System.Threading.Monitor.Enter(lockPrintNumbers, ref IsLockTaken);
                System.Threading.Monitor.TryEnter(lockPrintNumbers, timeout, ref IsLockTaken);
                if (IsLockTaken)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " Entered into the critical section");
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(100);
                        Console.Write(i + ",");
                    }
                    Console.WriteLine();
                }
                else
                {
                    // The lock was not acquired.
                    Console.WriteLine(Thread.CurrentThread.Name + " Lock was not acquired");
                }
            }
            finally
            {
                if (IsLockTaken)
                {
                    System.Threading.Monitor.Exit(lockPrintNumbers);
                    Console.WriteLine(Thread.CurrentThread.Name + " Exit from critical section");
                }
            }
        }
    }
}
