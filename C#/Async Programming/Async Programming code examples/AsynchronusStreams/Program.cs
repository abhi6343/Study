namespace AsynchronusStreams
{
    internal class Program
    {
        //#region Names over period of time
        //static void Main(string[] args)
        //{
        //    ////list of string
        //    //var names = new List<string>() { "Anurag", "Pranaya", "Sambit" }
        //    ////iterating over the list using foreach loop
        //    //foreach (var name in names)
        //    //{
        //    // //You can do anything with the name
        //    // //for example printing the name on the console
        //    // Console.WriteLine(name);
        //    //}
        //    foreach (var name in GenerateNames())
        //    {
        //        //You can do anything with the name
        //        //for example printing the name on the console
        //        Console.WriteLine(name);
        //    }
        //    Console.ReadKey();
        //}
        ////This method is going to generate names over a period of time
        //private static IEnumerable<string> GenerateNames()
        //{
        //    yield return "Anurag";
        //    yield return "Pranaya";

        //    Thread.Sleep(3000);

        //    yield return "Sambit";
        //}
        //#endregion

        //#region Stream with asynchronous
        //static void Main(string[] args)
        //{
        //    foreach (var name in GenerateNames())
        //    {
        //        Console.WriteLine(name);
        //    }
        //    Console.ReadKey();
        //}
        //private static async Task<IEnumerable<string>> GenerateNames()
        //{
        //    yield return "Anurag";
        //    yield return "Pranaya";
        //    await Task.Delay(TimeSpan.FromSeconds(3));
        //    yield return "Sambit";
        //}
        //#endregion

        #region IAsyncEnumerable for stream with asynchronous
        static async Task Main(string[] args)
        {
            await foreach (var name in GenerateNames())
            {
                Console.WriteLine(name);
            }
            Console.ReadKey();
        }
        private static async IAsyncEnumerable<string> GenerateNames()
        {
            yield return "Anurag";
            yield return "Pranaya";
            await Task.Delay(TimeSpan.FromSeconds(3));
            yield return "Sambit";
        }
        #endregion
    }
}
