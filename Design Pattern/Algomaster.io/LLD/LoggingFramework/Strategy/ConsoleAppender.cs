using LoggingFramework.Entities;

namespace LoggingFramework.Strategy
{
    internal class ConsoleAppender : ILogAppender
    {
        public void Append(LogMessage logMessage)
        {
            Console.Write(Formatter.Format(logMessage));
        }

        public void Close() { }
        public ILogFormatter Formatter { get; set; } = new SimpleTextFormatter();
    }
}
