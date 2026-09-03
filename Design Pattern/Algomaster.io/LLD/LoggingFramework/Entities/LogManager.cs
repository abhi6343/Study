using System.Collections.Concurrent;

namespace LoggingFramework.Entities
{
    internal class LogManager
    {
        private static volatile LogManager? instance;
        private static readonly Lock lockObject = new();
        private readonly ConcurrentDictionary<string, Logger> loggers = [];
        public Logger RootLogger { get; } = new("root", null);
        public AsyncLogProcessor Processor { get; } = new();

        private LogManager()
        {
            this.loggers.TryAdd("root", RootLogger);
        }

        public static LogManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        instance ??= new();
                    }
                }
                return instance;
            }
        }

        // Logger Factory method to get or create loggers by name
        public Logger GetOrCreateLogger(string name)
        {
            return loggers.GetOrAdd(name, CreateLogger);
        }

        private Logger CreateLogger(string name)
        {
            if (name.Equals("root"))
            {
                return RootLogger;
            }
            int lastDot = name.LastIndexOf('.');
            string parentName = (lastDot == -1) ? "root" : name[..lastDot];
            var parent = GetOrCreateLogger(parentName);
            return new(name, parent);
        }

        public void Shutdown()
        {
            // Stop the processor first to ensure all logs are written
            Processor.Stop();

            // Then, close all appenders
            var allAppenders = loggers.Values.SelectMany(logger => logger.Appenders).Distinct();

            foreach (var appender in allAppenders)
            {
                appender.Close();
            }

            Console.WriteLine("Logging framework shut down gracefully.");
        }
    }
}
