namespace GarbageCollections
{
    //internal class MyClass3
    //{
    //    ~MyClass3()
    //    {
    //        //Here, you need to write the code for
    //        //Unmanaged resource clean up
    //    }
    //}


    #region IDisposable
    internal class MyClass3 : IDisposable
    {
        #region IDisposable Support
        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        ~MyClass3()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
    #endregion
}
