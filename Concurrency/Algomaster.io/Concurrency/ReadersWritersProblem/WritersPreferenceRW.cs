namespace ReadersWritersProblem
{
    // Writers-preference readers-writers lock
    // Readers are blocked when there is at least one waiting writer.
    internal class WritersPreferenceRW
    {
        int readerCount = 0, writerCount = 0;

        // Locks to protect counters
        readonly Lock readerCountLock = new();
        readonly Lock writerCountLock = new();

        // Semaphore that protects the shared resource (1 = free)
        readonly SemaphoreSlim resourceAccess = new(1, 1);
        // Semaphore that writers use to block new readers
        readonly SemaphoreSlim readAccess = new(1, 1);

        public void ReaderAcquire()
        {
            // Wait if writers are waiting (writers acquire readAccess when they start)
            readAccess.Wait();
            try
            {
                lock (readerCountLock)
                {
                    readerCount++;
                    if (readerCount == 1)
                    {
                        // First reader locks the resource for writers
                        resourceAccess.Wait();
                    }
                }
            }
            finally
            {
                // Allow other readers to attempt to enter
                readAccess.Release(); 
            }
        }

        public void ReaderRelease()
        {            
            lock (readerCountLock)
            {
                readerCount--;
                if (readerCount == 0)
                {
                    // Last reader releases the resource
                    resourceAccess.Release();
                }
            }
        }

        public void WriterAcquire()
        {
            // Indicate this writer intends to write
            lock (writerCountLock)
            {
                writerCount++;
                if (writerCount == 1)
                {
                    // First writer blocks new readers
                    readAccess.Wait();
                }
            }

            // Acquire exclusive access to the resource
            resourceAccess.Wait();
        }

        public void WriterRelease()
        {
            // Release exclusive access
            resourceAccess.Release();

            lock (writerCountLock)
            {
                writerCount--;
                if (writerCount == 0)
                {
                    // Last writer allows readers
                    readAccess.Release();
                }
            }
        }
    }
}
