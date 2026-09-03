namespace TaskManagementSystem.State
{
    internal class TodoState : ITaskState
    {
        public void StartProgress(Builder.Task task)
        {
            task.SetState(new InProgressState());
        }

        public void CompleteTask(Builder.Task task)
        {
            Console.WriteLine("Cannot complete a task that is not in progress.");
        }

        public void ReopenTask(Builder.Task task)
        {
            Console.WriteLine("Task is already in TO-DO state.");
        }

        public Entities.TaskStatus GetStatus() => Entities.TaskStatus.TODO;
    }
}
