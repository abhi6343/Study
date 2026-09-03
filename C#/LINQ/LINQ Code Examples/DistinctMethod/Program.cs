namespace DistinctMethod
{
    internal class Program
    {
        //#region Distinct method on value type
        //static void Main(string[] args)
        //{
        //    List<int> intCollection = new List<int>()
        //    {
        //        1,2,3,2,3,4,4,5,6,3,4,5
        //    };

        //    //Using Method Syntax
        //    var MS = intCollection.Distinct();

        //    //Using Query Syntax
        //    var QS = (from num in intCollection
        //              select num).Distinct();

        //    foreach (var item in MS)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Distinct with string values
        //static void Main(string[] args)
        //{
        //    string[] namesArray = { "Priyanka", "HINA", "hina", "Anurag", "Anurag", "ABC", "abc" };
        //    var distinctNames = namesArray.Distinct();
        //    foreach (var name in distinctNames)
        //    {
        //        Console.WriteLine(name);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Distinct with IEqualityComparer for string values
        //static void Main(string[] args)
        //{
        //    string[] namesArray = { "Priyanka", "HINA", "hina", "Anurag", "Anurag","ABC", "abc" };
        //    var distinctNames = namesArray.Distinct(StringComparer.OrdinalIgnoreCase);
        //    foreach (var name in distinctNames)
        //    {
        //        Console.WriteLine(name);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Distinct with complex data type
        //Fetch all the distinct names from the student’s collection
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    var MS = Student.GetStudents()
        //              .Select(std => std.Name)
        //              .Distinct().ToList();

        //    //Using Query Syntax
        //    var QS = (from std in Student.GetStudents()
        //              select std.Name)
        //             .Distinct().ToList();

        //    foreach (var item in MS)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Problem with Default Comparer
        ////select distinct students (ID and Name) from the student’s collection
        ////MS or QS will show all the students bacause of default eqality comparer
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    var MS = Student.GetStudents()
        //             .Distinct().ToList();

        //    //Using Query Syntax
        //    var QS = (from std in Student.GetStudents()
        //              select std)
        //              .Distinct().ToList();

        //    foreach (var item in QS)
        //    {
        //        Console.WriteLine($"ID : {item.ID} , Name : {item.Name} ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Approach 1 write class that implements IEqualityComparer interface
        //static void Main(string[] args)
        //{
        //    //Creating an instance of StudentComparer
        //    StudentComparer studentComparer = new StudentComparer();

        //    //Using Method Syntax
        //    var MS = Student.GetStudents()
        //             .Distinct(studentComparer).ToList();

        //    //Using Query Syntax
        //    var QS = (from std in Student.GetStudents()
        //              select std)
        //              .Distinct(studentComparer).ToList();

        //    foreach (var item in QS)
        //    {
        //        Console.WriteLine($"ID : {item.ID} , Name : {item.Name} ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Approach 2: Overriding Equals() and GetHashCode() Methods within the Student Class
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    var MS = Student.GetStudents()
        //             .Distinct().ToList();

        //    //Using Query Syntax
        //    var QS = (from std in Student.GetStudents()
        //              select std)
        //              .Distinct().ToList();

        //    foreach (var item in MS)
        //    {
        //        Console.WriteLine($"ID : {item.ID} , Name : {item.Name} ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Approach 3: Using Anonymous Type
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    var MS = Student.GetStudents()
        //            .Select(std => new { std.ID, std.Name })
        //            .Distinct().ToList();

        //    //Using Query Syntax
        //    var QS = (from std in Student.GetStudents()
        //              select std)
        //            .Select(std => new { std.ID, std.Name })
        //            .Distinct().ToList();

        //    foreach (var item in MS)
        //    {
        //        Console.WriteLine($"ID : {item.ID} , Name : {item.Name}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion



        #region Approach 4: Implementing IEquatble<T> Interface in Student Class
        static void Main(string[] args)
        {
            //Using Method Syntax
            var MS = Student.GetStudents()
                      .Distinct().ToList();

            //Using Query Syntax
            var QS = (from std in Student.GetStudents()
                      select std)
                      .Distinct().ToList();

            foreach (var item in MS)
            {
                Console.WriteLine($"ID : {item.ID} , Name : {item.Name} ");
            }
            Console.ReadKey();
        }
        #endregion
    }
}
