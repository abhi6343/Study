using LoggingFramework.Entities;

namespace LoggingFramework.Strategy
{
    internal class FileAppender : ILogAppender
    {
        private readonly StreamWriter? writer;
        private readonly Lock fileLock = new();

        public FileAppender(string filePath)
        {
            this.Formatter = new SimpleTextFormatter();
            try
            {
                this.writer = new StreamWriter(filePath, true);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to create writer for file logs, exception: {e.Message}");
                this.writer = null;
            }
        }

        public void Append(LogMessage logMessage)
        {
            lock (fileLock)
            {
                if (writer != null)
                {
                    try
                    {
                        writer.Write(Formatter.Format(logMessage) + "\n");
                        writer.Flush();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Failed to write logs to file, exception: {e.Message}");
                    }
                }
            }
        }

        public void Close()
        {
            if (writer != null)
            {
                try
                {
                    writer.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Failed to close logs file, exception: {e.Message}");
                }
            }
        }

        public ILogFormatter Formatter { get; set; }
    }
}
