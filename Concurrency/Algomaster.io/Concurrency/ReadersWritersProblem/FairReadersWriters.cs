namespace ReadersWritersProblem
{
    internal class FairReadersWriters
    {
        int _readerCount = 0;
        readonly Lock _readerCountLock = new();
        readonly SemaphoreSlim _resourceAccess = new(1, 1);
        readonly SemaphoreSlim _serviceQueue = new(1, 1);

        public void ReaderAcquire()
        {
            _serviceQueue.Wait();  // Wait in line
            lock (_readerCountLock)
            {
                _readerCount++;
                if (_readerCount == 1)
                {
                    _resourceAccess.Wait();
                }
            }
            _serviceQueue.Release();  // Let next in line proceed
        }

        public void ReaderRelease()
        {
            lock (_readerCountLock)
            {
                _readerCount--;
                if (_readerCount == 0)
                {
                    _resourceAccess.Release();
                }
            }
        }

        public void WriterAcquire()
        {
            _serviceQueue.Wait();  // Wait in line
            _resourceAccess.Wait();  // Get exclusive access
        }

        public void WriterRelease()
        {
            _resourceAccess.Release();
            _serviceQueue.Release();  // Let next in line proceed
        }
    }
}
