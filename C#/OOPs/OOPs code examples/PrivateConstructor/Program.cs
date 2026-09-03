namespace PrivateConstructor
{
    internal class Program
    {
        //Private Constructor
        private Program()
        {
            Console.WriteLine("This is Private Constructor");
        }
        private Program(string message)
        {
            Console.WriteLine("Private Parameterized Constructor is Called");
        }
        public void Method1()
        {
            Console.WriteLine("Method1 is Called");
        }
        static void Main(string[] args)
        {
            //#region Createing object from private constructor
            ////Creating instance of Program class using Private Constructor
            //Program obj = new Program();
            //obj.Method1();
            //#endregion


            //#region Class with private and public constructor
            ////Creating instance of Test class using public Constructor
            //Test obj = new Test(10);
            //obj.Method1();
            //#endregion


            //#region Private Constructor Restricting Inheritance
            ////Creating instance of Child class
            //Child obj = new Child();
            //#endregion


            //#region Static class instantiation
            ////Cannot Create an instance of the Static class
            //Test test = new Test();

            //Console.WriteLine($"PI : {Test.PI}");
            //Console.WriteLine($"Square of 5 : {Test.GetSquare(5)}");
            //#endregion


            #region Private constructor overloading
            Program obj1 = new Program();
            Program obj2 = new Program("Hello");
            #endregion


            #region Singleton design pattern
            Singleton fromPlace1 = Singleton.GetSingletonInstance();
            fromPlace1.SomeMethod("From Place 1");
            Singleton fromPlace2 = Singleton.GetSingletonInstance();
            fromPlace2.SomeMethod("From Place 2");
            #endregion


            Console.ReadKey();
        }
    }
}
