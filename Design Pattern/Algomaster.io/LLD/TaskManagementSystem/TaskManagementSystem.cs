using TaskManagementSystem.Entities;
using TaskManagementSystem.Observer;
using TaskManagementSystem.Strategy;

namespace TaskManagementSystem
{
    internal class TaskManagementSystem
    {
        private static TaskManagementSystem? instance;
        private static readonly Lock lockObject = new();
        private readonly Dictionary<string, User> users = [];
        private readonly Dictionary<string, Builder.Task> tasks = [];
        private readonly Dictionary<string, TaskList> taskLists = [];

        private TaskManagementSystem() { }

        public static TaskManagementSystem GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    instance ??= new();
                }
            }
            return instance;
        }

        public User CreateUser(string name, string email)
        {
            User user = new(name, email);
            users[user.Id] = user;
            return user;
        }

        public TaskList CreateTaskList(string listName)
        {
            TaskList taskList = new(listName);
            taskLists[taskList.Id] = taskList;
            return taskList;
        }

        public Builder.Task CreateTask(string title, string description, string dueDate, TaskPriority priority, string createdByUserId)
        {
            if (!users.TryGetValue(createdByUserId, out var createdBy))
            {
                throw new ArgumentException("User not found.");
            }

            var task = new Builder.Task.TaskBuilder(title)
                    .SetDescription(description)
                    .SetDueDate(dueDate)
                    .SetPriority(priority)
                    .SetCreatedBy(createdBy)
                    .Build();

            task.AddObserver(new ActivityLogger());

            tasks[task.GetId()] = task;
            return task;
        }

        public List<Builder.Task> ListTasksByUser(string userId)
        {
            if (!users.TryGetValue(userId, out var user))
            {
                return [];
            }

            return [.. tasks.Values.Where(task => task.GetAssignee() == user)];
        }

        public List<Builder.Task> ListTasksByStatus(Entities.TaskStatus status)
        {
            return tasks.Values.Where(task => task.GetStatus() == status).ToList();
        }

        public void DeleteTask(string taskId)
        {
            tasks.Remove(taskId);
        }

        public List<Builder.Task> SearchTasks(string keyword, ITaskSortStrategy sortingStrategy)
        {
            List<Builder.Task> matchingTasks = [];
            foreach (var task in tasks.Values)
            {
                if (task.GetTitle().Contains(keyword) || task.GetDescription().Contains(keyword))
                {
                    matchingTasks.Add(task);
                }
            }
            sortingStrategy.Sort(matchingTasks);
            return matchingTasks;
        }
    }
}
