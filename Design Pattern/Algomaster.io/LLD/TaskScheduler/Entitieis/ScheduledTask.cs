using TaskScheduler.Strategies;
using TaskScheduler.Tasks;
using TaskStatus = TaskScheduler.Enums.TaskStatus;

namespace TaskScheduler.Entitieis
{
    internal class ScheduledTask(ITask task, ISchedulingStrategy strategy, long sequenceNumber) : IComparable<ScheduledTask>
    {
        readonly string _id = Guid.NewGuid().ToString();
        DateTime? _nextExecutionTime = strategy.GetNextExecutionTime(null);
        DateTime? _lastExecutionTime = null;
        TaskStatus _status = TaskStatus.Scheduled;
        readonly long _sequenceNumber = sequenceNumber;  // Monotonic counter for FIFO tiebreaking

        public string Id => _id;
        public ITask Task => task;
        public DateTime? NextExecutionTime => _nextExecutionTime;
        public TaskStatus Status
        {
            get => _status;
            set => _status = value;
        }

        public bool HasMoreExecutions()
        {
            return strategy.GetNextExecutionTime(_lastExecutionTime) != null;
        }

        // Called after execution completes. Records the actual finish time
        // (not the scheduled time), then asks the strategy for the next run.
        public void UpdateForNextExecution()
        {
            _lastExecutionTime = DateTime.Now;
            _nextExecutionTime = strategy.GetNextExecutionTime(_lastExecutionTime);
        }

        public int CompareTo(ScheduledTask? other)
        {
            // Null execution times get pushed to the back of the queue
            if (_nextExecutionTime == null && other?._nextExecutionTime == null) return 0;
            if (_nextExecutionTime == null) return 1;
            if (other?._nextExecutionTime == null) return -1;

            // Primary sort: earliest execution time first (min-heap)
            int timeCompare = _nextExecutionTime.Value.CompareTo(other._nextExecutionTime.Value);
            if (timeCompare != 0) return timeCompare;

            // Tiebreaker: lower sequence number first (FIFO for same-time tasks)
            return _sequenceNumber.CompareTo(other._sequenceNumber);
        }

        public override string ToString() => $"ScheduledTask[{task.Name}, next={_nextExecutionTime}, status={_status}]";
    }
}
