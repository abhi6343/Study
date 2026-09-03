namespace BoundedBuffer
{
    internal class MonitorBoundedBuffer<T>(int _capacity)
    {
        readonly Queue<T> _buffer = new();
        readonly object _lock = new();

        public void Produce(T item)
        {
            lock (_lock)
            {
                // Wait while buffer is full
                while (_buffer.Count == _capacity)
                {
                    Monitor.Wait(_lock);
                }
                _buffer.Enqueue(item);
                Monitor.Pulse(_lock);  // Wake one waiting consumer
            }
        }

        public T Consume()
        {
            lock (_lock)
            {
                // Wait while buffer is empty
                while (_buffer.Count == 0)
                {
                    Monitor.Wait(_lock);
                }
                var item = _buffer.Dequeue();
                Monitor.Pulse(_lock);  // Wake one waiting producer
                return item;
            }
        }
    }
}
