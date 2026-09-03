namespace Destructors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //#region
            //DestructorDemo obj1 = new DestructorDemo();
            //DestructorDemo obj2 = new DestructorDemo();
            ////Making obj1 null for Garbage Collection
            //obj1 = null;
            //obj2 = null;

            //GC.Collect();
            //#endregion

            //#region Calling garbage collector multiple times
            //Console.WriteLine("Main Method Execution Started");
            //DestructorDemo obj1 = new DestructorDemo();
            ////Making obj1 ready for Garbage Collection
            //obj1 = null;
            //GC.Collect();
            //Console.WriteLine("Some Statement Executed Inside Main Method");
            //obj1 = null;
            //GC.Collect();
            //Console.WriteLine("Some More Statement Executed Inside Main Method");
            //GC.Collect();
            //Console.WriteLine("Main Method Execution End");
            //#endregion


            //#region Garbage collect for multilevel inheritence
            //Third obj = new Third();
            //obj = null;
            //GC.Collect();
            //#endregion


            //#region Garbage collect for unmanaged resource
            //UmmanagedResource resource = new UmmanagedResource();
            //Console.WriteLine("Using Unmanaged Resource");
            //resource = null;
            //GC.Collect();
            //#endregion


            //#region Explicit Release of Resources using Dispose Pattern
            //UmmanagedResource resource = null;
            //try
            //{
            //    resource = new UmmanagedResource();
            //    Console.WriteLine("Using Resources");
            //}
            //finally
            //{
            //    if (resource != null)
            //    {
            //        Console.WriteLine("Calling Dispose Method to Destroy Resources");
            //        resource.Dispose();
            //    }
            //}
            ////Trying to Call the Dispose Method again
            //Console.WriteLine();
            //Console.WriteLine("Trying to Call the Dispose Method Again To Destroy Resources");
            //resource.Dispose();
            //#endregion


            Console.ReadKey();
        }
    }
}
