namespace Rangemethod
{
    internal class Program
    {
        //#region Range
        //static void Main(string[] args)
        //{
        //    //Generating Intger Numbers from 1 to 10
        //    IEnumerable<int> numberSequence = Enumerable.Range(1, 10);

        //    //Accessing the numberSequence using Foreach Loop
        //    foreach (int num in numberSequence)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Range with Where
        //static void Main(string[] args)
        //{
        //    //Using Range with Where Extension Method
        //    IEnumerable<int> EvenNumbers = Enumerable.Range(10, 30).Where(x => x % 2 == 0);

        //    //Printing the Even Numbers between 10 and 40
        //    foreach (int num in EvenNumbers)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Range with Select
        //static void Main(string[] args)
        //{
        //    IEnumerable<int> EvenNumbers = Enumerable.Range(1, 5).Select(x => x * x);

        //    foreach (int num in EvenNumbers)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Range with string type
        //static void Main(string[] args)
        //{
        //    IEnumerable<string> rangewithString = Enumerable.Range(1, 5).Select(x => (x * x) + " " + CustomLogic(x)).ToArray();

        //    foreach (var item in rangewithString)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.ReadKey();
        //}
        //private static string CustomLogic(int x)
        //{
        //    string result = string.Empty;
        //    switch (x)
        //    {
        //        case 1:
        //            result = "1st";
        //            break;
        //        case 2:
        //            result = "2nd";
        //            break;
        //        case 3:
        //            result = "3rd";
        //            break;
        //        case 4:
        //            result = "4th";
        //            break;
        //        case 5:
        //            result = "5th";
        //            break;
        //    }
        //    return result;
        //}
        //#endregion


        #region Range in combination with Select to create a sequence of dates
        static void Main()
        {
            DateTime startDate = new DateTime(2021, 1, 1);
            int daysToGenerate = 10;
            var dateSequence = Enumerable.Range(0, daysToGenerate)
                                         .Select(offset => startDate.AddDays(offset));

            foreach (var date in dateSequence)
            {
                Console.WriteLine(date.ToShortDateString());
            }

            Console.ReadKey();
        }
        #endregion
    }
}
