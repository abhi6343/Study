namespace BoundedBuffer
{
    internal class NaiveBoundedBuffer<T>//(int _capacity)
    {
        //readonly Queue<T> _buffer = new();
        //readonly Lock _lock = new();

        //public void Produce(T item)
        //{
        //    while (true)
        //    {
        //        lock (_lock)
        //        {
        //            if (_buffer.Count < _capacity)
        //            {
        //                _buffer.Enqueue(item);
        //                return;  // Success
        //            }
        //        }
        //        // Buffer full, busy wait
        //        Thread.Sleep(10);  // Inefficient!
        //    }
        //}

        //public T Consume()
        //{
        //    while (true)
        //    {
        //        lock (_lock)
        //        {
        //            if (_buffer.Count > 0)
        //            {
        //                return _buffer.Dequeue();  // Success
        //            }
        //        }
        //        // Buffer empty, busy wait
        //        Thread.Sleep(10);  // Inefficient!
        //    }
        //}
    }
}
