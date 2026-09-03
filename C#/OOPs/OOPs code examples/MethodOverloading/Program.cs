namespace MethodOverloading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //#region Method overloading
            //Program obj = new Program();
            //obj.Method(); //Invoke the 1st Method
            //obj.Method(10); //Invoke the 2nd Method
            //obj.Method("Hello"); //Invoke the 3rd Method
            //obj.Method(10, "Hello"); //Invoke the 4th Method
            //obj.Method("Hello", 10); //Invoke the 5th Method
            //#endregion


            #region Inheritance based method overloading
            Class2 obj = new Class2();
            obj.Add(10, 20);
            obj.Add(10.5f, 20.7f);
            obj.Add("Pranaya", "Rout");
            #endregion


            #region Constructor overloading
            ConstructorOverloading obj1 = new ConstructorOverloading(10);
            obj1.Display();
            ConstructorOverloading obj2 = new ConstructorOverloading(10, 20);
            obj2.Display();
            ConstructorOverloading obj3 = new ConstructorOverloading(10, 20, 3);
            obj3.Display();
            #endregion


            #region Real time example
            string ClassName = "Program";
            string MethodName = "Main";
            string UniqueId = Guid.NewGuid().ToString();
            Logger.Log(ClassName, MethodName, "Message 1");
            Logger.Log(UniqueId, ClassName, MethodName, "Message 2");
            Logger.Log("Message 3");
            try
            {
                int Num1 = 10, Num2 = 0;
                int result = Num1 / Num2;
                Logger.Log(UniqueId, ClassName, MethodName, "Message 4");
            }
            catch (Exception ex)
            {
                Logger.Log(ClassName, MethodName, ex);
            }
            #endregion


            Console.ReadKey();
        }
        public void Method()
        {
            Console.WriteLine("1st Method");
        }
        public void Method(int i)
        {
            Console.WriteLine("2nd Method");
        }
        public void Method(string s)
        {
            Console.WriteLine("3rd Method");
        }
        public void Method(int i, string s)
        {
            Console.WriteLine("4th Method");
        }
        public void Method(string s, int i)
        {
            Console.WriteLine("5th Method");
        }
    }
}
