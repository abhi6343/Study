namespace SkipWhileMethod
{
    internal class Program
    {
        //#region SkipWhile
        //static void Main(string[] args)
        //{
        //    //Data Source
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    //Skip Numbers which are less than 5 using SkipWhile Method
        //    //Using Method Syntax
        //    List<int> ResultMS = numbers.SkipWhile(num => num < 5).ToList();

        //    //Using Query Syntax
        //    List<int> ResultQS = (from num in numbers
        //                          select num).SkipWhile(num => num < 5).ToList();

        //    //Accessing the Result using Foreach Loop
        //    foreach (var num in ResultMS)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region SkipWhile with elements reordered
        //static void Main(string[] args)
        //{
        //    List<int> numbers = new List<int>() { 1, 4, 5, 6, 7, 8, 9, 10, 2, 3 };

        //    List<int> ResultMS = numbers.SkipWhile(num => num < 5).ToList();

        //    foreach (var num in ResultMS)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region SkipWhile with string
        //static void Main(string[] args)
        //{
        //    List<string> names = new List<string>() { "Pam", "Rahul", "Kim", "Sara", "Priyanka" };

        //    List<string> namesResult = names.SkipWhile(name => name.Length < 4).ToList();

        //    foreach (var name in namesResult)
        //    {
        //        Console.Write($"{name} ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        #region Using index
        static void Main(string[] args)
        {
            List<string> names = new List<string>() { "Sara", "Rahul", "John", "Pam", "Priyanka" };

            List<string> namesResult = names.SkipWhile((name, index) => name.Length > index).ToList();

            foreach (var name in namesResult)
            {
                Console.Write($"{name} ");
            }

            Console.ReadKey();
        }
        #endregion
    }
}
