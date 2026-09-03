using System.Linq;

namespace ReverseMethod
{
    internal class Program
    {
        //#region Reverse with primitive data type
        //static void Main(string[] args)
        //{
        //    int[] intArray = new int[] { 10, 30, 50, 40, 60, 20, 70, 100 };
        //    Console.WriteLine("Before Reverse the Data");
        //    foreach (var number in intArray)
        //    {
        //        Console.Write(number + " ");
        //    }
        //    Console.WriteLine();

        //    IEnumerable<int> ArrayReversedDataMS = intArray.Reverse();

        //    IEnumerable<int> ArrayReversedDataQS = (from num in intArray
        //                                          select num).Reverse();

        //    Console.WriteLine("After Reverse the Data");
        //    foreach (var number in ArrayReversedDataQS)
        //    {
        //        Console.Write(number + " ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region System.Collections.Generic Reverse Method
        //static void Main(string[] args)
        //{
        //    List<string> stringList = new List<string>() { "Preety", "Tiwary", "Priyanka", "Dewangan"};
        //    Console.WriteLine("Before Reverse the Data");
        //    foreach (var name in stringList)
        //    {
        //        Console.Write(name + " ");
        //    }
        //    Console.WriteLine();

        //    //You cannot store the data like below as this method belongs to
        //    //System.Collections.Generic namespace whose return type is void
        //    //IEnumerable<int> ArrayReversedData = stringList.Reverse();
        //    stringList.Reverse();

        //    Console.WriteLine("After Reverse the Data");
        //    foreach (var name in stringList)
        //    {
        //        Console.Write(name + " ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        #region Reverse Method on a Collection of List<T> Type
        static void Main(string[] args)
        {
            List<string> stringList = new List<string>() { "Preety", "Tiwary", "Priyanka", "Dewangan" };
            Console.WriteLine("Before Reverse the Data");
            foreach (var name in stringList)
            {
                Console.Write(name + " ");
            }
            Console.WriteLine();

            IEnumerable<string> ReverseData1 = stringList.AsEnumerable().Reverse();
            IQueryable<string> ReverseData2 = stringList.AsQueryable().Reverse();

            Console.WriteLine("After Reverse the Data");
            foreach (var name in ReverseData1)
            {
                Console.Write(name + " ");
            }
            Console.ReadKey();
        }
        #endregion
    }
}
