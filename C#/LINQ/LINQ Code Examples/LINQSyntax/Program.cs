namespace LINQSyntax
{
    internal class Program
    {
        #region Query syntax
        static void Main(string[] args)
        {
            //Step1: Data Source
            List<int> integerList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            //Step2: Query
            //LINQ Query using Query Syntax to fetch all numbers which are > 5
            //var QuerySyntax = from obj in integerList //Data Source
            //                  where obj > 5 //Condition
            //                  select obj; //Selection

            IEnumerable<int> QuerySyntax = from obj in integerList //Data Source
                              where obj > 5 //Condition
                              select obj; //Selection

            //Step3: Execution
            foreach (var item in QuerySyntax)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
        }
        #endregion


        //#region Method syntax
        //static void Main(string[] args)
        //{
        //    //Step1: Data Source
        //    List<int> integerList = new List<int>()
        //    {
        //        1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        //    };

        //    //Step2: Query
        //    //LINQ Query using Query Syntax to fetch all numbers which are > 5
        //    var QuerySyntax = integerList.Where(obj => obj > 5).ToList();

        //    //Step3: Execution
        //    foreach (var item in QuerySyntax)
        //    {
        //        Console.Write(item + " ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Mixed syntax
        //static void Main(string[] args)
        //{
        //    //Data Source
        //    List<int> integerList = new List<int>()
        //    {
        //        1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        //    };

        //    //LINQ Query using Mixed Syntax
        //    var MethodSyntax = (from obj in integerList
        //                        where obj > 5
        //                        select obj).Sum();

        //    //Execution
        //    Console.Write("Sum Is : " + MethodSyntax);
        //    Console.ReadKey();
        //}
        //#endregion
    }
}
