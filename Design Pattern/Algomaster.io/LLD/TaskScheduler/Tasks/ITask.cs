namespace TaskScheduler.Tasks
{
    internal interface ITask
    {
        string Name { get; }   // Human-readable identifier for logging and monitoring
        void Execute();        // Performs the actual work
    }
}
