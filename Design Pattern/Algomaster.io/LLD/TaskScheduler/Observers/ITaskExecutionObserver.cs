using TaskScheduler.Entitieis;

namespace TaskScheduler.Observers
{
    internal interface ITaskExecutionObserver
    {
        void OnTaskStarted(ScheduledTask task);
        void OnTaskCompleted(ScheduledTask task);
        void OnTaskFailed(ScheduledTask task, Exception exception);
    }
}
