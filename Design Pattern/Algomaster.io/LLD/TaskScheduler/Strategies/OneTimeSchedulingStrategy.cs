namespace TaskScheduler.Strategies
{
    internal class OneTimeSchedulingStrategy(DateTime executionTime) : ISchedulingStrategy
    {
        public DateTime? GetNextExecutionTime(DateTime? lastExecutionTime)
        {
            // null lastExecutionTime means the task has never executed
            if (lastExecutionTime == null)
            {
                return executionTime;
            }
            // Already executed once, no more runs needed
            return null;
        }
    }
}
