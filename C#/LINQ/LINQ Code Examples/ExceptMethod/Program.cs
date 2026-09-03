namespace ExceptMethod
{
    internal class Program
    {
        //#region Except method
        //static void Main(string[] args)
        //{
        //    List<int> dataSource1 = new List<int>() { 1, 2, 3, 4, 5, 6 };
        //    List<int> dataSource2 = new List<int>() { 1, 3, 5, 8, 9, 10 };

        //    //Method Syntax
        //    var MS = dataSource1.Except(dataSource2).ToList();

        //    //Query Syntax
        //    var QS = (from num in dataSource1
        //              select num)
        //              .Except(dataSource2).ToList(); 

        //    foreach (var item in QS)
        //    {
        //        Console.Write(item + " ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region if any of the Sequences is Null
        //static void Main(string[] args)
        //{
        //    List<int> dataSource1 = new List<int>() { 1, 2, 3, 4, 5, 6 };
        //    List<int> dataSource2 = null;

        //    //Method Syntax
        //    var MS = dataSource1.Except(dataSource2).ToList();
        //    foreach (var item in MS)
        //    {
        //        Console.Write(item + " ");
        //    }
        //    Console.ReadKey();
        //}
        //    #endregion


        //#region Except method with string
        //static void Main(string[] args)
        //{
        //    string[] dataSource1 = { "India", "USA", "UK", "Canada", "Srilanka" };
        //    string[] dataSource2 = { "India", "uk", "Canada", "France", "Japan" };

        //    //Method Syntax
        //    var MS = dataSource1.Except(dataSource2).ToList();

        //    //Query Syntax
        //    var QS = (from country in dataSource1
        //              select country)
        //              .Except(dataSource2).ToList();
        //    foreach (var item in QS)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Except with IEqualityComparer for string values
        //static void Main(string[] args)
        //{
        //    string[] dataSource1 = { "India", "USA", "UK", "Canada", "Srilanka" };
        //    string[] dataSource2 = { "India", "uk", "Canada", "France", "Japan" };

        //    //Method Syntax
        //    var MS = dataSource1.Except(dataSource2, StringComparer.OrdinalIgnoreCase).ToList();

        //    //Query Syntax
        //    var QS = (from country in dataSource1
        //              select country)
        //              .Except(dataSource2, StringComparer.OrdinalIgnoreCase).ToList();

        //    foreach (var item in MS)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Except with complex data type
        //static void Main(string[] args)
        //{
        //    List<Student> AllStudents = new List<Student>()
        //    {   
        //        new Student {ID = 101, Name = "Preety" },
        //        new Student {ID = 102, Name = "Sambit" },
        //        new Student {ID = 103, Name = "Hina"},
        //        new Student {ID = 104, Name = "Anurag"},
        //        new Student {ID = 105, Name = "Pranaya"},
        //        new Student {ID = 106, Name = "Santosh"},
        //    };
        //    List<Student> Class6Students = new List<Student>()
        //    {
        //        new Student {ID = 102, Name = "Sambit" },
        //        new Student {ID = 104, Name = "Anurag"},
        //        new Student {ID = 105, Name = "Pranaya"},
        //    };

        //    //Method Syntax
        //    var MS = AllStudents.Select(x => x.Name).Except(Class6Students.Select(y => y.Name)).ToList();

        //    //Query Syntax
        //    var QS = (from std in AllStudents
        //              select std.Name).Except(Class6Students.Select(y => y.Name)).ToList();
        //    foreach (var name in MS)
        //    {
        //        Console.WriteLine(name);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Problem with Default Comparer
        //static void Main(string[] args)
        //{
        //    List<Student> AllStudents = new List<Student>()
        //    {
        //        new Student { ID = 101, Name = "Preety" },
        //        new Student { ID = 102, Name = "Sambit" },
        //        new Student { ID = 103, Name = "Hina" },
        //        new Student { ID = 104, Name = "Anurag" },
        //        new Student { ID = 105, Name = "Pranaya" },
        //        new Student { ID = 106, Name = "Santosh" },
        //    };
        //    List<Student> Class6Students = new List<Student>()
        //    {
        //        new Student {ID = 102, Name = "Sambit" },
        //        new Student {ID = 104, Name = "Anurag"},
        //        new Student {ID = 105, Name = "Pranaya"},
        //    };

        //    //Method Syntax
        //    var MS = AllStudents.Except(Class6Students).ToList();

        //    //Query Syntax
        //    var QS = (from std in AllStudents
        //              select std).Except(Class6Students).ToList();

        //    foreach (var student in MS)
        //    {
        //        Console.WriteLine($" ID : {student.ID} Name : {student.Name}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Using anaonymous type
        ////Annonymous Type already overrides the Equals() and GetHashCode() methods of the Object Class.
        //static void Main(string[] args)
        //{
        //    List<Student> AllStudents = new List<Student>()
        //    {
        //        new Student {ID = 101, Name = "Preety" },
        //        new Student {ID = 102, Name = "Sambit" },
        //        new Student {ID = 103, Name = "Hina"},
        //        new Student {ID = 104, Name = "Anurag"},
        //        new Student {ID = 105, Name = "Pranaya"},
        //        new Student {ID = 106, Name = "Santosh"},
        //    };
        //    List<Student> Class6Students = new List<Student>()
        //    {
        //        new Student {ID = 102, Name = "Sambit" },
        //        new Student {ID = 104, Name = "Anurag"},
        //        new Student {ID = 105, Name = "Pranaya"},
        //    };

        //    //Method Syntax
        //    var MS = AllStudents.Select(x => new { x.ID, x.Name })
        //             .Except(Class6Students.Select(x => new { x.ID, x.Name })).ToList();

        //    //Query Syntax
        //    var QS = (from std in AllStudents
        //             select new { std.ID, std.Name })
        //             .Except(Class6Students.Select(x => new { x.ID, x.Name })).ToList();
        //    foreach (var student in QS)
        //    {
        //        Console.WriteLine($" ID : {student.ID} Name : {student.Name}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Write class that implements IEqualityComparer interface
        //static void Main(string[] args)
        //{
        //    List<Student> AllStudents = new List<Student>()
        //    {
        //        new Student {ID = 101, Name = "Preety" },
        //        new Student {ID = 102, Name = "Sambit" },
        //        new Student {ID = 103, Name = "Hina"},
        //        new Student {ID = 104, Name = "Anurag"},
        //        new Student {ID = 105, Name = "Pranaya"},
        //        new Student {ID = 106, Name = "Santosh"},
        //    };
        //    List<Student> Class6Students = new List<Student>()
        //    {
        //        new Student {ID = 102, Name = "Sambit" },
        //        new Student {ID = 104, Name = "Anurag"},
        //        new Student {ID = 105, Name = "Pranaya"},
        //    };

        //    //Create an instance of StudentComparer
        //    StudentComparer studentComparer = new StudentComparer();

        //    //Method Syntax
        //    var MS = AllStudents
        //             .Except(Class6Students, studentComparer).ToList();

        //    //Query Syntax
        //    var QS = (from std in AllStudents
        //              select std)
        //             .Except(Class6Students, studentComparer).ToList();

        //    foreach (var student in MS)
        //    {
        //        Console.WriteLine($" ID : {student.ID} Name : {student.Name}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Approach 2: Overriding Equals() and GetHashCode() Methods within the Student Class
        //static void Main(string[] args)
        //{
        //    List<Student> AllStudents = new List<Student>()
        //    {
        //        new Student {ID = 101, Name = "Preety" },
        //        new Student {ID = 102, Name = "Sambit" },
        //        new Student {ID = 103, Name = "Hina"},
        //        new Student {ID = 104, Name = "Anurag"},
        //        new Student {ID = 105, Name = "Pranaya"},
        //        new Student {ID = 106, Name = "Santosh"},
        //    };
        //    List<Student> Class6Students = new List<Student>()
        //    {
        //        new Student {ID = 102, Name = "Sambit" },
        //        new Student {ID = 104, Name = "Anurag"},
        //        new Student {ID = 105, Name = "Pranaya"},
        //    };

        //    //Method Syntax
        //    var MS = AllStudents
        //             .Except(Class6Students).ToList();

        //    //Query Syntax
        //    var QS = (from std in AllStudents
        //              select std)
        //              .Except(Class6Students).ToList();

        //    foreach (var student in QS)
        //    {
        //        Console.WriteLine($" ID : {student.ID} Name : {student.Name}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        #region Implementing IEquatble<T> Interface in Student Class
        static void Main(string[] args)
        {
            List<Student> AllStudents = new List<Student>()
            {
                new Student {ID = 101, Name = "Preety" },
                new Student {ID = 102, Name = "Sambit" },
                new Student {ID = 103, Name = "Hina"},
                new Student {ID = 104, Name = "Anurag"},
                new Student {ID = 105, Name = "Pranaya"},
                new Student {ID = 106, Name = "Santosh"},
            };
            List<Student> Class6Students = new List<Student>()
            {
                new Student {ID = 102, Name = "Sambit" },
                new Student {ID = 104, Name = "Anurag"},
                new Student {ID = 105, Name = "Pranaya"},
            };

            //Method Syntax
            var MS = AllStudents
                     .Except(Class6Students).ToList();

            //Query Syntax
            var QS = (from std in AllStudents
                      select std)
                      .Except(Class6Students).ToList();

            foreach (var student in QS)
            {
                Console.WriteLine($" ID : {student.ID} Name : {student.Name}");
            }
            Console.ReadKey();
        }
        #endregion
    }
}
