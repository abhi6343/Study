namespace ReadersWritersProblem
{
    internal class MonitorRWLock
    {
        readonly object _lock = new();
        int _readers = 0, _writers = 0, _waitingWriters = 0;

        public void ReaderAcquire()
        {
            lock (_lock)
            {
                while (_writers > 0 || _waitingWriters > 0)
                {
                    Monitor.Wait(_lock);  // Wait if writer active or waiting
                }
                _readers++;
            }
        }

        public void ReaderRelease()
        {
            lock (_lock)
            {
                _readers--;
                if (_readers == 0)
                {
                    Monitor.PulseAll(_lock);  // Wake up waiting threads
                }
            }
        }

        public void WriterAcquire()
        {
            lock (_lock)
            {
                _waitingWriters++;
                while (_readers > 0 || _writers > 0)
                {
                    Monitor.Wait(_lock);
                }
                _waitingWriters--;
                _writers++;
            }
        }

        public void WriterRelease()
        {
            lock (_lock)
            {
                _writers--;
                Monitor.PulseAll(_lock);  // Wake all waiting readers and writers
            }
        }
    }
}
