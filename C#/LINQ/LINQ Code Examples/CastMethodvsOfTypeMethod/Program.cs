using System.Collections;

namespace CastMethodvsOfTypeMethod
{
    internal class Program
    {
        //#region CastMethod
        //public static void Main()
        //{
        //    ArrayList list = new ArrayList { 10, 20, 30, "50" };

        //    IEnumerable<int> result = list.Cast<int>();

        //    foreach (int i in result)
        //    {
        //        Console.WriteLine(i);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        #region OfType method
        public static void Main()
        {
            ArrayList list = new ArrayList { 10, 20, 30, "50" };

            IEnumerable<int> result = list.OfType<int>();

            foreach (int i in result)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
        #endregion
    }
}
