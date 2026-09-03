namespace BoundedBuffer
{
    internal class SemaphoreBoundedBuffer<T> (int capacity)
    {
        readonly Queue<T> _buffer = new();
        readonly SemaphoreSlim _empty = new(capacity);  // N empty slots initially;  // Counts empty slots
        readonly SemaphoreSlim _full = new(0);          // 0 items initially;   // Counts items
        readonly Lock _lock = new();  // Protects buffer

        public void Produce(T item)
        {
            _empty.Wait();  // Wait for empty slot
            lock (_lock)
            {
                _buffer.Enqueue(item);
            }
            _full.Release();  // Signal item available
        }

        public T Consume()
        {
            _full.Wait();  // Wait for item
            T item;
            lock (_lock)
            {
                item = _buffer.Dequeue();
            }
            _empty.Release();  // Signal slot available
            return item;
        }
    }
}
