namespace TakeWhileMethod
{
    internal class Program
    {
        //#region TakeWhile
        //static void Main(string[] args)
        //{
        //    //Data Source
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    //Fetch Numbers which are less than 6 using TakeWhile Method
        //    //Using Method Syntax
        //    List<int> ResultMS = numbers.TakeWhile(num => num < 6).ToList();

        //    //Using Query Syntax
        //    List<int> ResultQS = (from num in numbers
        //                          select num).TakeWhile(num => num < 6).ToList();

        //    //Accessing the Result using Foreach Loop
        //    foreach (var num in ResultMS)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Where method
        //static void Main(string[] args)
        //{
        //    Data Source
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    Fetch Numbers which are less than 6 using Where Method
        //    Using Method Syntax
        //    List<int> ResultMS = numbers.Where(num => num < 6).ToList();

        //    Using Query Syntax
        //    List<int> ResultQS = (from num in numbers
        //                          where num < 6
        //                          select num).ToList();

        //    Accessing the Result using Foreach Loop
        //    foreach (var num in ResultQS)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region TakeWhile vs Where
        //static void Main(string[] args)
        //{
        //    //Data Source: Numbers are Stored in Randon Order
        //    List<int> numbers = new List<int>() { 1, 2, 3, 6, 7, 8, 9, 10, 4, 5 };

        //    //Using TakeWhile Method to Fetch Numbers which are less than 6
        //    List<int> Result1 = numbers.TakeWhile(num => num < 6).ToList();

        //    Console.Write("Result Of TakeWhile Method: ");
        //    foreach (var num in Result1)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.WriteLine();

        //    //Using Where Method to Fetch Numbers which are less than 6
        //    List<int> Result2 = numbers.Where(num => num < 6).ToList();

        //    Console.Write("Result Of Where Method: ");
        //    foreach (var num in Result2)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region TakeWhile Method with String Collection
        //static void Main(string[] args)
        //{
        //    List<string> names = new List<string>() { "Sara", "Rahul", "John", "Pam", "Priyanka" };

        //    List<string> namesResult = names.TakeWhile(name => name.Length > 3).ToList();

        //    foreach (var name in namesResult)
        //    {
        //        Console.Write($"{name} ");
        //    }

        //    Console.ReadKey();
        //}
        //#endregion


        #region TakeWhile Method with Index as a Parameter
        static void Main(string[] args)
        {
            List<string> names = new List<string>() { "Sara", "Rahul", "John", "Pam", "Priyanka" };

            List<string> namesResult = names.TakeWhile((name, index) => name.Length > index).ToList();

            foreach (var name in namesResult)
            {
                Console.Write($"{name} ");
            }

            Console.ReadKey();
        }
        #endregion
    }
}
