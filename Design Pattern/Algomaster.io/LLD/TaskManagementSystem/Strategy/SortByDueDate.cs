namespace TaskManagementSystem.Strategy
{
    internal class SortByDueDate : ITaskSortStrategy
    {
        public void Sort(List<Builder.Task> tasks)
        {
            tasks.Sort((a, b) => string.Compare(a.GetDueDate(), b.GetDueDate(), StringComparison.Ordinal));
        }
    }
}
