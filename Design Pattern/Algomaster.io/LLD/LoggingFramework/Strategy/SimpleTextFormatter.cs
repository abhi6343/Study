using LoggingFramework.Entities;

namespace LoggingFramework.Strategy
{
    internal class SimpleTextFormatter : ILogFormatter
    {
        public string Format(LogMessage logMessage) => $"{logMessage.Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{logMessage.ThreadName}] {logMessage.Level} - {logMessage.LoggerName}: {logMessage.Message}\n";
    }
}
