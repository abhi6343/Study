namespace TaskScheduler.Tasks
{
    internal class DataBackupTask(string source, string destination) : ITask
    {
        public string Name => "DataBackupTask";

        public void Execute()
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Starting backup: {source} -> {destination}");
            try
            {
                Thread.Sleep(2000);  // Simulate I/O-bound work
            }
            catch (ThreadInterruptedException)
            {
                // Thread was interrupted during sleep (e.g., during shutdown).
                // Re-interrupt the current thread so the caller (worker thread)
                // knows this thread was interrupted during execution.
                Thread.CurrentThread.Interrupt();
            }
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Backup completed: {source} -> {destination}");
        }
    }
}
