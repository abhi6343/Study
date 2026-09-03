namespace GroupByMultipleKeys
{
    internal class Program
    {
        //#region GroupBy with multiple keys
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    var GroupByMultipleKeysMS = Student.GetStudents()
        //                                //Grouping Multiple Keys using an Anonymous Object
        //                                .GroupBy(x => new { x.Branch, x.Gender })
        //                                .Select(g => new
        //                                {
        //                                    Branch = g.Key.Branch,
        //                                    Gender = g.Key.Gender,
        //                                    Students = g.OrderBy(x => x.Name)
        //                                });

        //    //Using Query Syntax
        //    var GroupByMultipleKeysQS = (from std in Student.GetStudents()
        //                                //Grouping Multiple Keys using an Anonymous Object
        //                                 group std by new
        //                                 {
        //                                     std.Branch,
        //                                     std.Gender
        //                                 } into stdGroup
        //                                 select new
        //                                 {
        //                                     Branch = stdGroup.Key.Branch,
        //                                     Gender = stdGroup.Key.Gender,
        //                                     //Sort the Students of Each group by Name in Ascending Order
        //                                     Students = stdGroup.OrderBy(x => x.Name)
        //                                 });

        //    //It will iterate through each group
        //    foreach (var group in GroupByMultipleKeysQS)
        //    {
        //        Console.WriteLine($"Barnch : {group.Branch} Gender: {group.Gender} No of Students = {group.Students.Count()}");
        //        //It will iterate through each item of a group
        //        foreach (var student in group.Students)
        //        {
        //            Console.WriteLine($"  ID: {student.ID}, Name: {student.Name}, Age: {student.Age} ");
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.Read();
        //}
        //#endregion


        //#region GroupBy with tuple
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    var GroupByMultipleKeysMS = Student.GetStudents()
        //                                //Grouping Multiple Keys using using Tuples
        //                                .GroupBy(student => (student.Branch, student.Gender))
        //                                .Select(g => new
        //                                {
        //                                    Branch = g.Key.Branch,
        //                                    Gender = g.Key.Gender,
        //                                    Students = g.OrderBy(x => x.Name)
        //                                });

        //    //Using Query Syntax
        //    var GroupByMultipleKeysQS = (from std in Student.GetStudents()
        //                                //Grouping Multiple Keys using Tuples
        //                                 group std by (std.Branch, std.Gender
        //                                 ) into stdGroup
        //                                 select new
        //                                 {
        //                                     Branch = stdGroup.Key.Branch,
        //                                     Gender = stdGroup.Key.Gender,
        //                                     //Sort the Students of Each group by Name in Ascending Order
        //                                     Students = stdGroup.OrderBy(x => x.Name)
        //                                 });

        //    //It will iterate through each group
        //    foreach (var group in GroupByMultipleKeysQS)
        //    {
        //        Console.WriteLine($"Barnch : {group.Branch} Gender: {group.Gender} No of Students = {group.Students.Count()}");
        //        //It will iterate through each item of a group
        //        foreach (var student in group.Students)
        //        {
        //            Console.WriteLine($"  ID: {student.ID}, Name: {student.Name}, Age: {student.Age} ");
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.Read();
        //}
        //#endregion


        //#region GroupBy with OrderBy
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    var GroupByMultipleKeysMS = Student.GetStudents()
        //                                //Group the Students first by Branch and then Gender
        //                                .GroupBy(x => new { x.Branch, x.Gender })
        //                                //Sort Each Group in Descending Order Based on Branch
        //                                .OrderByDescending(g => g.Key.Branch)
        //                                //Then Sort Each Branch Group in Ascending Order Based on Gender
        //                                .ThenBy(g => g.Key.Gender)
        //                                //Project the Result to an Annonymous Type
        //                                .Select(g => new
        //                                {
        //                                    Branch = g.Key.Branch,
        //                                    Gender = g.Key.Gender,
        //                                    //Sort the Students of Each group by Name in Ascending Order
        //                                    Students = g.OrderBy(x => x.Name)
        //                                });

        //    //Using Query Syntax
        //    var GroupByMultipleKeysQS = from student in Student.GetStudents()
        //                                //Group the Students by Branch and then Gender and Store the
        //                                //Result into a variable
        //                                group student by new
        //                                {
        //                                    student.Branch,
        //                                    student.Gender
        //                                } into stdGroup
        //                                //Then Sort the group by Barnch Descending and Gender Ascending Order
        //                                orderby stdGroup.Key.Branch descending,
        //                                        stdGroup.Key.Gender ascending
        //                                //Project the Result to an Annonymous Type
        //                                select new
        //                                {
        //                                    Branch = stdGroup.Key.Branch,
        //                                    Gender = stdGroup.Key.Gender,
        //                                    //Sort the Students of Each group by Name in Ascending Order
        //                                    Students = stdGroup.OrderBy(x => x.Name)
        //                                };

        //    //It will iterate through each group
        //    foreach (var group in GroupByMultipleKeysQS)
        //    {
        //        Console.WriteLine($"Barnch : {group.Branch} Gender: {group.Gender} No of Students = {group.Students.Count()}");
        //        //It will iterate through each item of a group
        //        foreach (var student in group.Students)
        //        {
        //            Console.WriteLine($"  ID: {student.ID}, Name: {student.Name}, Age: {student.Age} ");
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.Read();
        //}
        //#endregion


        //#region Projecting result to defined type
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    var GroupByMultipleKeysMS = Student.GetStudents()
        //                                //Group the Students first by Branch and then Gender
        //                                .GroupBy(x => new { x.Branch, x.Gender })
        //                                //Sort Each Group in Descending Order Based on Branch
        //                                .OrderByDescending(g => g.Key.Branch)
        //                                //Then Sort Each Branch Group in Ascending Order Based on Gender
        //                                .ThenBy(g => g.Key.Gender)
        //                                //Project the Result to StudentGroupByBranchGender Type
        //                                .Select(g => new StudentGroupByBranchGender
        //                                {
        //                                    Branch = g.Key.Branch,
        //                                    Gender = g.Key.Gender,
        //                                    //Sort the Students of Each group by Name in Ascending Order
        //                                    Students = g.OrderBy(x => x.Name).ToList()
        //                                });

        //    //Using Query Syntax
        //    var GroupByMultipleKeysQS = from student in Student.GetStudents()
        //                                    //Group the Students by Branch and then Gender and Store the
        //                                    //Result into a variable
        //                                group student by new
        //                                {
        //                                    student.Branch,
        //                                    student.Gender
        //                                } into stdGroup
        //                                //Then Sort the group by Barnch Descending and Gender Ascending Order
        //                                orderby stdGroup.Key.Branch descending,
        //                                        stdGroup.Key.Gender ascending
        //                                //Project the Result to StudentGroupByBranchGender Type
        //                                select new StudentGroupByBranchGender
        //                                {
        //                                    Branch = stdGroup.Key.Branch,
        //                                    Gender = stdGroup.Key.Gender,
        //                                    //Sort the Students of Each group by Name in Ascending Order
        //                                    Students = stdGroup.OrderBy(x => x.Name).ToList()
        //                                };

        //    //It will iterate through each group
        //    foreach (StudentGroupByBranchGender group in GroupByMultipleKeysQS)
        //    {
        //        Console.WriteLine($"Barnch : {group.Branch} Gender: {group.Gender} No of Students = {group.Students.Count()}");
        //        //It will iterate through each item of a group
        //        foreach (var student in group.Students)
        //        {
        //            Console.WriteLine($"  ID: {student.ID}, Name: {student.Name}, Age: {student.Age} ");
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.Read();
        //}
        //#endregion


        //#region GroupBy Complex Data Structures
        //static void Main(string[] args)
        //{
        //    // Grouping by CustomerId and OrderYear
        //    var groupedOrders = Order.GetAllOrders()
        //                        .GroupBy(order => new
        //                        {
        //                            order.CustomerId,
        //                            OrderYear = order.OrderDate.Year
        //                        })
        //                        .Select(group => new
        //                        {
        //                            CustomerId = group.Key.CustomerId,
        //                            OrderYear = group.Key.OrderYear,
        //                            TotalOrders = group.Count(),
        //                            TotalAmount = group.Sum(order => order.Total)
        //                        });

        //    // Displaying the grouped information
        //    foreach (var group in groupedOrders)
        //    {
        //        Console.WriteLine($"CustomerId: {group.CustomerId}, OrderYear: {group.OrderYear}, Orders: {group.TotalOrders}, TotalAmount: {group.TotalAmount}");
        //    }
        //    Console.Read();
        //}
        //#endregion


        //#region GroupBy for detailed data analysis
        //static void Main(string[] args)
        //{
        //    //To group by multiple keys, we use an anonymous type in the GroupBy method
        //    var groupedSales = SaleRecord.GetAllSales().GroupBy(s => new { s.Country, s.Year })
        //                        .Select(g => new
        //                        {
        //                            Country = g.Key.Country,
        //                            Year = g.Key.Year,
        //                            TotalAmount = g.Sum(x => x.Amount),
        //                            SaleCount = g.Count()
        //                        });

        //    // Analyzing the Results
        //    //we can iterate over the grouped results to analyze the total sales amount 
        //    //and count of sales for each country and year
        //    foreach (var group in groupedSales)
        //    {
        //        Console.WriteLine($"Country: {group.Country}, Year: {group.Year}, Total Sales: {group.TotalAmount}, Sales Count: {group.SaleCount}");
        //    }

        //    Console.Read();
        //}
        //#endregion


        #region GroupBy for Handling Hierarchical Data
        static void Main(string[] args)
        {
            var groupedEmployees = Employee.GetAllEmployees()
                                    .GroupBy(e => new { e.Department, e.JobTitle })
                                    .Select(group => new
                                    {
                                        Department = group.Key.Department,
                                        JobTitle = group.Key.JobTitle,
                                        Employees = group.ToList()
                                    });

            foreach (var group in groupedEmployees)
            {
                Console.WriteLine($"{group.Department} - {group.JobTitle}");
                foreach (var employee in group.Employees)
                {
                    Console.WriteLine($"\t{employee.Name}");
                }
            }

            Console.Read();
        }
        #endregion
    }
}
