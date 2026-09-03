namespace RealtimeAbstractionExample
{
    //Using the Abstraction
    //With the abstraction in place, data fetching becomes a unified process
    internal class DataProcessing
    {
        public void ProcessData(IDataFetcher dataFetcher)
        {
            string data = dataFetcher.FetchData();
            Console.WriteLine(data);
            // Further processing of data if needed
        }
    }
}
