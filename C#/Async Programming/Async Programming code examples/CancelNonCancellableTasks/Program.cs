namespace CancelNonCancellableTasks
{
    internal class Program
    {
        //#region Without cancelling the cancellation token
        //static CancellationTokenSource cancellationTokenSource;
        //static void Main(string[] args)
        //{
        //    SomeMethod();
        //    Console.ReadKey();
        //}
        //public static async void SomeMethod()
        //{
        //    cancellationTokenSource = new CancellationTokenSource();
        //    try
        //    {
        //        var result = await Task.Run(async () =>
        //        {
        //            await Task.Delay(TimeSpan.FromSeconds(5));
        //            Console.WriteLine("Operation was Successful");
        //            return 7;
        //        }).WithCancellation(cancellationTokenSource.Token);
        //    }
        //    catch (Exception EX)
        //    {
        //        Console.WriteLine(EX.Message);
        //    }
        //    finally
        //    {
        //        cancellationTokenSource.Dispose();
        //        cancellationTokenSource = null;
        //    }
        //}
        //#endregion

        #region Cancelling the CancellationToken
        static CancellationTokenSource cancellationTokenSource;
        static void Main(string[] args)
        {
            SomeMethod();
            CancelToken();
            Console.ReadKey();
        }
        public static async void SomeMethod()
        {
            cancellationTokenSource = new CancellationTokenSource();
            try
            {
                var result = await Task.Run(async () =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(5));
                    Console.WriteLine("Operation was Successful");
                    return 7;
                }).WithCancellation(cancellationTokenSource.Token);
            }
            catch (Exception EX)
            {
                Console.WriteLine(EX.Message);
            }
            finally
            {
                cancellationTokenSource.Dispose();
                cancellationTokenSource = null;
            }
        }
        public static void CancelToken()
        {
            cancellationTokenSource?.Cancel();
        }
        #endregion
    }
}
