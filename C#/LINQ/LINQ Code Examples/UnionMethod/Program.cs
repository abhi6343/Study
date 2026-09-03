using System.Linq;

namespace UnionMethod
{
    internal class Program
    {
        //#region Union method on value type
        //static void Main(string[] args)
        //{
        //    List<int> dataSource1 = new List<int>() { 1, 2, 3, 4, 5, 6 };
        //    List<int> dataSource2 = new List<int>() { 1, 3, 5, 8, 9, 10 };

        //    //Method Syntax
        //    var MS = dataSource1.Union(dataSource2).ToList();

        //    //Query Syntax
        //    var QS = (from num in dataSource1
        //              select num)
        //            .Union(dataSource2).ToList();

        //    foreach (var item in MS)
        //    {
        //        Console.WriteLine(item);
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
        //    var MS = dataSource1.Union(dataSource2).ToList();
        //    foreach (var item in MS)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Union with string values
        //static void Main(string[] args)
        //{
        //    string[] dataSource1 = { "India", "USA", "UK", "Canada", "Srilanka" };
        //    string[] dataSource2 = { "India", "uk", "Canada", "France", "Japan" };

        //    //Method Syntax
        //    var MS = dataSource1.Union(dataSource2).ToList();

        //    //Query Syntax
        //    var QS = (from country in dataSource1
        //              select country)
        //              .Union(dataSource2).ToList();

        //    foreach (var item in MS)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Union with IEqualityComparer for string values
        //static void Main(string[] args)
        //{
        //    string[] dataSource1 = { "India", "USA", "UK", "Canada", "Srilanka" };
        //    string[] dataSource2 = { "India", "uk", "Canada", "France", "Japan" };

        //    //Method Syntax
        //    var MS = dataSource1.Union(dataSource2,
        //              StringComparer.OrdinalIgnoreCase).ToList();

        //    //Query Syntax
        //    var QS = (from country in dataSource1
        //              select country)
        //             .Union(dataSource2, StringComparer.OrdinalIgnoreCase).ToList();

        //    foreach (var item in MS)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Union with complex data type with one property same
        //static void Main(string[] args)
        //{
        //    List<Student> StudentCollection1 = new List<Student>()
        //    {
        //        new Student {ID = 101, Name = "Preety" },
        //        new Student {ID = 102, Name = "Sambit" },
        //        new Student {ID = 105, Name = "Hina"},
        //        new Student {ID = 106, Name = "Anurag"},
        //    };
        //    List<Student> StudentCollection2 = new List<Student>()
        //    {
        //        new Student {ID = 105, Name = "Hina"},
        //        new Student {ID = 106, Name = "Anurag"},
        //        new Student {ID = 107, Name = "Pranaya"},
        //        new Student {ID = 108, Name = "Santosh"},
        //    };

        //    //Method Syntax
        //    var MS = StudentCollection1.Select(x => x.Name)
        //             .Union(StudentCollection2.Select(y => y.Name)).ToList();

        //    //Query Syntax
        //    var QS = (from std in StudentCollection1
        //              select std.Name)
        //             .Union(StudentCollection2.Select(y => y.Name)).ToList();

        //    foreach (var name in MS)
        //    {
        //        Console.WriteLine(name);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Problem with default comparer
        //static void Main(string[] args)
        //{
        //    List<Student> StudentCollection1 = new List<Student>()
        //    {
        //        new Student {ID = 101, Name = "Preety" },
        //        new Student {ID = 102, Name = "Sambit" },
        //        new Student {ID = 105, Name = "Hina"},
        //        new Student {ID = 106, Name = "Anurag"},
        //    };
        //    List<Student> StudentCollection2 = new List<Student>()
        //    {
        //        new Student {ID = 105, Name = "Hina"},
        //        new Student {ID = 106, Name = "Anurag"},
        //        new Student {ID = 107, Name = "Pranaya"},
        //        new Student {ID = 108, Name = "Santosh"},
        //    };

        //    //Method Syntax
        //    var MS = StudentCollection1.Union(StudentCollection2).ToList();

        //    //Query Syntax
        //    var QS = (from std in StudentCollection1
        //              select std).Union(StudentCollection2).ToList();

