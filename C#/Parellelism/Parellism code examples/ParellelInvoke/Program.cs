using System.Diagnostics;

namespace ParellelInvoke
{
    internal class Program
    {
        //#region Sequential calls
        //static void Main()
        //{
        //    Stopwatch stopWatch = new Stopwatch();
        //    stopWatch.Start();
        //    //Calling Three methods sequentially
        //    Method1();
        //    Method2();
        //    Method3();
        //    stopWatch.Stop();
        //    Console.WriteLine($"Sequential Execution Took {stopWatch.ElapsedMilliseconds} Milliseconds");
        //    Console.ReadKey();
        //}
        //static void Method1()
        //{
        //    Thread.Sleep(200);
        //    Console.WriteLine($"Method 1 Completed by Thread = {Thread.CurrentThread.ManagedThreadId}");
        //}
        //static void Method2()
        //{
        //    Thread.Sleep(200);
        //    Console.WriteLine($"Method 2 Completed by Thread = {Thread.CurrentThread.ManagedThreadId}");
        //}
        //static void Method3()
        //{
        //    Thread.Sleep(200);
        //    Console.WriteLine($"Method 3 Completed by Thread = {Thread.CurrentThread.ManagedThreadId}");
        //}
        //#endregion


        #region ParellelInvoke
        //static void Main()
        //{
        //    Stopwatch stopWatch = new Stopwatch();
        //    stopWatch.Start();
        //    //Calling Three methods Parallely
        //    Parallel.Invoke(
        //    Method1, Method2, Method3
        //    );
        //    stopWatch.Stop(); 
        //    Console.WriteLine($"Parallel Execution Took {stopWatch.ElapsedMilliseconds} Milliseconds");
        //    Console.ReadKey();
        //}
        //static void Method1()
        //{
        //    Thread.Sleep(200);
        //    Console.WriteLine($"Method 1 Completed by Thread = {Thread.CurrentThread.ManagedThreadId}");
        //}
        //static void Method2()
        //{
        //    Thread.Sleep(200);
        //    Console.WriteLine($"Method 2 Completed by Thread = {Thread.CurrentThread.ManagedThreadId}");
        //}
        //static void Method3()
        //{
        //    Thread.Sleep(200);
        //    Console.WriteLine($"Method 3 Completed by Thread = {Thread.CurrentThread.ManagedThreadId}");
        //}
        #endregion


        //#region ParellelInvoke with anonymous and lambda expression
        //static void Main()
        //{
        //    Parallel.Invoke(
        //    NormalAction, // Invoking Normal Method
        //    delegate () // Invoking an inline delegate
        //    {
        //        Console.WriteLine($"Method 2, Thread = {Thread.CurrentThread.ManagedThreadId}");
        //    },
        //    () => // Invoking a lambda expression
        //    {
        //        Console.WriteLine($"Method 3, Thread = {Thread.CurrentThread.ManagedThreadId}");
        //    }
        //    );
        //    Console.WriteLine("Press any key to exit.");
        //    Console.ReadKey();
        //}
        //static void NormalAction()
        //{
        //    Console.WriteLine($"Method 1, Thread = {Thread.CurrentThread.ManagedThreadId}");
        //}
        //#endregion


        //#region Without ParellelOptions
        //static void Main()
        //{
        //    Parallel.Invoke(
        //    () => DoSomeTask(1),
        //    () => DoSomeTask(2),
        //    () => DoSomeTask(3),
        //    () => DoSomeTask(4),
        //    () => DoSomeTask(5),
        //    () => DoSomeTask(6),
        //    () => DoSomeTask(7)
        //    );
        //    Console.ReadKey();
        //}
        //static void DoSomeTask(int number)
        //{
        //    Console.WriteLine($"DoSomeTask {number} started by Thread {Thread.CurrentThread.ManagedThreadId}");
        //    //Sleep for 5000 milliseconds
        //    Thread.Sleep(5000);
        //    Console.WriteLine($"DoSomeTask {number} completed by Thread {Thread.CurrentThread.ManagedThreadId}");
        //}
        //#endregion


        //#region ParellelOptions
        //static void Main()
        //{
        //    //Allowing three task to execute at a time
        //    ParallelOptions parallelOptions = new ParallelOptions
        //    {
        //        MaxDegreeOfParallelism = 3
        //    };

        //    //parallelOptions.MaxDegreeOfParallelism = System.Environment.ProcessorCount - 1;

        //    //Passing ParallelOptions as the first parameter
        //    Parallel.Invoke(
        //    parallelOptions,
        //    () => DoSomeTask(1),
        //    () => DoSomeTask(2),
        //    () => DoSomeTask(3),
        //    () => DoSomeTask(4),
        //    () => DoSomeTask(5),
        //    () => DoSomeTask(6),
        //    () => DoSomeTask(7)
        //    );
        //    Console.ReadKey();
        //}
        //static void DoSomeTask(int number)
        //{
        //    Console.WriteLine($"DoSomeTask {number} started by Thread {Thread.CurrentThread.ManagedThreadId}");
        //    //Sleep for 500 milliseconds
        //    Thread.Sleep(5000);
        //    Console.WriteLine($"DoSomeTask {number} completed by Thread {Thread.CurrentThread.ManagedThreadId}");
        //}
        //#endregion


        #region ParellelInvoke with input and return value
        static void Main()
        {
            int intResult = 0;
            string strResult = string.Empty;
            //Calling Three methods Parallely
            Parallel.Invoke(
            () => intResult = Method1(),
            () => strResult = Method2("Pranaya"),
            () => Method3(100)
            );
            Console.WriteLine($"Method1 Result: {intResult}");
            Console.WriteLine($"Method2 Result: {strResult}");
            Console.WriteLine($"Parallel Execution Completed");
            Console.ReadKey();
        }
        static int Method1()
        {
            Task.Delay(200);
            Console.WriteLine($"Method 1 Completed by Thread = {Thread.CurrentThread.ManagedThreadId}");
            return 100;
        }
        static string Method2(string name)
        {
            Task.Delay(200);
            Console.WriteLine($"Method 2 Completed by Thread = {Thread.CurrentThread.ManagedThreadId}");
            return "Hello:" + name;
        }
        static void Method3(int number)
        {
            Task.Delay(200);
            Console.WriteLine($"Method 3 Completed by Thread = {Thread.CurrentThread.ManagedThreadId}");
        }
        #endregion
    }
}
