namespace SelectManyProjectionMethod
{
    internal class Program
    {
        //#region SelectMany method
        //static void Main(string[] args)
        //{
        //    List<string> nameList = new List<string>() { "Pranaya", "Kumar" };

        //    IEnumerable<char> methodSyntax = nameList.SelectMany(x => x);
        //    foreach (char c in methodSyntax)
        //    {
        //        Console.Write(c + " ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Achieve SelectMany through multiple from clause
        //static void Main(string[] args)
        //{
        //    List<string> nameList = new List<string>() { "Pranaya", "Kumar" };

        //    IEnumerable<char> querySyntax = from str in nameList
        //                                    from ch in str
        //                                    select ch;
        //    foreach (char c in querySyntax)
        //    {
        //        Console.Write(c + " ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region SelectMany projection method with complex data type
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    List<string> MethodSyntax = Student.GetStudents().SelectMany(std => std.Programming).ToList();

        //    //Using Query Syntax
        //    IEnumerable<string> QuerySyntax = from std in Student.GetStudents()
        //                                      from program in std.Programming
        //                                      select program;
        //    //Printing the values
        //    foreach (string program in MethodSyntax)
        //    {
        //        Console.WriteLine(program);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Remove duplicate while using SelectMany
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    List<string> MethodSyntax = Student.GetStudents()
        //                                .SelectMany(std => std.Programming)
        //                                .Distinct()
        //                                .ToList();

        //    //Using Query Syntax
        //    IEnumerable<string> QuerySyntax = (from std in Student.GetStudents()
        //                                       from program in std.Programming
        //                                       select program).Distinct().ToList();
        //    //Printing the values
        //    foreach (string program in QuerySyntax)
        //    {
        //        Console.WriteLine(program);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        #region Complete example of SlectMany
        static void Main(string[] args)
        {
            //Using Method Syntax
            var MethodSyntax = Student.GetStudents()
                               .SelectMany(std => std.Programming,
                               (student, program) => new
                               {
                                   StudentName = student.Name,
                                   ProgramName = program
                               }
                               )
                               .ToList();

            //Using Query Syntax
            var QuerySyntax = (from std in Student.GetStudents()
                               from program in std.Programming
                               select new
                               {
                                   StudentName = std.Name,
                                   ProgramName = program
                               }).ToList();
            //Printing the values
            foreach (var item in QuerySyntax)
            {
                Console.WriteLine(item.StudentName + " => " + item.ProgramName);
            }
            Console.ReadKey();
        }
        #endregion
    }
}
