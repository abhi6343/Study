namespace AnyMethod
{
    internal class Program
    {
        //#region Any method
        //static void Main(string[] args)
        //{
        //    int[] IntArray = { 11, 22, 33, 44, 55 };

        //    //Using Method Syntax
        //    var ResultMS = IntArray.Any();

        //    //Using Query Syntax
        //    var ResultQS = (from num in IntArray
        //                    select num).Any();

        //    Console.WriteLine("Is there any element in the collection? " + ResultMS);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Any method with predicate
        //static void Main(string[] args)
        //{
        //    int[] IntArray = { 11, 22, 33, 44, 55 };

        //    //Using Method Syntax
        //    var ResultMS = IntArray.Any(x => x < 10);

        //    //Using Query Syntax
        //    var ResultQS = (from num in IntArray
        //                    select num).Any(x => x < 10);

        //    Console.WriteLine("Is There Any Element Less than 10: " + ResultMS);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Any with string data type
        //static void Main(string[] args)
        //{
        //    string[] stringArray = { "James", "Sachin", "Sourav", "Pam", "Sara" };

        //    //Method Syntax
        //    var ResultMS = stringArray.Any(name => name.Length > 5);

        //    //Query Syntax
        //    var ResultQS = (from name in stringArray
        //                    select name).Any(name => name.Length > 5);

        //    Console.WriteLine("Is Any name with a Length greater than 5 Characters " + ResultMS);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Any with complex type
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    bool MSResult = Student.GetAllStudnets().Any(std => std.TotalMarks > 250);

        //    //Using Query Syntax
        //    bool QSResult = (from std in Student.GetAllStudnets()
        //                     select std).Any(std => std.TotalMarks > 250);

        //    Console.WriteLine($"Any Student Having Total Marks > 250: {MSResult}");
        //    Console.ReadKey();
        //}
        //#endregion


        #region Any with complex type with complex condition
        static void Main(string[] args)
        {
            //Using Method Syntax
            var MSResult = Student.GetAllStudnets()
                            .Where(std => std.Subjects.Any(x => x.Marks > 90)).ToList();

            //Using Query Syntax
            var QSResult = (from std in Student.GetAllStudnets()
                            where std.Subjects.Any(x => x.Marks > 90)
                            select std).ToList();

            foreach (var student in QSResult)
            {
                Console.WriteLine($"{student.Name} - {student.TotalMarks}");
                foreach (var subject in student.Subjects)
                {
                    Console.WriteLine($" {subject.SubjectName} - {subject.Marks}");
                }
            }
            Console.ReadKey();
        }
        #endregion


        //#region Any for checking user existance in datbase
        //public bool UserExists(string email)
        //{
        //    using (var context = new MyDbContext())
        //    {
        //        return context.Users.Any(user => user.Email == email);
        //    }
        //}
        //#endregion


        //#region Any for validating product availability in an E-commerce cart
        //public bool IsCartValid(List<CartItem> cartItems)
        //{
        //    foreach (var item in cartItems)
        //    {
        //        if (!Products.Any(p => p.Id == item.ProductId && p.StockQuantity >= item.Quantity))
        //        {
        //            return false; // At least one item is not available in the desired quantity
        //        }
        //    }
        //    return true; // All items are available
        //}
        //#endregion


        //#region Any for role based access control
        //public bool HasAccess(User user, string[] requiredRoles)
        //{
        //    return user.Roles.Any(role => requiredRoles.Contains(role.Name));
        //}
        //#endregion


        //#region Any for invalid entries from user input
        //public bool ContainsInvalidEmails(List<string> emails)
        //{
        //    return emails.Any(email => !IsValidEmail(email));
        //}
        //private bool IsValidEmail(string email)
        //{
        //    // Assume this method implements email validation logic
        //}
        //#endregion
    }
}
