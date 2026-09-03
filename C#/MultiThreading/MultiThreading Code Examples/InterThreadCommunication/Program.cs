namespace InterThreadCommunication
{
    internal class Program
    {
        //#region Print even & odd numbers
        ////Limit numbers will be printed on the Console
        //const int numberLimit = 10;
        //static readonly object _lockObject = new object();
        //static void Main(string[] args)
        //{
        //    Thread EvenThread = new Thread(PrintEvenNumbers);
        //    Thread OddThread = new Thread(PrintOddNumbers);
        //    //First Start the Even thread.
        //    EvenThread.Start();
        //    //Pause for 10 ms, to make sure Even thread has started 
        //    //or else Odd thread may start first resulting different sequence.
        //    Thread.Sleep(100);
        //    //Next, Start the Odd thread.
        //    OddThread.Start();
        //    //Wait for all the childs threads to complete
        //    OddThread.Join();
        //    EvenThread.Join();
        //    Console.ReadKey();
        //}
        ////Printing of Even Numbers Function
        //static void PrintEvenNumbers()
        //{
        //    try
        //    {
        //        //Implement lock as the Console is shared between two threads
        //        Monitor.Enter(_lockObject);
        //        for (int i = 0; i <= numberLimit; i = i + 2)
        //        {
        //            //Printing Even Number on Console)
        //            Console.Write($"{i} ");
        //            //Notify Odd thread that I'm done, you do your job
        //            Monitor.Pulse(_lockObject);
        //            //I will wait here till Odd thread notify me 
        //            // Monitor.Wait(monitor);
        //            //Without this logic application will wait forever
        //            bool isLast = false;
        //            if (i == numberLimit)
        //            {
        //                isLast = true;
        //            }
        //            if (!isLast)
        //            {
        //                //I will wait here till Odd thread notify me
        //                Monitor.Wait(_lockObject);
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        //Release the lock
        //        Monitor.Exit(_lockObject);
        //    }
        //}
        ////Printing of Odd Numbers Function
        //static void PrintOddNumbers()
        //{
        //    try
        //    {
        //        //Hold lock as the Console is shared between two threads
        //        Monitor.Enter(_lockObject);
        //        for (int i = 1; i <= numberLimit; i = i + 2)
        //        {
        //            //Printing the odd numbers on the console
        //            Console.Write($"{i} ");
        //            //Notify Even thread that I'm done, you do your job
        //            Monitor.Pulse(_lockObject);
        //            //I will wait here till even thread notify me
        //            // Monitor.Wait(monitor);
        //            // without this logic application will wait forever
        //            bool isLast = false;
        //            if (i == numberLimit - 1)
        //            {
        //                isLast = true;
        //            }
        //            if (!isLast)
        //            {
        //                //I will wait here till Even thread notify me
        //                Monitor.Wait(_lockObject);
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        //Release lock
        //        Monitor.Exit(_lockObject);
        //    }
        //}
        //#endregion

        //#region Print table of 4 & 5 without Wait() & Pulse()
        //static readonly object _lockObject = new object();
        //static void Main(string[] args)
        //{
        //    //Creating an object of Thread class to Execute the PrintTable method
        //    Thread thread = new Thread(PrintTable)
        //    {
        //        Name = "Manual Thread"
        //    };
        //    thread.Start();
        //    //Locking the _lockObject
        //    lock (_lockObject)
        //    {
        //        Thread th = Thread.CurrentThread;
        //        th.Name = "Main Thread";
        //        Console.WriteLine($"{th.Name} Running and Printing the Table of 5");
        //        for (int i = 1; i <= 10; i++)
        //        {
        //            Console.WriteLine("5 x " + i + " = " + (5 * i));
        //        }
        //    } //synchronized block ends
        //    Console.ReadKey();
        //}

        //public static void PrintTable()
        //{
        //    //Synchronizing or locking the _lockObject 
        //    //Doing so, restricts any other thread to access a block of code using this _lockObject at the same time.
        //    lock (_lockObject)
        //    {
        //        Console.WriteLine($"{Thread.CurrentThread.Name} Running and Printing the Table of 4");
        //        for (int i = 1; i <= 10; i++)
        //        {
        //            Console.WriteLine("4 x " + i + " = " + (4 * i));
        //        }
        //    }
        //}
        //#endregion

        # region Print table of 4 & 5 with Wait() & Pulse()
        static readonly object _lockObject = new object();
        static void Main(string[] args)
        {
            //Creating an object ofThread class to Execute the PrintTable method
            Thread thread = new Thread(PrintTable)
            {
                Name = "Manual Thread"
            };
            thread.Start();
            //Locking the _lockObject
            lock (_lockObject)
            {
                //Calling the Wait() method in a synchronized context
                //Doing so, makes the Main Thread stops its execution and wait
                //until it is notified by the Pulse() method
                //on the same object _lockObject
                Monitor.Wait(_lockObject);
                Thread th = Thread.CurrentThread;
                th.Name = "Main Thread";
                Console.WriteLine($"{th.Name} Running and Printing the Table of 5");
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine("5 x " + i + " = " + (5 * i));
                }
            } //synchronized block ends
            Console.ReadKey();
        }
        //The entry-point method of the thread
        public static void PrintTable()
        {
            //Synchronizing or locking the _lockObject 
            //Doing so, restricts any other thread to access a block of code using this _lockObject at the same time.
            lock (_lockObject)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} Running and Printing the Table of 4");
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine("4 x " + i + " = " + (4 * i));
                }
                //The manually created thread is calling the Pulse() method
                //To notifying the Main thread that it is releasing the lock over the _lockObject
                //And Main Thread could lock the object to continue its work     
                Monitor.Pulse(_lockObject);
            } //synchronized block ends
        }
        #endregion
    }
}
