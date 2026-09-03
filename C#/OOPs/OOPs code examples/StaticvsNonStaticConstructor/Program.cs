namespace StaticvsNonStaticConstructor
{
    internal class Program
    {
        //Main Method is the Entry Point for our Application Execution
        static void Main(string[] args)
        {
            #region Access class static variable
            Console.WriteLine("Main Method Started");

            //As soon as it finds ConstructorsDemo.x, 
            //it will first execute the static constructor of the class
            Console.WriteLine(ConstructorsDemo.x);

            Console.WriteLine("Main Method Completed");
            #endregion


            //#region Creating instance of class having static constructor
            //Console.WriteLine("Main Method Started");
            ////Before Executing the non-static constructor
            ////it will first execute the static constructor of the class
            //ConstructorsDemo obj1 = new ConstructorsDemo();

            ////Now, onwards it will not execute the static constructor,
            ////Because static constructor executed only once
            //ConstructorsDemo obj2 = new ConstructorsDemo();
            //ConstructorsDemo obj3 = new ConstructorsDemo();

            //Console.WriteLine("Main Method Completed");
            //#endregion


            #region 

            #endregion


            Console.ReadKey();
        }
    }
}
