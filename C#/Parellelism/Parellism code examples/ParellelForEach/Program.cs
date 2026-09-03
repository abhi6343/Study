using System.Diagnostics;

namespace ParellelForEach
{
    internal class Program
    {
        //#region Sequential foreach loop
        //static void Main()
        //{
        //    Stopwatch stopwatch = new Stopwatch();
        //    Console.WriteLine("Standard Foreach Loop Started");
        //    stopwatch.Start();
        //    List<int> integerList = Enumerable.Range(1, 10).ToList();
        //    foreach (int i in integerList)
        //    {
        //        long total = DoSomeIndependentTimeConsumingTask();
        //        Console.WriteLine("{0} - {1}", i, total);
        //    };
        //    Console.WriteLine("Standard Foreach Loop Ended");
        //    stopwatch.Stop();
        //    Console.WriteLine($"Time Taken by Standard Foreach Loop in Miliseconds { stopwatch.ElapsedMilliseconds}");
        //    Console.ReadLine();
        //}
        //static long DoSomeIndependentTimeConsumingTask()
        //{
        //    //Do Some Time Consuming Task here
        //    long total = 0;
        //    for (int i = 1; i < 100000000; i++)
        //    {
        //        total += i;
        //    }
        //    return total;
        //}
        //#endregion


        //#region Parellel ForEach
        //static void Main()
        //{
        //    Stopwatch stopwatch = new Stopwatch();
        //    Console.WriteLine("Parallel Foreach Loop Started");
        //    stopwatch.Start();
        //    List<int> integerList = Enumerable.Range(1, 10).ToList();
        //    Parallel.ForEach(integerList, i =>
        //    {
        //        long total = DoSomeIndependentTimeConsumingTask();
        //        Console.WriteLine("{0} - {1}", i, total);
        //    });
        //    Console.WriteLine("Parallel Foreach Loop Ended"); 
        //    stopwatch.Stop();
        //    Console.WriteLine($"Time Taken by Parallel Foreach Loop in Miliseconds { stopwatch.ElapsedMilliseconds}");
        //    Console.ReadLine();
        //}
        //static long DoSomeIndependentTimeConsumingTask()
        //{
        //    //Do Some Time Consuming Task here
        //    long total = 0;
        //    for (int i = 1; i < 100000000; i++)
        //    {
        //        total += i;
        //    }
        //    return total;
        //}
        //#endregion

        //#region Without DegreeOfParellelism
        //static void Main()
        //{
        //    List<int> integerList = Enumerable.Range(0, 10).ToList();
        //    Parallel.ForEach(integerList, i =>
        //    {
        //        Console.WriteLine(@"value of i = {0}, thread = {1}", i, Thread.CurrentThread.ManagedThreadId);
        //    });
        //    Console.ReadLine();
        //}
        //#endregion


        //#region DegreeOfParellelism
        //static void Main()
        //{
        //    List<int> integerList = Enumerable.Range(0, 10).ToList();
        //    var options = new ParallelOptions() { MaxDegreeOfParallelism = 2 };
        //    Parallel.ForEach(integerList, options, i =>
        //    {
        //        Console.WriteLine(@"value of i = {0}, thread = {1}", i,  Thread.CurrentThread.ManagedThreadId);
        //    });
        //    Console.ReadLine(); 
        //}
        //#endregion


        #region When not to use parellelism
        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Standard Foreach Loop Started");
            stopwatch.Start();
            List<int> integerList = Enumerable.Range(1, 10).ToList();
            foreach (int i in integerList)
            {
                DoSomeIndependentTask(i);
            };
            stopwatch.Stop();
            Console.WriteLine("Standard Foreach Loop Ended");
            Console.WriteLine($"Time Taken by Standard Foreach Loop in Miliseconds { stopwatch.ElapsedMilliseconds}");

            Console.WriteLine("\nParallel Foreach Loop Started");
            stopwatch.Restart();
            Parallel.ForEach(integerList, i =>
            {
                DoSomeIndependentTask(i);
            });
            stopwatch.Stop();
            Console.WriteLine("Parallel Foreach Loop Ended");
            Console.WriteLine($"Time Taken by Parallel Foreach Loop in Miliseconds { stopwatch.ElapsedMilliseconds}");
            Console.ReadLine();
        }
        static void DoSomeIndependentTask(int i)
        {
            Console.WriteLine($"Number: {i}");
        }
        #endregion
    }
}
