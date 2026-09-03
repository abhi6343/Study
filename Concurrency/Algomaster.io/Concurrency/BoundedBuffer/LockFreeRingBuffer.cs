namespace BoundedBuffer
{
    // Note: This is a simplified SPSC (single-producer, single-consumer) implementation.
    // For production, consider using System.Threading.Channels.
    internal class LockFreeRingBuffer<T>
    {
        readonly T?[] _buffer;
        readonly int _capacity;
        int _head;  // Consumer reads here
        int _tail;  // Producer writes here

        public LockFreeRingBuffer(int capacity)
        {
            // Round up to power of 2
            _capacity = (int)Math.Pow(2, Math.Ceiling(Math.Log2(capacity)));
            _buffer = new T?[_capacity];
            _head = 0;
            _tail = 0;
        }

        // Single producer only
        public bool TryProduce(T item)
        {
            int currentTail = Volatile.Read(ref _tail);
            int nextTail = (currentTail + 1) & (_capacity - 1);
            if (nextTail == Volatile.Read(ref _head))
            {
                return false;  // Buffer full
            }
            _buffer[currentTail] = item;
            Volatile.Write(ref _tail, nextTail);
            return true;
        }

        // Single consumer only
        public bool TryConsume(out T item)
        {
            int currentHead = Volatile.Read(ref _head);
            if (currentHead == Volatile.Read(ref _tail))
            {
                item = default!;
                return false;  // Buffer empty
            }
            item = _buffer[currentHead]!;
            Volatile.Write(ref _head, (currentHead + 1) & (_capacity - 1));
            return true;
        }
    }
}
