namespace GenericDelegates
{
    internal class Program
    {
        //#region Custom delegate
        //public delegate double AddNumber1Delegate(int no1, float no2, double no3);
        //public delegate void AddNumber2Delegate(int no1, float no2, double no3);
        //public delegate bool CheckLengthDelegate(string name);
        //static void Main(string[] args)
        //{
        //    AddNumber1Delegate obj1 = new AddNumber1Delegate(AddNumber1);
        //    double Result = obj1.Invoke(100, 125.45f, 456.789);
        //    Console.WriteLine(Result);
        //    AddNumber2Delegate obj2 = new AddNumber2Delegate(AddNumber2);
        //    obj2.Invoke(50, 255.45f, 123.456);
        //    CheckLengthDelegate obj3 = new CheckLengthDelegate(CheckLength);
        //    bool Status = obj3.Invoke("Pranaya");
        //    Console.WriteLine(Status);
        //    Console.ReadKey();
        //}
        //public static double AddNumber1(int no1, float no2, double no3)
        //{
        //    return no1 + no2 + no3;
        //}
        //public static void AddNumber2(int no1, float no2, double no3)
        //{
        //    Console.WriteLine(no1 + no2 + no3);
        //}
        //public static bool CheckLength(string name)
        //{
        //    if (name.Length > 5)
        //        return true;
        //    return false;
        //}
        //#endregion


        //#region Generic delegates
        //static void Main(string[] args)
        //{
        //    Func<int, float, double, double> obj1 = new Func<int, float, double, double>(AddNumber1);
        //    double Result = obj1.Invoke(100, 125.45f, 456.789);
        //    Console.WriteLine(Result);
        //    Action<int, float, double> obj2 = new Action<int, float, double>(AddNumber2);
        //    obj2.Invoke(50, 255.45f, 123.456);
        //    Predicate<string> obj3 = new Predicate<string>(CheckLength);
        //    bool Status = obj3.Invoke("Pranaya");
        //    Console.WriteLine(Status);
        //    Console.ReadKey();
        //}
        //public static double AddNumber1(int no1, float no2, double no3)
        //{
        //    return no1 + no2 + no3;
        //}
        //public static void AddNumber2(int no1, float no2, double no3)
        //{
        //    Console.WriteLine(no1 + no2 + no3);
        //}
        //public static bool CheckLength(string name)
        //{
        //    if (name.Length > 5)
        //        return true;
        //    return false;
        //}
        //#endregion


        #region Generic delegates with lambda function
        static void Main(string[] args)
        {
            Func<int, float, double, double> obj1 = (x, y, z) =>
            {
                return x + y + z;
            };
            double Result = obj1.Invoke(100, 125.45f, 456.789);
            Console.WriteLine(Result);
            Action<int, float, double> obj2 = (x, y, z) =>
            {
                Console.WriteLine(x + y + z);
            };
            obj2.Invoke(50, 255.45f, 123.456);
            Predicate<string> obj3 = new Predicate<string>(CheckLength);
            bool Status = obj3.Invoke("Pranaya");
            Console.WriteLine(Status);
            Console.ReadKey();
        }
        public static bool CheckLength(string name)
        {
            if (name.Length > 5)
                return true;
            return false;
        }
        #endregion
    }
}
