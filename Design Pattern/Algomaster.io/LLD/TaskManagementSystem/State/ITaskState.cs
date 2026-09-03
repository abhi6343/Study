namespace TaskManagementSystem.State
{
    internal interface ITaskState
    {
        void StartProgress(Builder.Task task);
        void CompleteTask(Builder.Task task);
        void ReopenTask(Builder.Task task);
        Entities.TaskStatus GetStatus();
    }
}
