namespace FinalizevsDispose
{
    internal class ResourceHolder : IDisposable
    {
        // To track whether Dispose has been called.
        private bool _disposed = false;

        // Constructor
        public ResourceHolder()
        {
            // Allocate or initialize an unmanaged resource.
            Console.WriteLine("Unmanaged resource allocated.");
        }

        // Implementing Dispose method from IDisposable interface
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // Prevent finalizer from being called.
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Free any other managed objects here.
                    Console.WriteLine("Free other managed objects");
                }
                // Free unmanaged resources here.
                Console.WriteLine("Unmanaged resource released.");
                _disposed = true;
            }
        }

        // Finalizer is nothing but the destructor
        ~ResourceHolder()
        {
            Dispose(false);
            Console.WriteLine("Finalizer called.");
        }
    }
}
