namespace TypesOfConstructors
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    //#region System defined default constructor
        //    //// Default means public and parameterless
        //    //Employee e1 = new Employee();
        //    //Console.WriteLine("Employee Id is: " + e1.Id);
        //    //Console.WriteLine("Employee Name is: " + e1.Name);
        //    //Console.WriteLine("Employee Age is: " + e1.Age);
        //    //Console.WriteLine("Employee Address is: " + e1.Address);
        //    //Console.WriteLine("Is Employee Permanent: " + e1.IsPermanent);
        //    //#endregion


        //    //#region User defined default constructor
        //    //Employee e2 = new Employee();
        //    //e2.Display();
        //    //#endregion


        //    //#region Same values for each object of default constructor
        //    //Employee e1 = new Employee();
        //    //e1.Display();
        //    //Employee e2 = new Employee();
        //    //Console.WriteLine();
        //    //e2.Display();
        //    //#endregion


        //    //#region Parameterized constructor
        //    //ParameterizedConstructor obj = new ParameterizedConstructor(10);
        //    //obj.Display();
        //    //ParameterizedConstructor obj2 = new ParameterizedConstructor(20);
        //    //obj2.Display();
        //    //#endregion


        //    //#region Copy constructor
        //    //CopyConstructor obj1 = new CopyConstructor(10);
        //    //obj1.Display();
        //    //CopyConstructor obj2 = new CopyConstructor(obj1);
        //    //obj2.Display();
        //    //#endregion

            
        //    Console.ReadKey();            
        //}


        //#region Static Constructor of Program class
        ////First static constructor will execute then Main method
        //static Program()
        //{
        //    Console.WriteLine("Static Constructor Executed!");
        //}
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Main Method Exceution Started...");
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Private constructor
        //private Program()
        //{
        //    Console.WriteLine("This is private constructor");
        //}
        //static void Main(string[] args)
        //{
        //    Program p = new Program();
        //    Console.WriteLine("Main method");
        //    Console.ReadKey();
        //}
        //#endregion
    }
}
