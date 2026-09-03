using LoggingFramework.Entities;

namespace LoggingFramework.Strategy
{
    internal interface ILogFormatter
    {
        string Format(LogMessage logMessage);
    }
}
