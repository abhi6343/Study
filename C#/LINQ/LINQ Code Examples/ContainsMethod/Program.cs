namespace ContainsMethod
{
    internal class Program
    {
        //#region Contains method with primitive type
        //static void Main(string[] args)
        //{
        //    int[] IntArray = { 11, 22, 33, 44, 55 };

        //    //Using Method Syntax
        //    var IsExistsMS = IntArray.Contains(33);

        //    //Using Query Syntax
        //    var IsExistsQS = (from num in IntArray
        //                      select num).Contains(33);

        //    Console.WriteLine($"Is Element 33 Exist: {IsExistsMS}");
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Contains method with string type
        //static void Main(string[] args)
        //{
        //    List<string> namesList = new List<string>() { "James", "Sachin", "Sourav", "Pam", "Sara" };

        //    //Using Method Syntax
        //    //This method belongs to System.Collections.Generic namespace
        //    var IsExistsMS1 = namesList.Contains("Anurag");

        //    //This method belongs to System.Linq namespace
        //    var IsExistsMS2 = namesList.AsEnumerable().Contains("Anurag");

        //    //Using Query Syntax
        //    var IsExistsQS = (from num in namesList
        //                      select num).Contains("Anurag");

        //    Console.WriteLine($"Is Name Anurag Exist: {IsExistsQS}");
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Contains method with complex type
        ////Contains method checks the object reference, not the object’s values.
        //static void Main(string[] args)
        //{
        //    List<Student> students = new List<Student>();
        //    var student1 = new Student() { ID = 101, Name = "Priyanka", TotalMarks = 275 };
        //    var student2 = new Student() { ID = 102, Name = "Preety", TotalMarks = 375 };
        //    students.Add(student1);
        //    students.Add(student2);

        //    //Using Method Syntax
        //    var IsExistsMS = students.Contains(student1);

        //    //Using Query Syntax
        //    var IsExistsQS = (from num in students
        //                      select num).Contains(student1);

        //    Console.WriteLine(IsExistsMS);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Problem with the default coparer
        //static void Main(string[] args)
        //{
        //    List<Student> students = new List<Student>()
        //                {
        //                    new Student(){ID = 101, Name = "Priyanka", TotalMarks = 275 },
        //                    new Student(){ID = 102, Name = "Preety", TotalMarks = 375 }
        //                };

        //    //Using Method Syntax
        //    var IsExistsMS = students.Contains(new Student() { ID = 101, Name = "Priyanka", TotalMarks = 275 });

        //    var student1 = new Student() { ID = 101, Name = "Priyanka", TotalMarks = 275 };

        //    //Using Query Syntax
        //    var IsExistsQS = (from num in students
        //                      select num).Contains(student1);

        //    Console.WriteLine(IsExistsMS);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Conatins with IEqualityComparer
        //static void Main(string[] args)
        //{
        //    List<Student> students = new List<Student>()
        //                {
        //                    new Student(){ID = 101, Name = "Priyanka", TotalMarks = 275 },
        //                    new Student(){ID = 102, Name = "Preety", TotalMarks = 375 }
        //                };

        //    //Createing Student Comparer Instance
        //    StudentComparer studentComparer = new StudentComparer();

        //    //Using Method Syntax
        //    var IsExistsMS = students.Contains(new Student() { ID = 101, Name = "Priyanka", TotalMarks = 275 }, studentComparer);
        //    var student1 = new Student() { ID = 101, Name = "Priyanka", TotalMarks = 275 };

        //    //Using Query Syntax
        //    var IsExistsQS = (from num in students
        //                      select num).Contains(student1, studentComparer);

        //    Console.WriteLine(IsExistsMS);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Overriding Equals() and GetHashCode() Methods within the Student Class
        //static void Main(string[] args)
        //{
        //    List<Student> students = new List<Student>()
        //                {
        //                    new Student(){ID = 101, Name = "Priyanka", TotalMarks = 275 },
        //                    new Student(){ID = 102, Name = "Preety", TotalMarks = 375 }
        //                };

        //    //Using Method Syntax
        //    var IsExistsMS = students.Contains(new Student() { ID = 101, Name = "Priyanka", TotalMarks = 275 });
        //    var student1 = new Student() { ID = 101, Name = "Priyanka", TotalMarks = 275 };

        //    //Using Query Syntax
        //    var IsExistsQS = (from num in students
        //                      select num).Contains(student1);

        //    Console.WriteLine(IsExistsMS);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region With IEquatable<Student> interface
        //static void Main(string[] args)
        //{
        //    List<Student> students = new List<Student>()
        //                {
        //                    new Student(){ID = 101, Name = "Priyanka", TotalMarks = 275 },
        //                    new Student(){ID = 102, Name = "Preety", TotalMarks = 375 }
        //                };

        //    //Using Method Syntax
        //    var IsExistsMS = students.Contains(new Student() { ID = 101, Name = "Priyanka", TotalMarks = 275 });
        //    var student1 = new Student() { ID = 101, Name = "Priyanka", TotalMarks = 275 };

        //    //Using Query Syntax
        //    var IsExistsQS = (from num in students
        //                      select num).Contains(student1);

        //    Console.WriteLine(IsExistsMS);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Contains for Checking for the existence of an item in a collection
        //static void Main(string[] args)
        //{
        //    List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
        //    int targetNumber = 3;
        //    bool containsTarget = numbers.Contains(targetNumber);
        //    Console.WriteLine($"Does the list contain {targetNumber}? {containsTarget}");
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Filtering elements in a sequence
        //static void Main(string[] args)
        //{
        //    List<string> fruits = new List<string> { "Apple", "Banana", "Cherry", "Date", "Elderberry" };
        //    string searchKeyword = "an";

        //    var matchingFruits = fruits.Where(fruit => fruit.Contains(searchKeyword)).ToList();

        //    Console.WriteLine($"Fruits containing '{searchKeyword}':");
        //    foreach (var fruit in matchingFruits)
        //    {
        //        Console.WriteLine(fruit);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Searching for specific values in collections
        //static void Main(string[] args)
        //{
        //    List<int> sourceList = new List<int> { 1, 2, 3, 4, 5 };
        //    List<int> targetList = new List<int> { 3, 6, 9 };

        //    bool anyMatch = sourceList.Any(item => targetList.Contains(item));

        //    bool anyMatchFound = sourceList.Any(targetList.Contains);

        //    Console.WriteLine($"Any elements in sourceList exist in targetList? {anyMatch}");
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Searching for elements in a database using LINQ to SQL or Entity Framework
        //static void Main(string[] args)
        //{
        //    using (var dbContext = new MyDbContext()) // Replace with your actual DbContext
        //    {
        //        List<string> targetNames = new List<string> { "John", "Alice", "Bob" };
        //        var matchingUsers = dbContext.Users
        //            .Where(user => targetNames.Contains(user.Name))
        //            .ToList();
        //        Console.WriteLine("Users matching the target names:");
        //        foreach (var user in matchingUsers)
        //        {
        //            Console.WriteLine($"{user.Id}: {user.Name}");
        //        }
        //    }
        //    Console.ReadKey();
        //}
        //#endregion
    }
}
