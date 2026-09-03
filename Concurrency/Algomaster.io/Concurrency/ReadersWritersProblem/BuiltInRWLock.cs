namespace ReadersWritersProblem
{
    internal class BuiltInRWLock
    {
        readonly ReaderWriterLockSlim _rwLock = new();

        public void Read()
        {
            _rwLock.EnterReadLock();
            try
            {
                // Read from shared resource
            }
            finally
            {
                _rwLock.ExitReadLock();
            }
        }

        public void Write()
        {
            _rwLock.EnterWriteLock();
            try
            {
                // Write to shared resource
            }
            finally
            {
                _rwLock.ExitWriteLock();
            }
        }
    }
}
