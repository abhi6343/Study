using System.Runtime.InteropServices;

namespace OptionalParameters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ADDNumbers(10, 20);
            ADDNumbers(10, 20, 30, 40);
            ADDNumbers(10, 20, new object[] { 30, 40, 50 });


            ADDNumbers(10, 20);
            ADDNumbers(10, 20, new int[] { 30, 40, 50 });


            //Adding two Integer Numbers
            ADDNumbers(10, 20);
            //Adding Five Integer Numbers
            ADDNumbers(10, 20, new int[] { 30, 40, 50 });


            //Using Named Parameter while calling Method
            Test(1, 2); //a = 1 and b = 2 and c = 20 by default value
            Test(1, c: 2); //a = 1 and b = 10 by default and c = 2
            //Order is not Important with Named Parameter
            Test(b: 1, c: 2, a: 10);


            ADDNumbers(10, 20);
            ADDNumbers(10, 20, new int[] { 30, 40, 50 });


            Console.ReadLine();
        }
        public static void ADDNumbers(int FN, int SN, params object[] restOfTheNumbers)
        {
            int result = FN + SN;
            foreach (int i in restOfTheNumbers)
            {
                result += i;
            }
            Console.WriteLine("Total = " + result.ToString());
        }
        //public static void ADDNumbers(int FN, int SN, int[] restOfTheNumbers)
        //{
        //    int result = FN + SN;
        //    foreach (int i in restOfTheNumbers)
        //    {
        //        result += i;
        //    }
        //    Console.WriteLine("Total = " + result.ToString());
        //}
        public static void ADDNumbers(int FN, int SN)
        {
            int result = FN + SN;
            Console.WriteLine("Total = " + result.ToString());
        }

        //#region Specifying Parameter Defaults
        //public static void ADDNumbers(int FN, int SN, int[] restOfTheNumbers = null)
        //{
        //    int result = FN + SN;
        //    //Loop through the restOfTheNumbers only if it is not null
        //    //else we will get runtime error
        //    if (restOfTheNumbers != null)
        //    {
        //        foreach (int i in restOfTheNumbers)
        //        {
        //            result += i;
        //        }
        //    }
        //    Console.WriteLine("Total = " + result.ToString());
        //}
        //#endregion


        #region Named parameters
        public static void Test(int a, int b = 10, int c = 20)
        {
            Console.WriteLine($"a = {a}, b = {b}, c= {c}");
        }
        #endregion

        #region Optional attribute
        public static void ADDNumbers(int FN, int SN, [Optional] int[] restOfTheNumbers)
        {
            int result = FN + SN;
            // loop thru restOfTheNumbers only if it is not null otherwise 
            // you will get a null reference exception
            if (restOfTheNumbers != null)
            {
                foreach (int i in restOfTheNumbers)
                {
                    result += i;
                }
            }
            Console.WriteLine("Total = " + result.ToString());
        }
        #endregion
    }
}