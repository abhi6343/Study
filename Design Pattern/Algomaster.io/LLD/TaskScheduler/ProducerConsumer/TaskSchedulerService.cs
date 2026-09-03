using TaskScheduler.Entitieis;
using TaskScheduler.Observers;
using TaskScheduler.Strategies;
using TaskScheduler.Tasks;
using TaskStatus = TaskScheduler.Enums.TaskStatus;

namespace TaskScheduler.ProducerConsumer
{
    internal class TaskSchedulerService
    {
        // volatile ensures all threads see the latest instance reference.
        // Without it, a thread might see a partially constructed object due to instruction reordering.
        static volatile TaskSchedulerService _instance;
        static readonly Lock _instanceLock = new();

        readonly SortedSet<ScheduledTask> _taskQueue;  // Ordered set by execution time
        readonly object _queueLock;     // Monitor object for Wait/PulseAll coordination
        readonly List<ITaskExecutionObserver> _observers;
        readonly Lock _observersLock;   // Protects observer list access
        Thread[] _workers;              // Raw thread pool (no TaskScheduler)
        volatile bool _running;         // volatile so all workers see shutdown immediately
        long _sequenceCounter;          // Generates tiebreaker sequence numbers

        private TaskSchedulerService()
        {
            _taskQueue = [];
            _queueLock = new object();
            _observers = [];
            _observersLock = new();
            _running = false;
            _sequenceCounter = 0;
        }
        public static TaskSchedulerService Instance
        {
            get
            {
                // First check: avoid lock overhead on every call
                if (_instance == null)
                {
                    lock (_instanceLock)
                    {
                        // Second check: another thread may have created the instance
                        // between our first check and acquiring the lock
                        _instance ??= new();
                    }
                }
                return _instance;
            }
        }
        public void Initialize(int workerCount)
        {
            if (workerCount <= 0)
            {
                throw new ArgumentException("Worker count must be positive");
            }
            if (_running)
            {
                throw new TaskSchedulerException("Scheduler is already running");
            }

            _running = true;
            _workers = new Thread[workerCount];
            for (int i = 0; i < workerCount; i++)
            {
                _workers[i] = new(RunWorker)
                {
                    Name = $"Scheduler-Worker-{i}",
                    // Background threads don't prevent process exit. If the main thread
                    // exits without calling Shutdown(), the process still terminates cleanly.
                    IsBackground = true
                };
                _workers[i].Start();
            }
            Console.WriteLine($"Started {workerCount} worker threads");
        }
        public string Schedule(ITask task, ISchedulingStrategy strategy)
        {
            if (task == null || strategy == null)
            {
                throw new ArgumentNullException(task == null ? nameof(task) : nameof(strategy),
                    "Task and strategy must not be null");
            }
            if (!_running)
            {
                throw new TaskSchedulerException("Scheduler is not running");
            }

            long seq = Interlocked.Increment(ref _sequenceCounter) - 1;
            var scheduledTask = new ScheduledTask(task, strategy, seq);

            lock (_queueLock)
            {
                _taskQueue.Add(scheduledTask);
                // Wake ALL waiting workers. One of them will pick up this task.
                // We use PulseAll() instead of Pulse() because a worker in a
                // timed wait (sleeping until a future task) also needs to wake up
                // and re-evaluate if this new task is earlier than what it's waiting for.
                Monitor.PulseAll(_queueLock);
            }
            return scheduledTask.Id;
        }
        public bool Cancel(string taskId)
        {
            lock (_queueLock)
            {
                // Linear scan through the queue to find the task by ID.
                // SortedSet doesn't support O(1) lookup by ID, but cancellation
                // is rare enough that O(n) is acceptable for an interview solution.
                ScheduledTask found = null;
                foreach (var task in _taskQueue)
                {
                    if (task.Id == taskId)
                    {
                        found = task;
                        break;
                    }
                }

                if (found != null)
                {
                    found.Status = TaskStatus.Cancelled;
                    _taskQueue.Remove(found);
                    return true;
                }
            }
            // Task not found: either already executed or invalid ID
            return false;
        }

