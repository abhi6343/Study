namespace TaskScheduler.Strategies
{
    internal interface ISchedulingStrategy
    {
        // Returns the next time this task should execute, or null if done.
        // lastExecutionTime is null on the first call (task has never run).
        DateTime? GetNextExecutionTime(DateTime? lastExecutionTime);
    }
}
