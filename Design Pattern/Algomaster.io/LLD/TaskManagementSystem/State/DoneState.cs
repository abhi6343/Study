namespace TaskManagementSystem.State
{
    internal class DoneState : ITaskState
    {
        public void StartProgress(Builder.Task task)
        {
            Console.WriteLine("Cannot start a completed task. Reopen it first.");
        }

        public void CompleteTask(Builder.Task task)
        {
            Console.WriteLine("Task is already done.");
        }

        public void ReopenTask(Builder.Task task)
        {
            task.SetState(new TodoState());
        }

        public Entities.TaskStatus GetStatus() => Entities.TaskStatus.DONE;
    }
}
