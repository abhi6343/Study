using LoggingFramework.Enums;
using LoggingFramework.Strategy;

namespace LoggingFramework.Entities
{
    internal class Logger(string name, Logger? parent)
    {
        private LogLevel? level;
        private readonly Logger? parent = parent;
        public ICollection<ILogAppender> Appenders { get; } = [];
        private bool additivity = true;

        public void AddAppender(ILogAppender appender)
        {
            Appenders.Add(appender);
        }       

        public void SetLevel(LogLevel minLevel)
        {
            this.level = minLevel;
        }

        public void SetAdditivity(bool additivity)
        {
            this.additivity = additivity;
        }

        public void Log(LogLevel messageLevel, string message)
        {
            if (messageLevel.IsGreaterOrEqual(GetEffectiveLevel()))
            {
                CallAppenders(new(messageLevel, name, message));
            }

            LogLevel GetEffectiveLevel()
            {
                for (var logger = this; logger != null; logger = logger.parent)
                {
                    var currentLevel = logger.level;
                    if (currentLevel.HasValue)
                    {
                        return currentLevel.Value;
                    }
                }
                return LogLevel.DEBUG; // Default root level
            }
        }

        private void CallAppenders(LogMessage logMessage)
        {
            if (Appenders.Count > 0)
            {
                LogManager.Instance.Processor.Process(logMessage, this.Appenders);
            }
            if (additivity && parent != null)
            {
                parent.CallAppenders(logMessage);
            }
        }

        public void Debug(string message) => Log(LogLevel.DEBUG, message);

        public void Info(string message) => Log(LogLevel.INFO, message);        

        public void Warn(string message) => Log(LogLevel.WARN, message);        

        public void Error(string message) => Log(LogLevel.ERROR, message);

        public void Fatal(string message) => Log(LogLevel.FATAL, message);
    }
}
