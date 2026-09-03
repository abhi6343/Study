namespace TaskScheduler.Strategies
{
    internal class RecurringSchedulingStrategy : ISchedulingStrategy
    {
        private readonly TimeSpan _interval;

        public RecurringSchedulingStrategy(TimeSpan interval)
        {
            // Fail fast: zero or negative intervals make no sense for recurring tasks
            if (interval <= TimeSpan.Zero)
            {
                throw new ArgumentException("Interval must be positive");
            }
            _interval = interval;
        }

        public DateTime? GetNextExecutionTime(DateTime? lastExecutionTime)
        {
            // First execution: schedule relative to now
            // Subsequent executions: schedule relative to when the task last finished
            DateTime baseTime = lastExecutionTime ?? DateTime.Now;
            return baseTime.Add(_interval);
        }
    }
}
