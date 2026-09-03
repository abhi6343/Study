using System.Collections;

namespace CastMethod
{
    internal class Program
    {
        //#region Cast
        //public static void Main()
        //{
        //    ArrayList list = new ArrayList { 10, 20, 30 };

        //    IEnumerable<int> result = list.Cast<int>();

        //    foreach (int i in result)
        //    {
        //        Console.WriteLine(i);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Invalid cast
        //public static void Main()
        //{
        //    ArrayList list = new ArrayList { 10, 20, 30, };
        //    //The following statement throws System.InvalidCastException
        //    list.Add("40");

        //    IEnumerable<int> result = list.Cast<int>();

        //    foreach (int i in result)
        //    {
        //        Console.WriteLine(i);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        #region Data source null
        public static void Main()
        {
            ArrayList list = null;
            //Throws System.ArgumentNullException
            IEnumerable<int> result = list.Cast<int>();

            foreach (int i in result)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
        #endregion
    }
}
