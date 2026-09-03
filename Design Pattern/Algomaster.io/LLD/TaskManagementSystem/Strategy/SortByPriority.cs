namespace TaskManagementSystem.Strategy
{
    internal class SortByPriority : ITaskSortStrategy
    {
        public void Sort(List<Builder.Task> tasks)
        {
            // Higher priority comes first
            tasks.Sort((a, b) => b.GetPriority().CompareTo(a.GetPriority()));
        }
    }
}
