namespace WhyWeNeedConstructor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            First f1 = new First();
            First f2 = new First();
            First f3 = new First();
            Console.WriteLine($"{f1.x} {f2.x} {f3.x}");

            //#region Default constructor
            //Second s1 = new Second();
            //Second s2 = new Second();
            //Second s3 = new Second();
            //Console.WriteLine($"{s1.x} {s2.x} {s3.x}");
            //#endregion


            //#region Parameterized constructor
            //Second s1 = new Second(100); //100 wll send to local variable x
            //Second s2 = new Second(200); //200 wll send to local variable x
            //Second s3 = new Second(300); //300 wll send to local variable x
            //Console.WriteLine($"{s1.x} {s2.x} {s3.x}");
            //#endregion


            //#region Parameterized Constructor Real-time Example
            //Employee e1 = new Employee(101, 30, "Pranaya", "Mumbai", true);
            //e1.Display();
            //Console.WriteLine();
            //Employee e2 = new Employee(101, 28, "Rout", "BBSR", false);
            //e2.Display();
            //#endregion


            //#region Copy Constructor Real-time Example
            //Employee e1 = new Employee(101, 30, "Pranaya", "Mumbai", true);
            //e1.Display();
            //Console.WriteLine();
            //Employee e2 = new Employee(e1);
            //e2.Display();
            //Console.ReadKey();
            //#endregion


            #region
            Example e1 = new Example();
            e1.Increment();
            e1.Display();
            e1.Increment();
            e1.Display();

            Example e2 = new Example();
            e2.Increment();
            e2.Display();
            e2.Increment();
            e2.Display();
            #endregion

            Console.ReadKey();
        }
    }
}
