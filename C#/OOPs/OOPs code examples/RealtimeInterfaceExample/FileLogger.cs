namespace RealtimeInterfaceExample
{
    // FileLogger.cs
    internal class FileLogger : ILogger
    {
        private string filePath;
        public FileLogger(string filePath)
        {
            this.filePath = filePath;
        }
        public void LogMessage(string message)
        {
            System.IO.File.AppendAllText(filePath, message + Environment.NewLi
        }
    }
}
