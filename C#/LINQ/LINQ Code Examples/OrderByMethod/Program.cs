namespace OrderByMethod
{
    internal class Program
    {
        //#region OrderBy with value data type
        //static void Main(string[] args)
        //{
        //    List<int> intList = new List<int>() { 10, 45, 35, 29, 100, 69, 58, 50 };
        //    Console.WriteLine("Before Sorting : ");
        //    foreach (var item in intList)
        //    {
        //        Console.Write(item + " ");
        //    }

        //    //Sorting the data in Ascending Order
        //    //Using Method Syntax
        //    var MS = intList.OrderBy(num => num);

        //    //Using Query Syntax
        //    var QS = (from num in intList
        //              orderby num
        //              select num).ToList();

        //    Console.WriteLine();
        //    Console.WriteLine("After Sorting : ");
        //    foreach (var item in QS)
        //    {
        //        Console.Write(item + " ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region OrderBy with string
        //static void Main(string[] args)
        //{
        //    List<string> stringList = new List<string>() { "Preety", "Tiwary", "Agrawal", "Priyanka", 
        //                                    "Dewangan", "Hina","Kumar","Manoj", "Rout", "James"};

        //    //Using Method Syntax
        //    var MS = stringList.OrderBy(name => name);

        //    //Using Query Syntax
        //    var QS = (from name in stringList
        //              orderby name ascending
        //              select name).ToList();

        //    foreach (var item in MS)
        //    {
        //        Console.WriteLine(item + " ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region OrderBy with complex data type
        //static void Main(string[] args)
        //{
        //    //Method Syntax
        //    var MS = Student.GetAllStudents().OrderBy(x => x.Branch).ToList();

        //    //Query Syntax
        //    var QS = (from std in Student.GetAllStudents()
        //              orderby std.Branch
        //              select std);

        //    foreach (var student in MS)
        //    {
        //        Console.WriteLine(" Branch: " + student.Branch + ", Name :" +
        //                            student.FirstName + " " + student.LastName);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region OrderBy or sorting with filtering
        ////Use the Where method before the OrderBy method because it will filter and sort the filtered results
        //static void Main(string[] args)
        //{
        //    //Method Syntax
        //    var MS = Student.GetAllStudents()
        //    .Where(std => std.Branch.ToUpper() == "CSE")
        //    .OrderBy(x => x.FirstName).ToList();

        //    //Query Syntax
        //    var QS = (from std in Student.GetAllStudents()
        //              where std.Branch.ToUpper() == "CSE"
        //              orderby std.FirstName
        //              select std);

        //    foreach (var student in QS)
        //    {
        //        Console.WriteLine(" Branch: " + student.Branch + ", Name :" +
        //                            student.FirstName + " " + student.LastName);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        #region OrderBy with custom comparer
        public static void Main()
        {
            CaseInsensitiveComparer caseInsensitiveComparer = new CaseInsensitiveComparer();

            string[] Alphabets = { "a", "b", "c", "A", "B", "C" };

            var SortedAlphabets = Alphabets.OrderBy(aplhabet => aplhabet, caseInsensitiveComparer);

            foreach (var item in SortedAlphabets)
            {
                Console.Write(item + " ");
            }
            Console.Read();
        }
        #endregion
    }
}
