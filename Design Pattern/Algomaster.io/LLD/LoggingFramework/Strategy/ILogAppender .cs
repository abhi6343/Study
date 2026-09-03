using LoggingFramework.Entities;

namespace LoggingFramework.Strategy
{
    internal interface ILogAppender
    {
        void Append(LogMessage logMessage);
        void Close();
        public ILogFormatter Formatter { get; set; }
    }
}
