namespace Auto_ManualResetEvent
{
    internal class Program
    {
        ////static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        //static ManualResetEvent manualResetEvent = new ManualResetEvent(false);
        //static void Main(string[] args)
        //{
        //    var newThread = new Thread(SomeMethod)
        //    {
        //        Name = "NewThread"
        //    };
        //    newThread.Start(); //It will invoke the SomeMethod in a different thread
        //    //To See how the SomeMethod goes in halt mode
        //    //Once we enter any key it will call set method and the SomeMethod will Resume its work
        //    Console.ReadLine();
        //    //It will send a signal to other threads to resume their work
        //    //autoResetEvent.Set();
        //    manualResetEvent.Set();
        //}
        //static void SomeMethod()
        //{
        //    Console.WriteLine("Starting........");
        //    //Put the current thread into waiting state until it receives the signal
        //    //autoResetEvent.WaitOne(); //It will make the thread in halt mode
        //    manualResetEvent.WaitOne(); //It will make the thread in halt mode
        //    Console.WriteLine("Finishing........");
        //    Console.ReadLine(); //To see the output in the console
        //}

        //private static AutoResetEvent event_1 = new(true);
        //private static AutoResetEvent event_2 = new(false);

        //static void Main()
        //{
        //    Console.WriteLine("Press Enter to create three threads and start them.\r\n" +
        //                      "The threads wait on AutoResetEvent #1, which was created\r\n" +
        //                      "in the signaled state, so the first thread is released.\r\n" +
        //                      "This puts AutoResetEvent #1 into the unsignaled state.");
        //    Console.ReadLine();

        //    for (int i = 0; i < 3; i++)
        //    {
        //        var t = new Thread(ThreadProc)
        //        {
        //            Name = "Thread_" + i
        //        };
        //        t.Start();
        //    }
        //    Thread.Sleep(250);

        //    for (int i = 0; i < 2; i++)
        //    {
        //        Console.WriteLine("Press Enter to release another thread.");
        //        Console.ReadLine();
        //        event_1.Set();
        //        Thread.Sleep(250);
        //    }

        //    Console.WriteLine("\r\nAll threads are now waiting on AutoResetEvent #2.");
        //    for (int i = 0; i < 3; i++)
        //    {
        //        Console.WriteLine("Press Enter to release a thread.");
        //        Console.ReadLine();
        //        event_2.Set();
        //        Thread.Sleep(250);
        //    }

        //    // Visual Studio: Uncomment the following line.
        //    //Console.Readline();
        //}

        //static void ThreadProc()
        //{
        //    var name = Thread.CurrentThread.Name;

        //    Console.WriteLine("{0} waits on AutoResetEvent #1.", name);
        //    event_1.WaitOne();
        //    Console.WriteLine("{0} is released from AutoResetEvent #1.", name);

        //    Console.WriteLine("{0} waits on AutoResetEvent #2.", name);
        //    event_2.WaitOne();
        //    Console.WriteLine("{0} is released from AutoResetEvent #2.", name);

        //    Console.WriteLine("{0} ends.", name);
        //}

        //Initially not signaled.
        //const int numIterations = 100;
        //static readonly AutoResetEvent myResetEvent = new(false);
        //static int number;

        //static void Main()
        //{
        //    //Create and start the reader thread.
        //    var myReaderThread = new Thread(new ThreadStart(MyReadThreadProc))
        //    {
        //        Name = "ReaderThread"
        //    };
        //    myReaderThread.Start();

        //    for (int i = 1; i <= numIterations; i++)
        //    {
        //        Console.WriteLine("Writer thread writing value: {0}", i);
        //        number = i;

        //        //Signal that a value has been written.
        //        myResetEvent.Set();

        //        //Give the Reader thread an opportunity to act.
        //        Thread.Sleep(1000);
        //    }
        //}

