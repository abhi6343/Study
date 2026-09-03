namespace Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //#region Interface
            //ImplementationClass1 obj1 = new ImplementationClass1();
            ////Using obj1 we can only call Add method
            //obj1.Add(10, 20);
            ////We cannot call Sub method
            ////obj1.Sub(100, 20);
            //ImplementationClass2 obj2 = new ImplementationClass2();
            ////Using obj2 we can call both Add and Sub method
            //obj2.Add(10, 20);
            //obj2.Sub(100, 20);
            //#endregion


            //#region Interface reference
            ////Creating Reference of an Interface point to the
            ////child class instance
            //ITestInterface1 obj = new ImplementationClass();
            ////Add method signature declared in ITestInterface1, so we can
            ////Invoke the Add method
            //obj.Add(10, 20);
            ////Sub method signature is not declared in ITestInterface1,
            ////so, we cannot Invoke the Sub method
            ////obj.Sub(100, 20);
            //#endregion


            #region Explicit Interface Implementation
            ImplementationClass obj1 = new ImplementationClass();
            //Using obj1 we can call the Add method directly because
            //It is implemented using public access specifier
            obj1.Add(10, 20);
            //We need to typecast obj1 to ITestInterface1 to call the Sub
            //method because Sub method is implemented using Interface name
            ((ITestInterface1)obj1).Sub(100, 20);
            //We can call the method directly using the interface reference
            //Typecasting is not required in this case
            ITestInterface1 obj2 = new ImplementationClass();
            obj2.Add(200, 50);
            obj2.Sub(200, 50);
            #endregion


            Console.ReadKey();
        }
    }
}
