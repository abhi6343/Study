namespace OrderByDescending
{
    internal class Program
    {
        //#region OrderByDescending with value data type
        //static void Main(string[] args)
        //{
        //    List<int> intList = new List<int>() { 10, 45, 35, 29, 100, 69, 58, 50 };
        //    Console.WriteLine("Before Sorting the Data: ");
        //    foreach (var item in intList)
        //    {
        //        Console.Write(item + " ");
        //    }

        //    //Sorting the data in Descending Order Using Method Syntax
        //    var MS = intList.OrderByDescending(num => num);

        //    //Sorting the data in Descending Order Using Query Syntax
        //    var QS = (from num in intList
        //              orderby num descending
        //              select num).ToList();

        //    Console.WriteLine();
        //    Console.WriteLine("After Sorting the Data in Descending Order: ");
        //    foreach (var item in QS)
        //    {
        //        Console.Write(item + " ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region OrderByDescending with string data type
        //static void Main(string[] args)
        //{
        //    List<string> stringList = new List<string>() { "Preety", "Tiwary", "Priyanka", "Dewangan", "Hina", "Sharma" };
        //    Console.WriteLine("Before Sorting:");
        //    foreach (var item in stringList)
        //    {
        //        Console.Write(item + " ");
        //    }

        //    //Sorting in Descending Order Using Method Syntax
        //    var MS = stringList.OrderByDescending(name => name);

        //    //Sorting in Descending Order Using Query Syntax
        //    var QS = (from name in stringList
        //              orderby name descending
        //              select name).ToList();

        //    Console.WriteLine("\nAfter Sorting in Descending Order:");
        //    foreach (var item in MS)
        //    {
        //        Console.Write(item + " ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region OrderByDescending with complex data type
        //static void Main(string[] args)
        //{
        //    //Method Syntax
        //    var MS = Student.GetAllStudents().OrderByDescending(x => x.Branch);

        //    //Query Syntax
        //    var QS = (from std in Student.GetAllStudents()
        //              orderby std.Branch descending
        //              select std);
        //    foreach (var student in MS)
        //    {
        //        Console.WriteLine(" Branch: " + student.Branch + ", Name :" +
        //        student.FirstName + " " + student.LastName);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region OrderByDescending or sorting with filtering
        ////Use the Where method before the OrderBy method because it will filter and sort the filtered results
        //static void Main(string[] args)
        //{
        //    //Method Syntax
        //    var MS = Student.GetAllStudents()
        //             .Where(std => std.Branch.ToUpper() == "ETC")
        //             .OrderByDescending(x => x.FirstName).ToList();

        //    //Query Syntax
        //    var QS = (from std in Student.GetAllStudents()
        //              where std.Branch.ToUpper() == "ETC"
        //              orderby std.FirstName descending
        //              select std);

        //    foreach (var student in QS)
        //    {
        //        Console.WriteLine(" Branch: " + student.Branch + ", Name :" +
        //        student.FirstName + " " + student.LastName);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        #region OrderByDescending with custom comparer
        public static void Main()
        {
            CaseInsensitiveComparer caseInsensitiveComparer = new CaseInsensitiveComparer();
            string[] Alphabets = { "a", "b", "c", "A", "B", "C" };

            var SortedAlphabets = Alphabets.OrderByDescending(aplhabet => aplhabet, caseInsensitiveComparer);

            foreach (var item in SortedAlphabets)
            {
                Console.Write(item + " ");
            }
            Console.Read();
        }
        #endregion
    }
}
