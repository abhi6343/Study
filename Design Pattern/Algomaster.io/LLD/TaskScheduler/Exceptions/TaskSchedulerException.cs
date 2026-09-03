namespace TaskScheduler.Exceptions
{
    internal class TaskSchedulerException : Exception
    {
        public TaskSchedulerException(string message) : base(message) { }

        public TaskSchedulerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
