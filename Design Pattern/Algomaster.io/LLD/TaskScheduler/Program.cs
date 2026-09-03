using TaskScheduler.Tasks;
using TaskScheduler.Observers;
using TaskScheduler.ProducerConsumer;
using TaskScheduler.Strategies;


// 1. Setup the facade and observers
var scheduler = TaskSchedulerService.Instance;
scheduler.AddObserver(new LoggingObserver());

// 2. Initialize the scheduler
scheduler.Initialize(10);

// 3. Define tasks and strategies
// Scenario 1: One-time task, 1 second from now
ITask oneTimeTask = new PrintMessageTask("This is a one-time task.");
ISchedulingStrategy oneTimeStrategy = new OneTimeSchedulingStrategy(DateTime.Now.AddSeconds(1));

// Scenario 2: Recurring task, every 2 seconds
ITask recurringTask = new PrintMessageTask("This is a recurring task.");
ISchedulingStrategy recurringStrategy = new RecurringSchedulingStrategy(TimeSpan.FromSeconds(2));

// Scenario 3: A long-running backup task, scheduled to run in 3 seconds
ITask backupTask = new DataBackupTask("/data/source", "/data/backup");
ISchedulingStrategy longRunningStrategy = new OneTimeSchedulingStrategy(DateTime.Now.AddSeconds(3));

// 4. Schedule the tasks using the facade
Console.WriteLine("Scheduling tasks...");
scheduler.Schedule(oneTimeTask, oneTimeStrategy);
scheduler.Schedule(recurringTask, recurringStrategy);
scheduler.Schedule(backupTask, longRunningStrategy);

// 5. Let the demo run for a while
Console.WriteLine("Scheduler is running. Waiting for tasks to execute... (Demo will run for 6 seconds)");
Thread.Sleep(6000);

// 6. Shutdown the scheduler
scheduler.Shutdown();