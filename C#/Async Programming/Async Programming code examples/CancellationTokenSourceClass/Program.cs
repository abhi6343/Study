using System.Diagnostics;

namespace CancellationTokenSourceClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SomeMethod();
            Console.ReadKey();
        }
        private static async void SomeMethod()
        {
            int count = 10;
            Console.WriteLine("SomeMethod Method Started");
            var cancellationTokenSource = new CancellationTokenSource(5000);

            //var cancellationTokenSource = new CancellationTokenSource();
            //cancellationTokenSource.CancelAfter(5000);

            try
            {
                await LongRunningTask(count, cancellationTokenSource.Token);
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            Console.WriteLine("\nSomeMethod Method Completed");
        }
        public static async Task LongRunningTask(int count, CancellationToken token)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("\nLongRunningTask Started");
            for (int i = 1; i <= count; i++)
            {
                await Task.Delay(1000, token);
                Console.WriteLine("LongRunningTask Processing....");
                //if (token.IsCancellationRequested)
                //{
                //    throw new TaskCanceledException();
                //}
            }
            stopwatch.Stop();
            Console.WriteLine($"LongRunningTask Took { stopwatch.ElapsedMilliseconds / 1000.0} Seconds for Processing");
        }

        #region User-Initiated Cancellation
        //CancellationTokenSource cts = new CancellationTokenSource();
        //Task.Run(() =>
        //{
        //  // Long-running operation
        //  for (int i = 0; i< 10000; i++)
        //  {
        //      if (cts.Token.IsCancellationRequested)
        //      {
        //          // Perform cleanup or return early
        //          return;
        //      }
        //      // Perform some work
        //  }
        //}, cts.Token);
        //// To request cancellation:
        //// cts.Cancel();
        #endregion

        #region Time-Based Cancellation
        //CancellationTokenSource cts = new CancellationTokenSource();
        //Timer timer = new Timer(_ => cts.Cancel(), null, TimeSpan.FromSeconds(5),
        //Timeout.InfiniteTimeSpan);
        //Task.Run(() =>
        //{
        //    while (!cts.Token.IsCancellationRequested)
        //    {
        //        // Perform some work
        //    }
        //}, cts.Token);
        #endregion

        #region Cooperative Cancellation
        //CancellationTokenSource cts = new CancellationTokenSource();
        //Task task1 = Task.Run(() => { /* Task 1 logic */ }, cts.Token);
        //Task task2 = Task.Run(() => { /* Task 2 logic */ }, cts.Token);
        // To request cancellation for both tasks:
        // cts.Cancel();
        #endregion

        #region Cancellation in Async Methods
        //public async Task DoAsyncOperation(CancellationToken cancellationToken)
        //{
        //    while (!cancellationToken.IsCancellationRequested)
        //    {
        //        // Perform async work
        //        await Task.Delay(1000);
        //    }
        //}
        #endregion
    }
}
