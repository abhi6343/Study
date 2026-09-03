namespace RealtimeInterfaceExample
{
    //Step 2: Implement the interface for different logging mechanisms.
    // ConsoleLogger.cs
    internal class ConsoleLogger : ILogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine($"Console: {message}");
        }
    }
}