        public void AddObserver(ITaskExecutionObserver observer)
        {
            // Lock protects the list during concurrent access
            lock (_observersLock)
            {
                _observers.Add(observer);
            }
        }
        public void Shutdown()
        {
            _running = false;  // volatile write: immediately visible to all workers

            // Wake any workers blocked in Monitor.Wait()
            lock (_queueLock)
            {
                Monitor.PulseAll(_queueLock);
            }

            // Interrupt workers that might be sleeping in Monitor.Wait(delayMs)
            // or blocked inside a long-running task
            foreach (var worker in _workers)
            {
                worker?.Interrupt();
            }
            Console.WriteLine("Scheduler shut down.");
        }
        private void RunWorker()
        {
            while (_running)
            {
                ScheduledTask task = null;

                // --- CRITICAL SECTION: access the shared queue under the lock ---
                lock (_queueLock)
                {
                    while (_running)
                    {
                        // Case 1: Queue is empty. Sleep until a task is scheduled.
                        if (_taskQueue.Count == 0)
                        {
                            try
                            {
                                // Releases _queueLock and sleeps. Wakes when:
                                // - Schedule() calls PulseAll() (new task added)
                                // - Shutdown() calls PulseAll()
                                Monitor.Wait(_queueLock);
                            }
                            catch (ThreadInterruptedException)
                            {
                                return;
                            }
                            continue;  // Re-check conditions after waking
                        }

                        // Case 2: Queue has tasks. Check if the earliest one is due.
                        var next = _taskQueue.Min;
                        long delayMs = (long)(next.NextExecutionTime.Value - DateTime.Now).TotalMilliseconds;

                        if (delayMs <= 0)
                        {
                            // Task is due (or overdue). Remove it and break out of the lock block to execute it.
                            task = next;
                            _taskQueue.Remove(next);
                            break;
                        }
                        else
                        {
                            // Case 3: Task is in the future. Sleep for exactly the right amount of time.
                            // Wakes up when: - delayMs expires (time to execute)
                            // - Schedule() calls PulseAll() (new earlier task)
                            // - Shutdown() calls PulseAll()
                            try
                            {
                                Monitor.Wait(_queueLock, (int)delayMs);
                            }
                            catch (ThreadInterruptedException)
                            {
                                return;
                            }
                            // After waking, loop back and re-check. The queue head
                            // might have changed if a new earlier task was added.
                        }
                    }
                }
                // --- END CRITICAL SECTION ---

                // Execute OUTSIDE the lock block. This is crucial:
                // if we held the lock during execution, no other worker could
                // access the queue, and the entire scheduler would serialize.
                if (task != null && task.Status != TaskStatus.Cancelled)
                {
                    ExecuteTask(task);
                }
            }
        }
        private void ExecuteTask(ScheduledTask scheduledTask)
        {
            scheduledTask.Status = TaskStatus.Running;
            NotifyObservers(scheduledTask, "started");

            try
            {
                scheduledTask.Task.Execute();
                scheduledTask.Status = TaskStatus.Completed;
                NotifyObservers(scheduledTask, "completed");
            }
            catch (Exception e)
            {
                // Catch ALL exceptions so a failing task never kills the worker
                scheduledTask.Status = TaskStatus.Failed;
                NotifyObserversFailed(scheduledTask, e);
            }

            // Whether the task succeeded or failed, check if it should run again.
            // For one-time tasks, UpdateForNextExecution() sets nextExecutionTime to null.
            // For recurring tasks, it calculates the next run time.
            scheduledTask.UpdateForNextExecution();
            if (scheduledTask.NextExecutionTime != null)
            {
                scheduledTask.Status = TaskStatus.Scheduled;
                lock (_queueLock)
                {
                    _taskQueue.Add(scheduledTask);
                    // Wake workers so they re-evaluate the new queue head
                    Monitor.PulseAll(_queueLock);
                }
            }
        }

        private void NotifyObservers(ScheduledTask task, string eventType)
        {
            List<ITaskExecutionObserver> snapshot;
            lock (_observersLock)
            {
                snapshot = [.. _observers];
            }

            foreach (var observer in snapshot)
            {
                try
                {
                    if (eventType == "started") observer.OnTaskStarted(task);
                    else if (eventType == "completed") observer.OnTaskCompleted(task);
                }
                catch (Exception)
                {
                    // Observer failures must NEVER affect task execution or scheduling.
                    // A broken logger should not prevent tasks from running.
                }
            }
        }

        private void NotifyObserversFailed(ScheduledTask task, Exception exception)
        {
            List<ITaskExecutionObserver> snapshot;
            lock (_observersLock)
            {
                snapshot = [.. _observers];
            }

            foreach (var observer in snapshot)
            {
                try
                {
                    observer.OnTaskFailed(task, exception);
                }
                catch (Exception)
                {
                    // Same principle: observer errors are silently swallowed
                }
            }
        }

        // For testing: allows resetting the singleton between test cases
        public static void ResetInstance()
        {
            lock (_instanceLock)
            {
                _instance = default;
            }
        }
    }
}