namespace Semaphore
{
    internal class Program
    {
        //public static System.Threading.Semaphore semaphore = null;
        //static void Main(string[] args)
        //{
        //    try
        //    {
        //        //Try to Open the Semaphore if Exists, if not throw an exception
        //        semaphore = System.Threading.Semaphore.OpenExisting("Semaphore");
        //    }
        //    catch (WaitHandleCannotBeOpenedException)   //No handle of the given name exists.
        //    {
        //        //If Semaphore not Exists, create a semaphore instance
        //        //Here Maximum 2 external threads can access the code at the same time
        //        semaphore = new System.Threading.Semaphore(2, 2, "Semaphore");
        //    }
        //    Console.WriteLine("External Thread Trying to Acquire");
        //    semaphore.WaitOne();
        //    //This section can be accessed by maximum two external threads: Start
        //    Console.WriteLine("External Thread Acquired");
        //    Console.ReadKey();
        //    //This section can be accessed by maximum two external threads: End
        //    semaphore.Release();
        //}

        //public static System.Threading.Semaphore semaphore = new(2, 3);
        //static void Main(string[] args)
        //{
        //    for (int i = 1; i <= 10; i++)
        //    {
        //        var threadObject = new Thread(DoSomeTask)
        //        {
        //            Name = "Thread " + i
        //        };
        //        threadObject.Start();
        //    }
        //    Console.ReadKey();
        //}
        //static void DoSomeTask()
        //{
        //    Console.WriteLine(Thread.CurrentThread.Name + " Wants to Enter into Critical Section for processing");
        //    try
        //    {
        //        //Blocks the current thread until the current WaitHandle receives a signal.   
        //        semaphore.WaitOne();
        //        //Decrease the Initial Count Variable by 1
        //        Console.WriteLine("Success: " + Thread.CurrentThread.Name + " is Doing its work");
        //        Thread.Sleep(5000);
        //        Console.WriteLine(Thread.CurrentThread.Name + " Exit.");
        //    }
        //    finally
        //    {
        //        //Release() method to release semaphore  
        //        //Increase the Initial Count Variable by 1
        //        semaphore.Release();
        //    }
        //}

        // A semaphore that simulates a limited resource pool.
        //
        private static System.Threading.Semaphore _pool;

        // A padding interval to make the output more orderly.
        private static int _padding;

        public static void Main()
        {
            // Create a semaphore that can satisfy up to three
            // concurrent requests. Use an initial count of zero,
            // so that the entire semaphore count is initially
            // owned by the main program thread.
            
            //_pool = new System.Threading.Semaphore(initialCount: 0, maximumCount: 3);

            //// Create and start five numbered threads.            
            //for (int i = 1; i <= 5; i++)
            //{
            //    var t = new Thread(new ParameterizedThreadStart(Worker));

            //    // Start the thread, passing the number.                
            //    t.Start(i);
            //}

            //// Wait for half a second, to allow all the
            //// threads to start and to block on the semaphore.
            
            //Thread.Sleep(500);

            //// The main thread starts out holding the entire
            //// semaphore count. Calling Release(3) brings the 
            //// semaphore count back to its maximum value, and
            //// allows the waiting threads to enter the semaphore,
            //// up to three at a time.
            
            //Console.WriteLine("Main thread calls Release(3).");
            //_pool.Release(releaseCount: 3);

            //Console.WriteLine("Main thread exits.");

            //_pool.WaitOne();   // Thread A acquires

            //new Thread(() =>
            //{
            //    Console.WriteLine("Thread B releasing semaphore");
            //    _pool.Release();   // different thread releases
            //}).Start();
        }

        private static void Worker(object num)
        {
            // Each worker thread begins by requesting the semaphore.
            Console.WriteLine("Thread {0} begins " + "and waits for the semaphore.", num);
            _pool.WaitOne();

            // A padding interval to make the output more orderly.
            var padding = Interlocked.Add(ref _padding, 100);

            Console.WriteLine("Thread {0} enters the semaphore.", num);

            // The thread's "work" consists of sleeping for 
            // about a second. Each thread "works" a little 
            // longer, just to make the output more orderly.            
            Thread.Sleep(1000 + padding);

            Console.WriteLine("Thread {0} releases the semaphore.", num);
            Console.WriteLine("Thread {0} previous semaphore count: {1}", num, _pool.Release());
        }
    }
}
