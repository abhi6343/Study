namespace TaskManagementSystem.Strategy
{
    internal interface ITaskSortStrategy
    {
        void Sort(List<Builder.Task> tasks);
    }
}
