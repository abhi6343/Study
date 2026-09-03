namespace ReadersWritersProblem
{
    internal class ReadersPreferenceRW
    {
        int _readerCount = 0;
        readonly Lock _readerCountLock = new();
        readonly SemaphoreSlim _resourceAccess = new(1);
        public void ReaderAcquire()
        {
            lock (_readerCountLock)
            {
                _readerCount++;
                if (_readerCount == 1)
                {
                    // First reader locks out writers
                    _resourceAccess.Wait();
                }
            }
        }

        public void ReaderRelease() 
        {
            lock (_readerCountLock) 
            {
                _readerCount--;
                if (_readerCount == 0)
                {
                    // Last reader lets writers in
                    _resourceAccess.Release();
                }
            }
        }

        public void WriterAcquire()
        {
            // Writer needs exclusive access
            _resourceAccess.Wait();
        }

        public void WriterRelease()
        {
            _resourceAccess.Release();
        }
    }
}
