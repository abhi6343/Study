namespace FinalizevsDispose
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //#region Implicit call to Dispose
            //// Using the ResourceHolder with using statement
            //using (var resourceHolder = new ResourceHolder())
            //{
            //    // Use the resource...
            //} // Dispose is called automatically when exiting the using block.
            //#endregion


            //#region Explicit call to Dispose
            //// If not using 'using', dispose should be called manually.
            //var anotherResourceHolder = new ResourceHolder();

            //// Use the resource...
            //anotherResourceHolder.Dispose();
            //#endregion


            #region Finalizer call
            // Without calling Dispose, finalizer will be called by GC at some point.
            var finalResourceHolder = new ResourceHolder();

            // Use the resource...
            #endregion


            Console.ReadKey();
        }
    }
}
