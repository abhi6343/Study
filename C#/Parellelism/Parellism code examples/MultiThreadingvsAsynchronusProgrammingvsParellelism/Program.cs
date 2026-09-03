namespace MultiThreadingvsAsynchronusProgrammingvsParellelism
{
    internal class Program
    {
        //#region MultiThreading
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Main Thread Started");
        //    //Creating Threads
        //    Thread t1 = new Thread(Method1)
        //    {
        //        Name = "Thread1"
        //    };
        //    Thread t2 = new Thread(Method2)
        //    {
        //        Name = "Thread2"
        //    };
        //    Thread t3 = new Thread(Method3)
        //    {
        //        Name = "Thread3"
        //    };
        //    //Executing the methods
        //    t1.Start();
        //    t2.Start();
        //    t3.Start();
        //    Console.WriteLine("Main Thread Ended");
        //    Console.Read();
        //}
        //static void Method1()
        //{
        //    Console.WriteLine("Method1 Started using " + Thread.CurrentThread.Name);
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        Console.WriteLine("Method1 :" + i);
        //    }
        //    Console.WriteLine("Method1 Ended using " + Thread.CurrentThread.Name);
        //}
        //static void Method2()
        //{
        //    Console.WriteLine("Method2 Started using " + Thread.CurrentThread.Name);
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        Console.WriteLine("Method2 :" + i);
        //        if (i == 3)
        //        {
        //            Console.WriteLine("Performing the Database Operation Started");
        //            //Sleep for 10 seconds
        //            Thread.Sleep(10000);
        //            Console.WriteLine("Performing the Database Operation Completed");
        //        }
        //    }
        //    Console.WriteLine("Method2 Ended using " + Thread.CurrentThread.Name);
        //}
        //static void Method3()
        //{
        //    Console.WriteLine("Method3 Started using " + Thread.CurrentThread.Name);
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        Console.WriteLine("Method3 :" + i);
        //    }
        //    Console.WriteLine("Method3 Ended using " + Thread.CurrentThread.Name);
        //}
        //#endregion


        //#region Asynchronous Programming
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Main Method Started......");
        //    var task = SomeMethod();
        //    Console.WriteLine("Main Method End");
        //    string Result = task.Result;
        //    Console.WriteLine($"Result : {Result}");
        //    Console.WriteLine("Program End");
        //    Console.ReadKey();
        //}
        //public async static Task<string> SomeMethod()
        //{
        //    Console.WriteLine("Some Method Started......");
        //    await Task.Delay(TimeSpan.FromSeconds(2));
        //    Console.WriteLine("\n");
        //    Console.WriteLine("Some Method End");
        //    return "Some Data";
        //}
        //#endregion


        #region Parellel
        static void Main()
        {
            List<int> integerList = Enumerable.Range(1, 10).ToList();
            Console.WriteLine("Parallel For Loop Started");
            Parallel.For(1, 11, number => {
                Console.WriteLine(number);
            });
            Console.WriteLine("Parallel For Loop Ended");
            Console.WriteLine("Parallel Foreach Loop Started");
            Parallel.ForEach(integerList, i =>
            {
                long total = DoSomeIndependentTimeconsumingTask();
                Console.WriteLine("{0} - {1}", i, total);
            });
            Console.WriteLine("Parallel Foreach Loop Ended");
            //Calling Three methods Parallely
            Console.WriteLine("Parallel Invoke Started");
            Parallel.Invoke(
            Method1, Method2, Method3
            );
            Console.WriteLine("Parallel Invoke Ended");
            Console.ReadLine();
        }
        static long DoSomeIndependentTimeconsumingTask()
        {
            //Do Some Time Consuming Task here
            long total = 0;
            for (int i = 1; i < 100000000; i++)
            {
                total += i;
            }
            return total;
        }
        static void Method1()
        {
            Thread.Sleep(200);
            Console.WriteLine($"Method 1 Completed by Thread = {Thread.CurrentThread.ManagedThreadId}");
        }
        static void Method2()
        {
            Thread.Sleep(200);
            Console.WriteLine($"Method 2 Completed by Thread = {Thread.CurrentThread.ManagedThreadId}");
        }
        static void Method3()
        {
            Thread.Sleep(200);
            Console.WriteLine($"Method 3 Completed by Thread = {Thread.CurrentThread.ManagedThreadId}");
        }
        #endregion
    }
}
