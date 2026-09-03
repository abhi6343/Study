namespace TaskScheduler.Tasks
{
    internal class PrintMessageTask(string message) : ITask
    {
        public string Name => message;

        public void Execute()
        {
            // ToString("HH:mm:ss") gives clean time output without fractional seconds
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
        }
    }
}
