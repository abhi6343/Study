namespace ForegroundBackgroundThread
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    // A thread created here to run Method1 Parallely
        //    Thread thread1 = new Thread(Method1)
        //    {
        //        //Thread becomes background thread
        //        IsBackground = true
        //    };
        //    Console.WriteLine($"Thread1 is a Background thread:  {thread1.IsBackground}");
        //    thread1.Start();
        //    //The control will come here and will exit 
        //    //the main thread or main application
        //    Console.WriteLine("Main Thread Exited");
        //}
        //// Static method
        //static void Method1()
        //{
        //    Console.WriteLine("Method1 Started");
        //    for (int i = 0; i <= 5; i++)
        //    {
        //        Console.WriteLine("Method1 is in Progress!!");
        //        Thread.Sleep(1000);
        //    }
        //    Console.WriteLine("Method1 Exited");
        //    Console.WriteLine("Press any key to Exit.");
        //    Console.ReadKey();
        //}

        #region Multiple foreground and one background thrad
        //static void Main(string[] args)
        //{
        //    // A thread created here to run Method1 Parallely
        //    Thread thread1 = new Thread(Method1)
        //    {
        //    };
        //    Console.WriteLine($"Thread1 is a Background thread:  {thread1.IsBackground}");
        //    thread1.Start();
        //    //The control will come here and will exit 
        //    //the main thread or main application
        //    Console.WriteLine("Main Thread Exited");
        //    //As the Main thread (i.e. foreground thread exits the application)
        //    //Automatically, the background thread quits the application
        //}
        //// Static method
        //static void Method1()
        //{
        //    Console.WriteLine("Method1 Started");
        //    Thread thread2 = new Thread(Method2)
        //    {
        //        IsBackground = true
        //    };
        //    thread2.Start();
        //    Thread.Sleep(3000);
        //    Console.WriteLine("Method1 Exited");
        //}
        //// Static method
        //static void Method2()
        //{
        //    Console.WriteLine("Method2 Started");
        //    for (int i = 0; i <= 10; i++)
        //    {
        //        Console.WriteLine("Method2 is in Progress!!");
        //        Thread.Sleep(1000);
        //    }
        //    Console.WriteLine("Method2 Exited");
        //    Console.WriteLine("Press any key to Exit.");
        //    Console.ReadKey();
        //}
        #endregion
        static void Main(string[] args)
        {
            ThreadingTest foregroundTest = new ThreadingTest(5);
            //Creating a Coreground Thread
            Thread foregroundThread = new Thread(new ThreadStart(foregroundTest.RunLoop));
            ThreadingTest backgroundTest = new ThreadingTest(50);
            //Creating a Background Thread
            Thread backgroundThread = new Thread(new ThreadStart(backgroundTest.RunLoop))
            {
                IsBackground = true
            };
            foregroundThread.Start();
            backgroundThread.Start();
        }
    }
}
