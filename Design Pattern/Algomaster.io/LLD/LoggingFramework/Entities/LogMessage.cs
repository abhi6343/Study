using LoggingFramework.Enums;

namespace LoggingFramework.Entities
{
    internal class LogMessage(LogLevel level, string loggerName, string message)
    {
        public DateTime Timestamp { get; } = DateTime.Now;
        public LogLevel Level { get; } = level;
        public string LoggerName { get; } = loggerName;
        public string ThreadName { get; } = Thread.CurrentThread.Name ?? Environment.CurrentManagedThreadId.ToString();
        public string Message { get; } =  message;
    }
}
