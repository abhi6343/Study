using System.Diagnostics;

namespace CancelParellelOperations
{
    internal class Program
    {
        //#region Without ParallelOptions.CancellationToken
        //static void Main(string[] args)
        //{
        //    //Create an instance of ParallelOptions class
        //    var parallelOptions = new ParallelOptions()
        //    {
        //        MaxDegreeOfParallelism = 2,
        //    };
        //    try
        //    {
        //        Stopwatch stopwatch = new Stopwatch();
        //        stopwatch.Start();
        //        //Passing ParallelOptions as the first parameter
        //        Parallel.Invoke(
        //        parallelOptions,
        //        () => DoSomeTask(1),
        //        () => DoSomeTask(2),
        //        () => DoSomeTask(3),
        //        () => DoSomeTask(4),
        //        () => DoSomeTask(5),
        //        () => DoSomeTask(6),
        //        () => DoSomeTask(7)
        //        );
        //        stopwatch.Stop();
        //        Console.WriteLine($"Time Taken to Execute all the Methods : {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    Console.ReadLine();
        //}
        //static void DoSomeTask(int number)
        //{
        //    Console.WriteLine($"DoSomeTask {number} started by Thread {Thread.CurrentThread.ManagedThreadId}");
        //    //Sleep for 2 seconds
        //    Thread.Sleep(TimeSpan.FromSeconds(2));
        //    Console.WriteLine($"DoSomeTask {number} completed by Thread {Thread.CurrentThread.ManagedThreadId}");
        //}
        //#endregion


        //#region ParallelOptions.CancellationToken for Parellel.Invoke
        //static void Main(string[] args)
        //{
        //    //Create an Instance of CancellationTokenSource
        //    var CTS = new CancellationTokenSource();
        //    //Set when the token is going to cancel the parallel execution
        //    CTS.CancelAfter(TimeSpan.FromSeconds(5));
        //    //Create an instance of ParallelOptions class
        //    var parallelOptions = new ParallelOptions()
        //    {
        //        MaxDegreeOfParallelism = 2,
        //        //Set the CancellationToken value
        //        CancellationToken = CTS.Token
        //    };
        //    try
        //    {
        //        Stopwatch stopwatch = new Stopwatch();
        //        stopwatch.Start();
        //        //Passing ParallelOptions as the first parameter
        //        Parallel.Invoke(
        //            parallelOptions,
        //            () => DoSomeTask(1),
        //            () => DoSomeTask(2),
        //            () => DoSomeTask(3),
        //            () => DoSomeTask(4),
        //            () => DoSomeTask(5),
        //            () => DoSomeTask(6),
        //            () => DoSomeTask(7)
        //        );
        //        stopwatch.Stop();
        //        Console.WriteLine($"Time Taken to Execute all the Methods : {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
        //    }
        //    //When the token cancelled, it will throw an exception
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        //Finally dispose the CancellationTokenSource and set its valu
        //        CTS.Dispose();
        //        CTS = null;
        //    }
        //    Console.ReadLine();
        //}
        //static void DoSomeTask(int number)
        //{
        //    Console.WriteLine($"DoSomeTask {number} started by Thread {Thread.CurrentThread.ManagedThreadId}");
        //    //Sleep for 2 seconds
        //    Thread.Sleep(TimeSpan.FromSeconds(2));
        //    Console.WriteLine($"DoSomeTask {number} completed by Thread {Thread.CurrentThread.ManagedThreadId}");
        //}
        //#endregion


        //#region ParallelOptions.CancellationToken for Parellel.ForEach
        //static void Main(string[] args)
        //{
        //    //Create an Instance of CancellationTokenSource
        //    var CTS = new CancellationTokenSource();
        //    //Set when the token is going to cancel the parallel execution
        //    CTS.CancelAfter(TimeSpan.FromSeconds(5));
        //    //Create an instance of ParallelOptions class
        //    var parallelOptions = new ParallelOptions()
        //    {
        //        MaxDegreeOfParallelism = 2,
        //        //Set the CancellationToken value
        //        CancellationToken = CTS.Token
        //    };
        //    try
        //    {
        //        List<int> integerList = Enumerable.Range(0, 20).ToList();
        //        Parallel.ForEach(integerList, parallelOptions, i =>
        //        {
        //            Thread.Sleep(TimeSpan.FromSeconds(1));
        //            Console.WriteLine($"Value of i = {i}, thread = {Thread.CurrentThread.ManagedThreadId}");
        //        });
        //    }
        //    //When the token canceled, it will throw an exception
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        //Finally dispose the CancellationTokenSource and set its valu
        //        CTS.Dispose();
        //        CTS = null;
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        #region ParallelOptions.CancellationToken for Parellel.For
        static void Main(string[] args)
        {
            //Create an Instance of CancellationTokenSource
            var CTS = new CancellationTokenSource();
            //Set when the token is going to cancel the parallel execution
            CTS.CancelAfter(TimeSpan.FromSeconds(5));
            //Create an instance of ParallelOptions class
            var parallelOptions = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 2,
                //Set the CancellationToken value
                CancellationToken = CTS.Token
            };
            try
            {
                Parallel.For(1, 21, parallelOptions, i => {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    Console.WriteLine($"Value of i = {i}, thread = {Thread.CurrentThread.ManagedThreadId}");
                });
            }
            //When the token canceled, it will throw an exception
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Finally dispose the CancellationTokenSource and set its valu
                CTS.Dispose();
                CTS = null;
            }
            Console.ReadLine();
        }
        #endregion
    }
}