        //    foreach (var student in MS)
        //    {
        //        Console.WriteLine($" ID : {student.ID} Name : {student.Name}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Write class that implements IEqualityComparer interface
        //static void Main(string[] args)
        //{
        //    List<Student> StudentCollection1 = new List<Student>()
        //    {
        //        new Student {ID = 101, Name = "Preety" },
        //        new Student {ID = 102, Name = "Sambit" },
        //        new Student {ID = 105, Name = "Hina"},
        //        new Student {ID = 106, Name = "Anurag"},
        //    };
        //    List<Student> StudentCollection2 = new List<Student>()
        //    {
        //        new Student {ID = 105, Name = "Hina"},
        //        new Student {ID = 106, Name = "Anurag"},
        //        new Student {ID = 107, Name = "Pranaya"},
        //        new Student {ID = 108, Name = "Santosh"},
        //    };

        //    StudentComparer studentComparer = new StudentComparer();

        //    //Method Syntax
        //    var MS = StudentCollection1
        //    .Union(StudentCollection2, studentComparer).ToList();

        //    //Query Syntax
        //    var QS = (from std in StudentCollection1
        //              select std)
        //    .Union(StudentCollection2, studentComparer).ToList();

        //    foreach (var student in MS)
        //    {
        //        Console.WriteLine($" ID : {student.ID} Name : {student.Name}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Using Anonymous Type
        ////Annonymous Type already overrides the Equals() and GetHashCode() methods of the Object Class.
        //static void Main(string[] args)
        //{
        //    List<Student> StudentCollection1 = new List<Student>()
        //    {
        //        new Student {ID = 101, Name = "Preety" },
        //        new Student {ID = 102, Name = "Sambit" },
        //        new Student {ID = 105, Name = "Hina"},
        //        new Student {ID = 106, Name = "Anurag"},
        //    };
        //    List<Student> StudentCollection2 = new List<Student>()
        //    {
        //        new Student {ID = 105, Name = "Hina"},
        //        new Student {ID = 106, Name = "Anurag"},
        //        new Student {ID = 107, Name = "Pranaya"},
        //        new Student {ID = 108, Name = "Santosh"},
        //    };

        //    //Method Syntax
        //    var MS = StudentCollection1.Select(x => new { x.ID, x.Name })
        //              .Union(StudentCollection2.Select(x => new { x.ID, x.Name })).ToList();

        //    //Query Syntax
        //    var QS = (from std in StudentCollection1
        //              select new { std.ID, std.Name })
        //               .Union(StudentCollection2.Select(x => new { x.ID, x.Name })).ToList();

        //    foreach (var student in MS)
        //    {
        //        Console.WriteLine($" ID : {student.ID} Name : {student.Name}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Overriding Equals() and GetHashCode() Methods within the Student Class
        //static void Main(string[] args)
        //{
        //    List<Student> StudentCollection1 = new List<Student>()
        //    {
        //        new Student {ID = 101, Name = "Preety" },
        //        new Student {ID = 102, Name = "Sambit" },
        //        new Student {ID = 105, Name = "Hina"},
        //        new Student {ID = 106, Name = "Anurag"},
        //    };
        //    List<Student> StudentCollection2 = new List<Student>()
        //    {
        //        new Student {ID = 105, Name = "Hina"},
        //        new Student {ID = 106, Name = "Anurag"},
        //        new Student {ID = 107, Name = "Pranaya"},
        //        new Student {ID = 108, Name = "Santosh"},
        //    };

        //    //Method Syntax
        //    var MS = StudentCollection1.Union(StudentCollection2).ToList();

        //    //Query Syntax
        //    var QS = (from std in StudentCollection1
        //              select std).Union(StudentCollection2).ToList();

        //    foreach (var student in MS)
        //    {
        //        Console.WriteLine($" ID : {student.ID} Name : {student.Name}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        #region Implementing IEquatble<T> Interface in Student Class
        static void Main(string[] args)
        {
            List<Student> StudentCollection1 = new List<Student>()
            {
                new Student {ID = 101, Name = "Preety" },
                new Student {ID = 102, Name = "Sambit" },
                new Student {ID = 105, Name = "Hina"},
                new Student {ID = 106, Name = "Anurag"},
            };
            List<Student> StudentCollection2 = new List<Student>()
            {
                new Student {ID = 105, Name = "Hina"},
                new Student {ID = 106, Name = "Anurag"},
                new Student {ID = 107, Name = "Pranaya"},
                new Student {ID = 108, Name = "Santosh"},
            };

            //Method Syntax
            var MS = StudentCollection1.Union(StudentCollection2).ToList();

            //Query Syntax
            var QS = (from std in StudentCollection1
                      select std).Union(StudentCollection2).ToList();

            foreach (var student in MS)
            {
                Console.WriteLine($" ID : {student.ID} Name : {student.Name}");
            }
            Console.ReadKey();
        }
        #endregion
    }
}
