namespace TaskManagementSystem.State
{
    internal class InProgressState : ITaskState
    {
        public void StartProgress(Builder.Task task)
        {
            Console.WriteLine("Task is already in progress.");
        }

        public void CompleteTask(Builder.Task task)
        {
            task.SetState(new DoneState());
        }

        public void ReopenTask(Builder.Task task)
        {
            task.SetState(new TodoState());
        }

        public Entities.TaskStatus GetStatus() => Entities.TaskStatus.IN_PROGRESS;
    }
}
