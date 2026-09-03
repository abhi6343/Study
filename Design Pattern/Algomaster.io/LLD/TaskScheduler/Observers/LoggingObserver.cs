using TaskScheduler.Entitieis;

namespace TaskScheduler.Observers
{
    internal class LoggingObserver : ITaskExecutionObserver
    {
        public void OnTaskStarted(ScheduledTask task)
        {
            // Include thread name so logs show which worker executed which task
            Console.WriteLine($"[{Thread.CurrentThread.Name}] Task '{task.Task.Name}' started");
        }

        public void OnTaskCompleted(ScheduledTask task)
        {
            Console.WriteLine($"[{Thread.CurrentThread.Name}] Task '{task.Task.Name}' completed");
        }

        public void OnTaskFailed(ScheduledTask task, Exception exception)
        {
            // Use stderr for failures so they stand out in logs
            Console.Error.WriteLine($"[{Thread.CurrentThread.Name}] Task '{task.Task.Name}' failed: {exception.Message}");
        }
    }
}
