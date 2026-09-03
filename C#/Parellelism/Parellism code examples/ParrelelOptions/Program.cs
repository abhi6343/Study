namespace ParrellelOptions
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    Parallel.For(1, 11, i =>
        //    {
        //        Thread.Sleep(500);
        //        Console.WriteLine($"Value of i = {i}, Thread = {Thread.CurrentThread.ManagedThreadId}");
        //    });
        //    Console.ReadLine();
        //}


        //#region MaxDegreeOfParellelism
        //static void Main(string[] args)
        //{
        //    //Limiting the maximum degree of parallelism to 3
        //    var options = new ParallelOptions()
        //    {
        //        MaxDegreeOfParallelism = 3
        //    };
        //    //A maximum of three threads are going to execute the code paralle
        //    Parallel.For(1, 11, options, i =>
        //    {
        //        Thread.Sleep(500);
        //        Console.WriteLine($"Value of i = {i}, Thread = {Thread.CurrentThread.ManagedThreadId}");
        //    });
        //    Console.ReadLine();
        //}
        //#endregion


        //#region MaxDegreeOfParallelism = Environment.ProcessorCount - 1
        //static void Main(string[] args)
        //{
        //    //Getting the Number of Processor count
        //    int processorCount = Environment.ProcessorCount;
        //    Console.WriteLine($"Processor Count on this Machine: {processorCount}\n");
        //    //Limiting the maximum degree of parallelism to processorCount - 1
        //    var options = new ParallelOptions()
        //    {
        //        //You can hard code the value as follows
        //        //MaxDegreeOfParallelism = 7
        //        //But better to use the following statement
        //        MaxDegreeOfParallelism = Environment.ProcessorCount - 1
        //    };
        //    Parallel.For(1, 11, options, i =>
        //    {
        //        Thread.Sleep(500);
        //        Console.WriteLine($"Value of i = {i}, Thread = {Thread.CurrentThread.ManagedThreadId}");
        //    });
        //    Console.ReadLine();
        //}
        //#endregion


        //#region ForEach
        //static void Main(string[] args)
        //{
        //    //Limiting the maximum degree of parallelism to ProcessorCount - 1
        //    var options = new ParallelOptions()
        //    {
        //        //MaxDegreeOfParallelism = 7
        //        MaxDegreeOfParallelism = Environment.ProcessorCount - 1
        //    };
        //    List<int> integerList = Enumerable.Range(0, 10).ToList();
        //    Parallel.ForEach(integerList, options, i =>
        //    {
        //        Console.WriteLine($"Value of i = {i}, thread = {Thread.CurrentThread.ManagedThreadId}");
        //    });
        //    Console.ReadLine();
        //}
        //#endregion


        #region ForInvoke
        static void Main(string[] args)
        {
            var parallelOptions = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 3
                //MaxDegreeOfParallelism = Environment.ProcessorCount - 1
            };
            //Passing ParallelOptions as the first parameter
            Parallel.Invoke(
                parallelOptions,
                () => DoSomeTask(1),
                () => DoSomeTask(2),
                () => DoSomeTask(3),
                () => DoSomeTask(4),
                () => DoSomeTask(5),
                () => DoSomeTask(6),
                () => DoSomeTask(7)
            );
            Console.ReadLine();
        }
        static void DoSomeTask(int number)
        {
            Console.WriteLine($"DoSomeTask {number} started by Thread {Thread.CurrentThread.ManagedThreadId}");
            //Sleep for 5000 milliseconds
            Thread.Sleep(5000);
            Console.WriteLine($"DoSomeTask {number} completed by Thread {Thread.CurrentThread.ManagedThreadId}");
        }
        #endregion
    }
}
