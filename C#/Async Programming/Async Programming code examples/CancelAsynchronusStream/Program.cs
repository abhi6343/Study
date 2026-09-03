namespace CancelAsynchronusStream
{
    internal class Program
    {
        //#region Break statement
        //static async Task Main(string[] args)
        //{
        //    await foreach (var name in GenerateNames())
        //    {
        //        Console.WriteLine(name);

        //        //Some condition to break the asynchronous stream
        //        if (name == "Pranaya")
        //        {
        //            break;
        //        }

        //    }
        //    Console.ReadKey();
        //}
        //private static async IAsyncEnumerable<string> GenerateNames()
        //{
        //    yield return "Anurag";
        //    await Task.Delay(TimeSpan.FromSeconds(3));
        //    yield return "Pranaya";
        //    await Task.Delay(TimeSpan.FromSeconds(3));
        //    yield return "Sambit";
        //    await Task.Delay(TimeSpan.FromSeconds(3));
        //    yield return "Rakesh";
        //}
        //#endregion


        //#region CancellationToken
        //static async Task Main(string[] args)
        //{
        //    //Create an instance of CancellationTokenSource
        //    var CTS = new CancellationTokenSource();
        //    //Set the time when the token is going to cancel the stream
        //    CTS.CancelAfter(TimeSpan.FromSeconds(5));
        //    try
        //    {
        //        //Pass the Cancelllation Token to GenerateNames method
        //        await foreach (var name in GenerateNames(CTS.Token))
        //        {
        //            Console.WriteLine(name);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        //Dispose the CancellationTokenSource
        //        CTS.Dispose();
        //        CTS = null;
        //    }
        //    Console.ReadKey();
        //}

        ////This method accepts Cancellation Token as input parameter
        ////Set its value to default

        ////private static async IAsyncEnumerable<string> GenerateNames([System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken token = default)
        //private static async IAsyncEnumerable<string> GenerateNames(CancellationToken token = default)
        //{
        //    ////Check if request comes for Token Cancellation
        //    //if (token.IsCancellationRequested)
        //    //{
        //    //    token.ThrowIfCancellationRequested();
        //    //}

        //    //But here we just need to pass the token to Task.Delay method
        //    yield return "Anurag";
        //    await Task.Delay(TimeSpan.FromSeconds(3), token);
        //    yield return "Pranaya";
        //    await Task.Delay(TimeSpan.FromSeconds(3), token);
        //    yield return "Sambit";
        //    await Task.Delay(TimeSpan.FromSeconds(3), token);
        //    yield return "Rakesh";
        //}
        //#endregion


        //#region Consume IAsyncEnumerable
        //static async Task Main(string[] args)
        //{
        //    //Here we are receiving an IAsyncEnumerable.
        //    //This is just a represenatation of the stream,
        //    //But we are not running the stream here
        //    var namesEnumerable = GenerateNames();

        //    ////Creating the CancellationTokenSource instance
        //    //var CTS = new CancellationTokenSource();
        //    ////Setting the time interval when the token is going to be cancelled
        //    //CTS.CancelAfter(TimeSpan.FromSeconds(5));
        //    //var namesEnumerable = GenerateNames(CTS.Token);

        //    await ProcessNames(namesEnumerable);
        //    Console.ReadKey();
        //}
        //private static async Task ProcessNames(IAsyncEnumerable<string> namesEnumerable)
        //{
        //    await foreach (var name in namesEnumerable)
        //    {
        //        Console.WriteLine($"{name} - Processed");
        //    }
        //}
        //private static async IAsyncEnumerable<string> GenerateNames(CancellationToken token = default)
        //{
        //    yield return "Anurag";
        //    await Task.Delay(TimeSpan.FromSeconds(3), token);
        //    yield return "Pranaya";
        //    await Task.Delay(TimeSpan.FromSeconds(3), token);
        //    yield return "Sambit";
        //    await Task.Delay(TimeSpan.FromSeconds(3), token);
        //    yield return "Rakesh";
        //}
        //#endregion

        //#region Consume IAsyncEnumerable with WithCancellation() method
        //static async Task Main(string[] args)
        //{
        //    //Here we are receiving an IAsyncEnumerable.
        //    //This is just a represenatation of the stream,
        //    //But we are not running the stream here
        //    var namesEnumerable = GenerateNames();

        //    await ProcessNames(namesEnumerable);
        //    Console.ReadKey();
        //}
        //private static async Task ProcessNames(IAsyncEnumerable<string> namesEnumerable)
        //{
        //    //Creating the CancellationTokenSource instance
        //    var CTS = new CancellationTokenSource();
        //    //Setting the time interval when the token is going to be cancelled
        //    CTS.CancelAfter(TimeSpan.FromSeconds(5));

        //    //Iterating the IAsyncEnumerable
        //    //Passing the Cancellation Token using WithCancellation method
        //    await foreach (var name in namesEnumerable.WithCancellation(CTS.Token))
        //    {
        //        Console.WriteLine($"{name} - Processed");
        //    }
        //}
        //private static async IAsyncEnumerable<string> GenerateNames(CancellationToken token = default)
        //{
        //    yield return "Anurag";
        //    await Task.Delay(TimeSpan.FromSeconds(3), token);
        //    yield return "Pranaya";
        //    await Task.Delay(TimeSpan.FromSeconds(3), token);
        //    yield return "Sambit";
        //    await Task.Delay(TimeSpan.FromSeconds(3), token);
        //    yield return "Rakesh";
        //}
        //#endregion


        #region EnumeratorCancellation decoration on CancellationToken
        static async Task Main(string[] args)
        {
            //Here we are receiving an IAsyncEnumerable.
            //This is just a represenatation of the stream,
            //But we are not running the stream here
            var namesEnumerable = GenerateNames();

            await ProcessNames(namesEnumerable);
            Console.ReadKey();
        }
        private static async Task ProcessNames(IAsyncEnumerable<string> namesEnumerable)
        {
            //Creating the CancellationTokenSource instance
            var CTS = new CancellationTokenSource();
            //Setting the time interval when the token is going to be cancelled
            CTS.CancelAfter(TimeSpan.FromSeconds(5));

            //Iterating the IAsyncEnumerable
            //Passing the Cancellation Token using WithCancellation method

            //await foreach (var name in namesEnumerable.WithCancellation(CTS.Token))
            //{
            //    Console.WriteLine($"{name} - Processed");
            //}


            try
            {
                await foreach (var name in namesEnumerable.WithCancellation(CTS.Token))
                {
                    Console.WriteLine($"{name} - Processed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CTS.Dispose();
                CTS = null;
            }
        }

        private static async IAsyncEnumerable<string> GenerateNames([System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken token = default)
        {
            yield return "Anurag";
            await Task.Delay(TimeSpan.FromSeconds(3), token);
            yield return "Pranaya";
            await Task.Delay(TimeSpan.FromSeconds(3), token);
            yield return "Sambit";
            await Task.Delay(TimeSpan.FromSeconds(3), token);
            yield return "Rakesh";
        }
        #endregion
    }
}