        //static void MyReadThreadProc()
        //{
        //    while (true)
        //    {
        //        //The value will not be read until the writer has written
        //        // at least once since the last read.
        //        myResetEvent.WaitOne();
        //        Console.WriteLine("{0} reading value: {1}", Thread.CurrentThread.Name, number);
        //    }
        //}

        // mre is used to block and release threads manually. It is
        // created in the unsignaled state.
        private static readonly ManualResetEvent mre = new(false);

        static void Main()
        {
            Console.WriteLine("\nStart 3 named threads that block on a ManualResetEvent:\n");

            for (int i = 0; i <= 2; i++)
            {
                var t = new Thread(ThreadProc)
                {
                    Name = "Thread_" + i
                };
                t.Start();
            }

            Thread.Sleep(500);
            Console.WriteLine("\nWhen all three threads have started, press Enter to call Set()" +
                              "\nto release all the threads.\n");
            Console.ReadLine();

            mre.Set();

            Thread.Sleep(500);
            Console.WriteLine("\nWhen a ManualResetEvent is signaled, threads that call WaitOne()" +
                              "\ndo not block. Press Enter to show this.\n");
            Console.ReadLine();

            for (int i = 3; i <= 4; i++)
            {
                var t = new Thread(ThreadProc)
                {
                    Name = "Thread_" + i
                };
                t.Start();
            }

            Thread.Sleep(500);
            Console.WriteLine("\nPress Enter to call Reset(), so that threads once again block" +
                              "\nwhen they call WaitOne().\n");
            Console.ReadLine();

            mre.Reset();

            // Start a thread that waits on the ManualResetEvent.
            var t5 = new Thread(ThreadProc)
            {
                Name = "Thread_5"
            };
            t5.Start();

            Thread.Sleep(500);
            Console.WriteLine("\nPress Enter to call Set() and conclude the demo.");
            Console.ReadLine();

            mre.Set();

            // If you run this example in Visual Studio, uncomment the following line:
            //Console.ReadLine();
        }

        private static void ThreadProc()
        {
            var name = Thread.CurrentThread.Name;

            Console.WriteLine(name + " starts and calls mre.WaitOne()");

            mre.WaitOne();

            Console.WriteLine(name + " ends.");
        }

        #region Compare Manual & Auto ResetEvent
        //static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        //static ManualResetEvent manualResetEvent = new ManualResetEvent(false);
        //static void Main(string[] args)
        //{
        //    Thread newThread = new Thread(SomeMethod)
        //    {
        //        Name = "NewThread"
        //    };
        //    newThread.Start(); //It will invoke the SomeMethod in a different thread
        //    //To See how the SomeMethod goes in halt state let sleep the main thread for 3 secs
        //    Thread.Sleep(3000);
        //    //Console.WriteLine("Releasing the WaitOne 1 by Set 1");
        //    //autoResetEvent.Set(); //Set 1 will relase the Wait 1
        //    ////To See how the SomeMethod goes in halt state let sleep the main thread for 3 secs
        //    //Thread.Sleep(5000);
        //    //Console.WriteLine("Releasing the WaitOne 2 by Set 2");
        //    //autoResetEvent.Set(); //Set 2 will relase the Wait 2

        //    Console.WriteLine("Releasing the WaitOne 1 by Set 1");
        //    manualResetEvent.Set(); //Set will release all the WaitOne
        //    Console.ReadKey();
        //}
        //static void SomeMethod()
        //{
        //    Console.WriteLine("Starting 1........");
        //    //autoResetEvent.WaitOne(); //Wait 1
        //    manualResetEvent.WaitOne(); //Wait 1
        //    Console.WriteLine("Finishing 1........");
        //    Console.WriteLine();
        //    Console.WriteLine("Starting 2........");
        //    //autoResetEvent.WaitOne(); //Wait 2
        //    manualResetEvent.WaitOne(); //Wait 2
        //    Console.WriteLine("Finishing 2........");
        //}

        #endregion
    }
}
