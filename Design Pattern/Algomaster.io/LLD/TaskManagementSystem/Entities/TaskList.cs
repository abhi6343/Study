namespace TaskManagementSystem.Entities
{
    internal class TaskList(string name)
    {
        readonly string id = Guid.NewGuid().ToString();
        public string Id { get { return id; } }
        public string Name { get; } = name;
        readonly List<Builder.Task> tasks = [];
        readonly Lock listLock = new();
        public void AddTask(Builder.Task task)
        {
            lock (listLock)
            {
                tasks.Add(task);
            }
        }

        public List<Builder.Task> GetTasks()
        {
            lock (listLock)
            {
                return [.. tasks]; // Return copy
            }
        }
        public void Display()
        {
            Console.WriteLine($"--- Task List: {name} ---");
            foreach (var task in tasks)
            {
                task.Display("");
            }
            Console.WriteLine("-----------------------------------");
        }
    }
}
