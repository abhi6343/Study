namespace PrivateConstructor
{
    internal class Test
    {
        //Private Constructor
        private Test()
        {
            Console.WriteLine("This is Private Constructor");
        }
        //Public Constructor
        public Test(int x)
        {
            Console.WriteLine("This is public Constructor");
        }
        public void Method1()
        {
            Console.WriteLine("Method1 is Called");
        }
    }


    //#region Static class
    //internal static class Test
    //{
    //    public static double PI = 3.14;
    //    public static int GetSquare(int x)
    //    {
    //        return x * x;
    //    }
    //}
    ////A class cannot Derive from a Static Class
    //internal class Child : Test
    //{
    //}
    //#endregion
}
