namespace Constructors
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            //#region Implicit constructor
            //Test obj = new Test();
            //Console.WriteLine($"i = {obj.i}");
            //Console.WriteLine($"b = {obj.b}");
            ////value null will be printed, so here we checking the null
            //if (obj.s == null)
            //{
            //    Console.WriteLine("s = null");
            //}
            //#endregion


            #region Explicit constructor
            ExplicitConstructor obj = new ExplicitConstructor();

            ExplicitConstructor obj1 = new();
            ExplicitConstructor obj2 = new();
            ExplicitConstructor obj3 = new();
            ExplicitConstructor obj4 = new ExplicitConstructor();
            #endregion


            Console.ReadKey();
        }        
    }
}
