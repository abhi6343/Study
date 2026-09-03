namespace ThenByandThenByDescending
{
    internal class Program
    {
        //#region ThenBy using method syntax
        //static void Main(string[] args)
        //{
        //    //Sorting the Student data by First Name and LastName in Descending order
        //    //Using Method Syntax
        //    var MS = Student.GetAllStudents()
        //              .OrderBy(x => x.FirstName)
        //              .ThenBy(y => y.LastName)
        //              .ToList();

        //    foreach (var student in MS)
        //    {
        //        Console.WriteLine("First Name :" + student.FirstName + ", Last Name :" + student.LastName);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region ThenBy using query syntax
        ////We do not have any operators called ThenBy and ThenByDescending, which we can use in the query syntax.
        ////So here, we need to specify multiple values or expressions in the order by clause separated by a comma
        //static void Main(string[] args)
        //{
        //    //Sorting the Student data by First Name and Last Name in Descending order
        //    //Using Query Syntax
        //    var QS = (from std in Student.GetAllStudents()
        //              orderby std.FirstName, std.LastName
        //              select std);

        //    foreach (var student in QS)
        //    {
        //        Console.WriteLine("First Name :" + student.FirstName + ", LastName :" + student.LastName);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Ascending and descending with multiple key values
        //static void Main(string[] args)
        //{
        //    //First Sort Students in Ascending Order Based on Branch
        //    //Then Sort Students in Descending Order Based on FirstName
        //    //Finally Sort Students in Ascending Order Based on LastName

        //    //Using Method Syntax
        //    var MS = Student.GetAllStudents()
        //              .OrderBy(x => x.Branch)
        //              .ThenByDescending(y => y.FirstName)
        //              .ThenBy(z => z.LastName)
        //              .ToList();

        //    //Using Query Syntax
        //    var QS = (from std in Student.GetAllStudents()
        //              orderby std.Branch ascending,
        //              std.FirstName descending,
        //              std.LastName //by default ascending
        //              select std).ToList();

        //    foreach (var student in QS)
        //    {
        //        Console.WriteLine("Barnch " + student.Branch + ", First Name : " + 
        //        student.FirstName + ", Last Name : " + student.LastName);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        #region ThenBy and ThenByDescending Method with Where Extension Method
        static void Main(string[] args)
        {
            //First, fetch only the CSE branch students
            //Sort the Students in ascending order based on First Name
            //Sort the students in descending order based on their Last Names

            //Using Method Syntax
            var MS = Student.GetAllStudents()
                     .Where(std => std.Branch == "CSE")
                     .OrderBy(x => x.FirstName)
                     .ThenByDescending(y => y.LastName)
                     .ToList();

            //Using Query Syntax
            var QS = (from std in Student.GetAllStudents()
                      where std.Branch == "CSE"
                      orderby std.FirstName, //By Default it is Ascending
                      std.LastName descending
                      select std).ToList();

            foreach (var student in QS)
            {
                Console.WriteLine("Barnch " + student.Branch + ", First Name : " +
                student.FirstName + ", Last Name : " + student.LastName);
            }
            Console.ReadKey();
        }
        #endregion
    }
}
