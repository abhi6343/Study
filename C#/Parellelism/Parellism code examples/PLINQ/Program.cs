using System.Diagnostics;

namespace PLINQ
{
    internal class Program
    {
        //#region Using LINQ
        //static void Main(string[] args)
        //{
        //    //Creating a Collection of integer numbers
        //    var numbers = Enumerable.Range(1, 20);
        //    //Fetching the List of Even Numbers using LINQ
        //    var evenNumbers = numbers.Where(x => x % 2 == 0).ToList();
        //    Console.WriteLine("Even Numbers Between 1 and 20");
        //    foreach (var number in evenNumbers)
        //    {
        //        Console.WriteLine(number);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Using PLINQ
        //static void Main(string[] args)
        //{
        //    //Creating a Collection of integer numbers
        //    var numbers = Enumerable.Range(1, 20);
        //    //Fetching the List of Even Numbers using LINQ
        //    //var evenNumbers = numbers.Where(x => x % 2 == 0).ToList();
        //    //Fetching the List of Even Numbers using PLINQ
        //    //PLINQ means we need to use AsParallel()
        //    var evenNumbers = numbers.AsParallel().Where(x => x % 2 == 0).ToList();
        //    Console.WriteLine("Even Numbers Between 1 and 20");
        //    foreach (var number in evenNumbers)
        //    {
        //        Console.WriteLine(number);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Using PLINQ and maintain order
        //static void Main(string[] args)
        //{
        //    //Creating a Collection of integer numbers
        //    var numbers = Enumerable.Range(1, 20);
        //    //Fetching the List of Even Numbers using PLINQ
        //    //PLINQ means we need to use AsParallel()
        //    var evenNumbers = numbers
        //    .AsParallel() //Parallel Processing
        //    .AsOrdered() //Original Order of the numbers
        //    .Where(x => x % 2 == 0)
        //    .ToList();
        //    Console.WriteLine("Even Numbers Between 1 and 20");
        //    foreach (var number in evenNumbers)
        //    {
        //        Console.WriteLine(number);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region LINQ OrderBy
        //static void Main(string[] args)
        //{
        //    //Creating a Collection of integer numbers
        //    List<int> numbers = new List<int>()
        //    {
        //        1, 2, 6, 7, 5, 4, 10, 12, 13, 20, 18, 9, 11, 15, 14, 3, 8, 16,
        //    };


        //    //Using PLINQ AsOrdered Method
        //    //Fetching the List of Even Numbers using PLINQ
        //    var evenNumbers1 = numbers
        //    .AsParallel() //Parallel Processing
        //    .AsOrdered() //Original Order of the numbers
        //    .Where(x => x % 2 == 0)
        //    .ToList();
        //    Console.WriteLine("Even Numbers Between 1 and 20 using AsOrdered");
        //    foreach (var number in evenNumbers1)
        //    {
        //        Console.WriteLine(number);
        //    }


        //    //Using LINQ OrderBy Method
        //    //Fetching the List of Even Numbers using PLINQ
        //    var evenNumbers2 = numbers
        //    .AsParallel() //Parallel Processing
        //    .Where(x => x % 2 == 0)
        //    .OrderBy(x => x) //Sort the Elements in Ascending Order
        //    .ToList();
        //    Console.WriteLine("\nEven Numbers Between 1 and 20 using OrderBy");
        //    foreach (var number in evenNumbers2)
        //    {
        //        Console.WriteLine(number);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region MaximumDegreeOfParellelism and CancellationTokenSource
        //static void Main(string[] args)
        //{
        //    //Creating an instance of CancellationTokenSource
        //    var CTS = new CancellationTokenSource();
        //    //Setting the time when the token is going to cancel the Parallel
        //    CTS.CancelAfter(TimeSpan.FromMilliseconds(200));

        //    //Creating a Collection of integer numbers
        //    var numbers = Enumerable.Range(1, 20);

        //    //Fetching the List of Even Numbers using PLINQ
        //    var evenNumbers = numbers
        //    .AsParallel() //Parallel Processing
        //    .AsOrdered() //Original Order of the numbers
        //    .WithDegreeOfParallelism(2) //Maximum of two threads can proce
        //    .WithCancellation(CTS.Token) //Cancel the operation after 200 Milliseconds
        //    .Where(x => x % 2 == 0) //This logic will execute in parallel
        //    .ToList();

        //    Console.WriteLine("Even Numbers Between 1 and 20");
        //    foreach (var number in evenNumbers)
        //    {
        //        Console.WriteLine(number);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Aggregates in PLINQ
        //static void Main()
        //{
        //    var numbers = Enumerable.Range(1, 10000);
        //    //Sum, Min, Max and Average LINQ extension methods
        //    Console.WriteLine("Sum, Min, Max and Average with LINQ");
        //    var Sum = numbers.AsParallel().Sum();
        //    var Min = numbers.AsParallel().Min();
        //    var Max = numbers.AsParallel().Max();
        //    var Average = numbers.AsParallel().Average();
        //    Console.WriteLine($"Sum:{Sum}\nMin: {Min}\nMax: {Max}\nAverage:{Average}");
        //    Console.ReadKey();
        //}
        //#endregion

        #region PLINQ vs LINQ
        static void Main()
        {
            var random = new Random();
            int[] values = Enumerable.Range(1, 99999999)
            .Select(x => random.Next(1, 1000))
            .ToArray();

            //Min, Max and Average LINQ extension methods
            Console.WriteLine("Min, Max and Average with LINQ");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // var linqStart = DateTime.Now;
            var linqMin = values.Min();
            var linqMax = values.Max();
            var linqAverage = values.Average();
            stopwatch.Stop();
            var linqTimeMS = stopwatch.ElapsedMilliseconds;
            DisplayResults(linqMin, linqMax, linqAverage, linqTimeMS);

            //Min, Max and Average PLINQ extension methods
            Console.WriteLine("\nMin, Max and Average with PLINQ");
            stopwatch.Restart();
            var plinqMin = values.AsParallel().Min();
            var plinqMax = values.AsParallel().Max();
            var plinqAverage = values.AsParallel().Average();
            stopwatch.Stop();
            var plinqTimeMS = stopwatch.ElapsedMilliseconds;
            DisplayResults(plinqMin, plinqMax, plinqAverage, plinqTimeMS);
            Console.ReadKey();
        }
        static void DisplayResults(int min, int max, double average, double time)
        {
            Console.WriteLine($"Min: {min}\nMax: {max}\n" + $"Average: {average}\n" + $"Total time in milliseconds: {time}");
        }
        #endregion
    }
}
