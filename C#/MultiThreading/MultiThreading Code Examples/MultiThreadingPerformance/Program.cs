using System.Diagnostics;

namespace MultiThreadingPerformance
{
    internal class Program
    {
        public static void Main()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();            

            //#region Single Thread
            EvenNumbersSum();
            OddNumbersSum();
            stopwatch.Stop();
            Console.WriteLine($"Total time in milliseconds : {stopwatch.ElapsedMilliseconds}");
            //#endregion

            #region Multi Thread
            stopwatch = Stopwatch.StartNew();
            var thread1 = new Thread(EvenNumbersSum);
            var thread2 = new Thread(OddNumbersSum);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            stopwatch.Stop();
            #endregion

            Console.WriteLine($"Total time in milliseconds for Multi-threading: {stopwatch.ElapsedMilliseconds}");
            Console.ReadKey();
        }
        public static void EvenNumbersSum()
        {
            double Evensum = 0;
            for (int count = 0; count <= 50000000; count++)
            {
                if (count % 2 == 0)
                {
                    Evensum += count;
                }
            }
            Console.WriteLine($"Sum of even numbers = {Evensum}");
        }
        public static void OddNumbersSum()
        {
            double Oddsum = 0;
            for (int count = 0; count <= 50000000; count++)
            {
                if (count % 2 == 1)
                {
                    Oddsum += count;
                }
            }
            Console.WriteLine($"Sum of odd numbers = {Oddsum}");
        }
    }
}
