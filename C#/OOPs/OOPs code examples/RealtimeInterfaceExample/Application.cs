namespace RealtimeInterfaceExample
{
    //Step 3: Use the implementations in an application.
    internal class Application
    {
        private ILogger _logger;
        public Application(ILogger logger)
        {
            _logger = logger;
        }
        public void Run()
        {
            // Example of a scenario where we want to log a message
            _logger.LogMessage("Application started.");
            // More code and operations...
            _logger.LogMessage("Application ended.");
        }
    }
}
