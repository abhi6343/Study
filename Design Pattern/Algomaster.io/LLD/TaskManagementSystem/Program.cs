// See https://aka.ms/new-console-template for more information
using TaskManagementSystem.Entities;
using TaskManagementSystem.Strategy;

var taskManagementSystem = TaskManagementSystem.TaskManagementSystem.GetInstance();

// Create users
User user1 = taskManagementSystem.CreateUser("John Doe", "john@example.com");
User user2 = taskManagementSystem.CreateUser("Jane Smith", "jane@example.com");

// Create task lists
TaskList taskList1 = taskManagementSystem.CreateTaskList("Enhancements");
TaskList taskList2 = taskManagementSystem.CreateTaskList("Bug Fix");

// Create tasks
var task1 = taskManagementSystem.CreateTask("Enhancement Task", "Launch New Feature", "2024-02-15", TaskPriority.LOW, user1.Id);
var subtask1 = taskManagementSystem.CreateTask("Enhancement sub task", "Design UI/UX", "2024-02-14", TaskPriority.MEDIUM, user1.Id);
var task2 = taskManagementSystem.CreateTask("Bug Fix Task", "Fix API Bug", "2024-02-16", TaskPriority.HIGH, user2.Id);

task1.AddSubtask(subtask1);

taskList1.AddTask(task1);
taskList2.AddTask(task2);

taskList1.Display();

// Update task status
subtask1.StartProgress();

// Assign task
subtask1.SetAssignee(user2);

taskList1.Display();

// Search tasks
var searchResults = taskManagementSystem.SearchTasks("Task", new SortByDueDate());
Console.WriteLine("\nTasks with keyword Task:");
foreach (var task in searchResults)
{
    Console.WriteLine(task.GetTitle());
}

// Filter tasks by status
var filteredTasks = taskManagementSystem.ListTasksByStatus(TaskManagementSystem.Entities.TaskStatus.TODO);
Console.WriteLine("\nTODO Tasks:");
foreach (var task in filteredTasks)
{
    Console.WriteLine(task.GetTitle());
}

// Mark a task as done
subtask1.CompleteTask();

// Get tasks assigned to a user
var userTaskList = taskManagementSystem.ListTasksByUser(user2.Id);
Console.WriteLine($"\nTask for {user2.Name}:");
foreach (var task in userTaskList)
{
    Console.WriteLine(task.GetTitle());
}

taskList1.Display();

// Delete a task
taskManagementSystem.DeleteTask(task2.GetId());
