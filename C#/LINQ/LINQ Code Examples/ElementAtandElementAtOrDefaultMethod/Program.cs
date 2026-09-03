namespace ElementAtandElementAtOrDefaultMethod
{
    internal class Program
    {
        //#region ElementAt method
        //static void Main(string[] args)
        //{
        //    //Data Source
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    //Using ElementAt Method
        //    //Fetch the Element from Index Position 1 using Method Syntax
        //    //ElementAt Method returns a Single Value
        //    int MethodSyntax = numbers.ElementAt(1);

        //    //Query Syntax
        //    int QuerySyntax = (from num in numbers
        //                       select num).ElementAt(1);

        //    //Printing the value returned by the ElementAt Method
        //    Console.WriteLine(MethodSyntax);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Index Value is out of the range of the collection
        //static void Main(string[] args)
        //{
        //    //Data Source
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    //Using ElementAt Method
        //    //Fetch the Element from Index Position -1 or 10 using Method Syntax

        //    //int MethodSyntax = numbers.ElementAt(-1);
        //    int MethodSyntax = numbers.ElementAt(10);

        //    //Printing the value returned by the ElementAt Method
        //    Console.WriteLine(MethodSyntax);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region ElementAt method on an Empty Data Source
        //static void Main(string[] args)
        //{
        //    //Data Source is Empty
        //    List<int> numbers = new List<int>();

        //    //Using ElementAt Method
        //    int MethodSyntax = numbers.ElementAt(1);

        //    //Printing the value returned by the ElementAt Method
        //    Console.WriteLine(MethodSyntax);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region ElementAt method on a null Data Source
        //static void Main(string[] args)
        //{
        //    //Data Source is Null
        //    List<int> numbers = null;

        //    //Using ElementAt Method
        //    int MethodSyntax = numbers.ElementAt(1);

        //    //Printing the value returned by the ElementAt Method
        //    Console.WriteLine(MethodSyntax);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region ElementAtOrDefault method
        //static void Main(string[] args)
        //{
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    //Method Syntax
        //    int MethodSyntax = numbers.ElementAtOrDefault(1);

        //    //Query Syntax
        //    int QuerySyntax = (from num in numbers
        //                       select num).ElementAtOrDefault(1);

        //    Console.WriteLine(MethodSyntax);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Index Value is out of the Ranges
        //static void Main(string[] args)
        //{
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        //    int MethodSyntax1 = numbers.ElementAtOrDefault(10);
        //    Console.WriteLine($"Value at Index Position 10: {MethodSyntax1}");
        //    int MethodSyntax2 = numbers.ElementAtOrDefault(-1);
        //    Console.WriteLine($"Value at Index Position -1: {MethodSyntax2}");
        //    Console.ReadLine();
        //}
        //#endregion


        #region ElementAt and ElementAtOrDefault with complex type
        static void Main(string[] args)
        {
            //ElementAtOrDefault Method Syntax
            Student ElementAtMS = Student.GetAllStudents().ElementAt(1);

            //ElementAtOrDefault Query Syntax
            Student ElementAtQS = (from student in Student.GetAllStudents()
                                   select student).ElementAt(2);

            //ElementAtOrDefault Method Syntax
            Student ElementAtOrDefaultMS = Student.GetAllStudents().ElementAtOrDefault(0);

            //ElementAtOrDefault Query Syntax
            Student ElementAtOrDefaultQS = (from student in Student.GetAllStudents()
                                            select student).ElementAtOrDefault(3);

            Console.WriteLine($"ID: {ElementAtMS.ID}, Name: {ElementAtMS.Name}, Department: {ElementAtMS.Department}");
            Console.ReadLine();
        }
        #endregion
    }
}
