using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThreadSafety
{
    internal class Program
    {
        //#region Without static Interlocked class
        //static void Main(string[] args)
        //{
        //    var ValueWithoutInterlocked = 0;
        //    Parallel.For(0, 100000, _ =>
        //    {
        //        //Incrementing the value
        //        ValueWithoutInterlocked++;
        //    });
        //    Console.WriteLine("Expected Result: 100000");
        //    Console.WriteLine($"Actual Result: {ValueWithoutInterlocked}");
        //    Console.ReadKey();
        //}
        //#endregion


        //#region static Interlocked class
        //static void Main(string[] args)
        //{
        //    var ValueInterlocked = 0;
        //    Parallel.For(0, 100000, _ =>
        //    {
        //        //Incrementing the value
        //        Interlocked.Increment(ref ValueInterlocked);
        //    });
        //    Console.WriteLine("Expected Result: 100000");
        //    Console.WriteLine($"Actual Result: {ValueInterlocked}");
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Interlocked.Add
        //static void Main(string[] args)
        //{
        //    long SumValueWithoutInterlocked = 0;
        //    long SumValueWithInterlocked = 0;
        //    Parallel.For(0, 100000, number =>
        //    {
        //        SumValueWithoutInterlocked = SumValueWithoutInterlocked + number;
        //        Interlocked.Add(ref SumValueWithInterlocked, number);
        //    });
        //    Console.WriteLine($"Sum Value Without Interlocked:{ SumValueWithoutInterlocked}");
        //    Console.WriteLine($"Sum Value With Interlocked: {SumValueWithInterlocked}");
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Interlocked.Exchange and Interlocked.CompareExchange
        //static long x;
        //static void Main(string[] args)
        //{
        //    Thread thread1 = new Thread(new ThreadStart(SomeMethod));
        //    thread1.Start();
        //    thread1.Join();
        //    // Written [20]
        //    Console.WriteLine(Interlocked.Read(ref Program.x));
        //    Console.ReadKey();
        //}
        //static void SomeMethod()
        //{
        //    // Replace x with 20.
        //    Interlocked.Exchange(ref Program.x, 20);
        //    // CompareExchange: if x is 20, then change to current DateTime.Now  or any integer variable.
        //    //long result = Interlocked.CompareExchange(ref Program.x, DateTime.Now.Day, 20);
        //    long result = Interlocked.CompareExchange(ref Program.x, 50, 20);
        //    // Returns original value from CompareExchange
        //    Console.WriteLine(result);
        //}
        //#endregion

        //#region lock
        //static object lockObject = new object();
        //static void Main(string[] args)
        //{
        //    var ValueWithLock = 0;
        //    Parallel.For(0, 100000, _ =>
        //    {
        //        lock (lockObject)
        //        {
        //            //Incrementing the value
        //            ValueWithLock++;
        //        }
        //    });
        //    Console.WriteLine("Expected Result: 100000");
        //    Console.WriteLine($"Actual Result: {ValueWithLock}");
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Lock vs Interlocked performance
        //static readonly object lockObject = new object();
        //static int IncrementValue = 0;
        //const int NumberOfIteration = 10000000;
        //static void Main()
        //{
        //    Stopwatch stopwatch = new Stopwatch();
        //    stopwatch.Start();
        //    // Version 1: use lock.
        //    Parallel.For(0, NumberOfIteration, number =>
        //    {
        //        lock (lockObject)
        //        {
        //            IncrementValue++;
        //        }
        //    });
        //    stopwatch.Stop();
        //    Console.WriteLine($"Result using Lock: {IncrementValue}");
        //    Console.WriteLine($"Lock took {stopwatch.ElapsedMilliseconds} Milliseconds");
        //    //Reset the _test value
        //    IncrementValue = 0;
        //    stopwatch.Restart();
        //    Parallel.For(0, NumberOfIteration, number =>
        //    {
        //        Interlocked.Increment(ref IncrementValue);
        //    });
        //    stopwatch.Stop();
        //    Console.WriteLine($"Result using Interlocked: {IncrementValue}");
        //    Console.WriteLine($"Interlocked took {stopwatch.ElapsedMilliseconds} Milliseconds");
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Lock over Interlocked
        //static void Main(string[] args)
        //{
        //    long IncrementValue = 0;
        //    long SumValue = 0;
        //    Parallel.For(0, 100000, number =>
        //    {
        //        //One thread start executing the Increment method
        //        Interlocked.Increment(ref IncrementValue);

        //        //While the thread travelling to the below code i.e., Add method
        //        //Another thread might get a chance to execute the Increment method
        //        //Which will change the Increment value
        //        Interlocked.Add(ref SumValue, IncrementValue);
        //    });
        //    Console.WriteLine($"Increment Value With Interlocked: {IncrementValue}");
        //    Console.WriteLine($"Sum Value With Interlocked: {SumValue}");
        //    Console.ReadKey();
        //}
        //#endregion


        #region Increment ana Add in lock block
        static object lockObject = new object();
        static void Main(string[] args)
        {
            long IncrementValue = 0;
            long SumValue = 0;
            Parallel.For(0, 10000, number =>
            {
                //Before lock Parallel
                lock (lockObject)
                {
                    IncrementValue++;
                    SumValue += IncrementValue;
                }
                //After lock Parallel
            });
            Console.WriteLine($"Increment Value With lock: {IncrementValue}");
            Console.WriteLine($"Sum Value With lock: {SumValue}");
            Console.ReadKey();
        }
        #endregion
    }
}
