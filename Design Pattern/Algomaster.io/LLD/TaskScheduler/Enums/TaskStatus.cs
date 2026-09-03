namespace TaskScheduler.Enums
{
    internal enum TaskStatus
    {
        Scheduled,   // In the queue, waiting for a worker
        Running,     // A worker thread is currently executing this task
        Completed,   // Execution finished successfully
        Failed,      // Execution threw an exception
        Cancelled    // Cancelled before execution (terminal, cannot be rescheduled)
    }
}
