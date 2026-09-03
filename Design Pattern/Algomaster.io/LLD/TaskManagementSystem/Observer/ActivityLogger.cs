namespace TaskManagementSystem.Observer
{
    internal class ActivityLogger : ITaskObserver
    {
        public void Update(Builder.Task task, string changeType)
        {
            Console.WriteLine($"LOGGER: Task '{task.GetTitle()}' was updated. Change: {changeType}");
        }
    }
}
