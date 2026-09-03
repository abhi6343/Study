namespace Mutex
{
    internal class Program
    {
        private static System.Threading.Mutex mutex = new();
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Application Is Running.......");
            //using (System.Threading.Mutex mutex = new System.Threading.Mutex(false, "Mutex"))
            //{
            //    //Checking if Other External Thread is Running
            //    if (!mutex.WaitOne(5000, false))
            //    {
            //        Console.WriteLine("An Instance of the Application is Already Running");
            //        Console.ReadKey();
            //        return;
            //    }
            //    Console.WriteLine("Application Is Running.......");
            //    Console.ReadKey();
            //}

            //        //Create multiple threads to understand Mutex
            //        for (int i = 1; i <= 5; i++)
            //        {
            //            Thread threadObject = new Thread(MutexDemo)
            //            {
            //                Name = "Thread " + i
            //            };
            //            threadObject.Start();
            //        }
            //        Console.ReadKey();

            //Console.WriteLine("Thread trying first WaitOne...");
            //mutex.WaitOne();   // 1st acquisition
            //Console.WriteLine("Mutex acquired first time");

            //Console.WriteLine("Thread trying second WaitOne...");
            //mutex.WaitOne();   // 2nd acquisition (same thread, no blocking)
            //Console.WriteLine("Mutex acquired second time");

            //Console.WriteLine("Releasing once...");
            //mutex.ReleaseMutex(); // release count 1

            //Console.WriteLine("Releasing twice...");
            //mutex.ReleaseMutex(); // release count 2

            //Console.WriteLine("Mutex fully released");

            //MethodA();

            //    var t1 = new Thread(Thread1Work);
            //    var t2 = new Thread(Thread2Work);

            //    t1.Start();
            //    Thread.Sleep(500);   // ensure t1 acquires mutex first
            //    t2.Start();

            //    t1.Join();
            //    t2.Join();

            //Mutex m1 = new Mutex(false, "MyMutex");
            //Mutex m2 = new Mutex(false, "MyMutex");

            //Console.WriteLine("Two Mutex objects created");

            //m1.WaitOne();
            //Console.WriteLine("m1 acquired mutex");

            //// m2.WaitOne() would block here because m1 owns it

            //m1.ReleaseMutex();
            //Console.WriteLine("m1 released mutex");
            //}
            //static void MethodA()
            //{
            //    mutex.WaitOne();
            //    MethodB();   // MethodB can also acquire the same mutex
            //    mutex.ReleaseMutex();
            //}
            //static void MethodB()
            //{
            //    mutex.WaitOne();   // does NOT deadlock
            //    mutex.ReleaseMutex();

            //var m = new System.Threading.Mutex(true, @"Global\MyMutex");

            //Console.WriteLine("Main thread owns the mutex");

            //// do work

            //m.ReleaseMutex();
            //Console.WriteLine("Mutex released");
            var m = new System.Threading.Mutex();

            m.WaitOne();   // Thread A acquires

            await Task.Run(() =>
            {
                m.ReleaseMutex();   // ❌ exception
            });
        }

        static void Thread1Work()
        {
            Console.WriteLine("T1: WaitOne #1");
            mutex.WaitOne();

            Console.WriteLine("T1: WaitOne #2");
            mutex.WaitOne();   // recursion allowed

            Console.WriteLine("T1: Holding mutex twice (3 sec)");
            Thread.Sleep(3000);

            Console.WriteLine("T1: ReleaseMutex #1");
            mutex.ReleaseMutex();   // still owned

            Console.WriteLine("T1: Sleeping 3 sec (mutex still owned)");
            Thread.Sleep(3000);

            Console.WriteLine("T1: ReleaseMutex #2");
            mutex.ReleaseMutex();   // now fully released
        }

        static void Thread2Work()
        {
            Console.WriteLine("T2: Waiting for mutex...");
            mutex.WaitOne();   // blocks until recursion count becomes 0

            Console.WriteLine("T2: Acquired mutex!");
            mutex.ReleaseMutex();
        }
        //Method to implement syncronization using Mutex
        //static void MutexDemo()
        //{
        //    Console.WriteLine(Thread.CurrentThread.Name + " Wants to Enter Critical Section for processing");
        //    if (mutex.WaitOne(1000))
        //    {
        //        try
        //        {
        //            //Blocks the current thread until the current WaitOne method receives a signal.
        //            //Wait until it is safe to enter.
        //            //mutex.WaitOne();
        //            Console.WriteLine("Success: " + Thread.CurrentThread.Name + " is Processing now");
        //            Thread.Sleep(2000);
        //            Console.WriteLine("Exit: " + Thread.CurrentThread.Name + " is completed its task");
        //        }
        //        finally
        //        {
        //            //Call the ReleaseMutex method to unblock so that other threads
        //            //that are trying to gain ownership of the mutex can enter
        //            mutex.ReleaseMutex();
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(Thread.CurrentThread.Name + " will not acquire the mutex");
        //    }
        //}
        //~Program()
        //{
        //    mutex.Dispose();
        //}

        //static System.Threading.Mutex _mutex;
        //static void Main()
        //{
        //    //If IsSingleInstance returns true continue with the Program else Exit the Program
        //    if (!IsSingleInstance())
        //    {
        //        Console.WriteLine("More than one instance"); // Exit program.
        //    }
        //    else
        //    {
        //        Console.WriteLine("One instance"); // Continue with program.
        //    }
        //    //Stay Open.
        //    Console.ReadLine();
        //}
        //static bool IsSingleInstance()
        //{
        //    try
        //    {
        //        //Try to open Existing Mutex.
        //        //If MyMutex is not opened, then it will throw an exception
        //        System.Threading.Mutex.OpenExisting("MyMutex");
        //    }
        //    catch (WaitHandleCannotBeOpenedException)
        //    {
        //        // If exception occurred, there is no such mutex.
        //        _mutex = new System.Threading.Mutex(true, "MyMutex");
        //        // Only one instance.
        //        return true;
        //    }
        //    // More than one instance.
        //    return false;
        //}
    }
}
