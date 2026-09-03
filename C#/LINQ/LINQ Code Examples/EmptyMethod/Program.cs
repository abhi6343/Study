namespace EmptyMethod
{
    internal class Program
    {
        //#region Empty
        //static void Main(string[] args)
        //{
        //    //Creating Empty Collection of Strings
        //    IEnumerable<string> emptyCollection1 = Enumerable.Empty<string>();

        //    //Creating Empty Collection of Student
        //    IEnumerable<Student> emptyCollection2 = Enumerable.Empty<Student>();

        //    //Printing the Type and Count of emptyCollection1
        //    Console.WriteLine("Count: {0} ", emptyCollection1.Count());
        //    Console.WriteLine("Type: {0} ", emptyCollection1.GetType().Name);

        //    //Printing the Type and Count of emptyCollection2
        //    Console.WriteLine("Count: {0} ", emptyCollection2.Count());
        //    Console.WriteLine("Type: {0} ", emptyCollection2.GetType().Name);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Why Empty method
        //static void Main(string[] args)
        //{
        //    //GetData() Method Returning Null
        //    IEnumerable<int> integerSequence = GetData();

        //    //The forloop will throw NullReferenceException
        //    foreach (var num in integerSequence)
        //    {
        //        Console.WriteLine(num);
        //    }
        //    Console.ReadKey();
        //}
        //private static IEnumerable<int> GetData()
        //{
        //    return null;
        //}
        //#endregion


        //#region Checking Null Before using inside the Loop
        //static void Main(string[] args)
        //{
        //    IEnumerable<int> integerSequence = GetData();

        //    if (integerSequence != null)
        //    {
        //        foreach (var num in integerSequence)
        //        {
        //            Console.WriteLine(num);
        //        }
        //    }
        //    Console.ReadKey();
        //}
        //private static IEnumerable<int> GetData()
        //{
        //    return null;
        //}
        //#endregion


        #region Using the Empty Method
        static void Main(string[] args)
        {
            IEnumerable<int> integerSequence = GetData() ?? Enumerable.Empty<int>();

            foreach (var num in integerSequence)
            {
                Console.WriteLine(num);
            }
            Console.ReadKey();
        }
        private static IEnumerable<int> GetData()
        {
            return null;
        }
        #endregion
    }
}
