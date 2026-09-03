namespace UnisexBathroom
{
    internal class UnisexBathroomNaive : IUniSexBathroom
    {
        readonly object _lock = new();

        public void ManEnter()
        {
            Monitor.Enter(_lock);
        }

        public void ManLeave()
        {
            Monitor.Exit(_lock);
        }

        public void WomanEnter()
        {
            Monitor.Enter(_lock);
        }

        public void WomanLeave()
        {
            Monitor.Exit(_lock);
        }
    }
}
