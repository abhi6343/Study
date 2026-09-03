namespace GarbageCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 1000000; i++)
            {
                MyClass1 obj1 = new MyClass1();
                MyClass2 obj2 = new MyClass2();
                MyClass3 obj3 = new MyClass3();
            }


            //#region Finalize Dispose pattern
            //for (int i = 0; i <= 1000000; i++)
            //{
            //    MyClass1 obj1 = new MyClass1();
            //    obj1.Dispose();
            //    MyClass2 obj2 = new MyClass2();
            //    obj2.Dispose();
            //    MyClass3 obj3 = new MyClass3();
            //    obj3.Dispose();
            //}
            //#endregion
            Console.Read();
        }
    }
}
