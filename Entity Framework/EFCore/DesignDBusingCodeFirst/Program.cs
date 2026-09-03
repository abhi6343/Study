using DesignDBusingCodeFirst;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    static void Main(string[] args)
    {
        //// Initialize the database context
        //using (var context = new EFCoreDbContext())
        //{
        //    try
        //    {
        //        // Method Syntax with Include (using lambda expression) 
        //        Console.WriteLine("Method Syntax: Loading Students and their Addresses\n");
        //        // Eagerly load Student entities along with their related Address entities using method syntax.
        //        var studentsWithAddressesMethod = context.Students
        //            .Include(s => s.Address) // Eager load Address entity using a lambda expression
        //            .ToList();
        //        // Method Syntax with Include (using string parameter)
        //        // Eagerly load Student entities along with their related Address entities using string-based Include.
        //        //var studentsWithAddressesMethodString = context.Students
        //        //    .Include("Address") // Eager load Address entity using string parameter
        //        //    .ToList();
        //        // Eager Loading using Query Syntax with Lambda Expression
        //        //var studentsWithAddressesQueryLambda = (from student in context.Students
        //        //                                        .Include(s => s.Address) // Eagerly load Address entity using lambda in query syntax
        //        //                                        select student).ToList();
        //        // Eager Loading using Query Syntax with String
        //        //var studentsWithAddressesQueryString = (from student in context.Students
        //        //                                        .Include("Address") // Eagerly load Address entity using string in query syntax
        //        //                                        select student).ToList();
        //        // Display results
        //        Console.WriteLine(); // Display a new line before displaying the data
        //        foreach (var student in studentsWithAddressesMethod)
        //        {
        //            if (student.Address != null)
        //            {
        //                // Address exists, display the full address details
        //                Console.WriteLine($"Student: {student.FirstName} {student.LastName}, Address: {student.Address.Street}, {student.Address.City}, {student.Address.State}");
        //            }
        //            else
        //            {
        //                // Address is null, display "No Address"
        //                Console.WriteLine($"Student: {student.FirstName} {student.LastName}, Address: No Address");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exceptions
        //        Console.WriteLine($"An error occurred while fetching the data. Error: {ex.Message}");
        //    }
        //}
        //// Final Output
        //Console.WriteLine("Eager loading completed.");

        //// Initialize the database context
        //using var context = new EFCoreDbContext();
        //try
        //{
        //    // METHOD SYNTAX with Include (using lambda expression)
        //    Console.WriteLine("Method Syntax: Loading Students with Branch, Address, and Courses");
        //    // Eagerly load Student entities along with their related Branch, Address, and Courses entities using method syntax.
        //    var studentsWithDetailsMethod = context.Students
        //        .Include(s => s.Branch)            // Eagerly load Branch entity
        //        .Include(s => s.Address)           // Eagerly load Address entity
        //        .Include(s => s.Courses)           // Eagerly load Courses collection
        //        .ToList();
        //    Console.WriteLine(); //Line Break before displaying the data
        //                         // Display results
        //    foreach (var student in studentsWithDetailsMethod)
        //    {
        //        Console.WriteLine($"Student: {student.FirstName} {student.LastName}, Branch: {student.Branch?.BranchLocation}, " +
        //            $"Address: {(student.Address == null ? "No Address" : student.Address.City)}, Courses Count: {student.Courses.Count}");
        //    }
        //    // QUERY SYNTAX with Include (using lambda expression)
        //    // Console.WriteLine("\nQuery Syntax: Loading Students with Branch, Address, and Courses");
        //    // Eagerly load Student entities along with their related Branch, Address, and Courses entities using query syntax.
        //    //var studentsWithDetailsQuery = (from student in context.Students
        //    //                                .Include(s => s.Branch)             // Eagerly load Branch entity
        //    //                                .Include(s => s.Address)            // Eagerly load Address entity
        //    //                                .Include(s => s.Courses)            // Eagerly load Courses collection
        //    //                                select student).ToList();
        //    // Display results
        //    //foreach (var student in studentsWithDetailsQuery)
        //    //{
        //    //    Console.WriteLine($"Student: {student.FirstName} {student.LastName}, Branch: {student.Branch?.BranchLocation}, " +
        //    //        $"Address: {(student.Address == null ? "No Address" : student.Address.City)}, Courses Count: {student.Courses.Count}");
        //    //}
        //}
        //catch (Exception ex)
        //{
        //    // Handle exceptions
        //    Console.WriteLine($"An error occurred while fetching the data. Error: {ex.Message}");
        //}

        //// Initialize the database context
        //using (var context = new EFCoreDbContext())
        //{
        //    try
        //    {
        //        // Method Syntax with Include and ThenInclude (using lambda expressions)
        //        Console.WriteLine("Loading Students and their related entities\n");
        //        // Eagerly load Student, Branch, Address, Courses, and the related Subjects using method syntax
        //        var student = (context.Students
        //            .Where(std => std.StudentId == 1)
        //            .Include(s => s.Branch)               // Eagerly load related Branch
        //            .Include(s => s.Address)              // Eagerly load related Address
        //            .Include(s => s.Courses)              // Eagerly load related Courses
        //            .ThenInclude(c => c.Subjects))        // Eagerly load related Subjects for each Course
        //            .FirstOrDefault();                    // Execute the query and retrieve the data
        //                                                  // Display basic student information
        //        Console.WriteLine($"Student: {student.FirstName} {student.LastName}");
        //        Console.WriteLine($"Branch: {student.Branch?.BranchLocation}");
        //        Console.WriteLine($"Address: {student.Address?.Street}, {student.Address?.City}, {student.Address?.State}");
        //        // Display each course and its related subjects
        //        foreach (var course in student.Courses)
        //        {
        //            Console.WriteLine($"Course: {course.Name}");
        //            foreach (var subject in course.Subjects)
        //            {
        //                Console.WriteLine($"    Subject: {subject.SubjectName}");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Exception handling: Catch and display any errors that occur during data retrieval
        //        Console.WriteLine($"An error occurred while fetching the data. Error: {ex.Message}");
        //    }
        //}
        //// Final Output
        //Console.WriteLine("\nEager loading of related entities completed.");



        #region Lazy Loading
        //using (var context = new EFCoreDbContext())
        //{
        //    try
        //    {
        //        // Lazy Loading Example
        //        Console.WriteLine("Lazy Loading Student and related data\n");
        //        // Load a student (only student data is loaded initially)
        //        var student = context.Students.FirstOrDefault(s => s.StudentId == 1);
        //        // Display basic student information
        //        Console.WriteLine($"\nStudent Id: {student?.StudentId}, Name: {student?.FirstName} {student?.LastName}, Gender: {student?.Gender} \n");
        //        // Accessing the Branch property triggers lazy loading
        //        // EF Core will issue a SQL query to load the related Branch
        //        if (student != null)
        //        {
        //            Console.WriteLine($"\nBranch Location: {student.Branch?.BranchLocation}, Email: {student.Branch?.BranchEmail}, Phone: {student.Branch?.BranchPhoneNumber}  \n");
        //            // Accessing the Address property triggers lazy loading
        //            // EF Core will issue a SQL query to load the related Address
        //            Console.WriteLine($"\nAddress: {student.Address?.Street}, {student.Address?.City}, {student.Address?.State}, Pin: {student.Address?.PostalCode} \n");
        //            // Accessing the Courses collection triggers lazy loading
        //            // EF Core will issue a SQL query to load the related Courses and their related Subjects
        //            //foreach (var course in student.Courses)
        //            //{
        //            //    Console.WriteLine($"Course Enrolled: {course.Name}");
        //            //You can also access the Subjects of each as follows
        //            //foreach (var subject in course.Subjects)
        //            //{
        //            //    Console.WriteLine($"    Subject: {subject.SubjectName}");
        //            //}
        //            //}
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle any errors that occur during data retrieval
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //    }
        //}
        //// Final Output
        //Console.WriteLine("\nLazy loading of related entities completed.");


        //using (var context = new EFCoreDbContext())
        //{
        //    try
        //    {
        //        // Eager Loading Example for Branch, Lazy Loading for Address
        //        Console.WriteLine("Eager Loading Branch, Lazy Loading Address\n");
        //        // Load a student and related Branch using Eager Loading
        //        var student = context.Students
        //                             .Include(s => s.Branch)  // Eagerly load the Branch entity
        //                             .FirstOrDefault(s => s.StudentId == 1);
        //        // Display basic student information
        //        if (student != null)
        //        {
        //            Console.WriteLine($"\nStudent Id: {student.StudentId}, Name: {student.FirstName} {student.LastName}, Gender: {student.Gender}");
        //            // Check if Branch is null
        //            if (student.Branch != null)
        //            {
        //                Console.WriteLine($"Branch Location: {student.Branch.BranchLocation}, Email: {student.Branch.BranchEmail}, Phone: {student.Branch.BranchPhoneNumber}\n");
        //            }
        //            else
        //            {
        //                Console.WriteLine("Branch data not available.\n");
        //            }
        //            // Accessing the Address property triggers lazy loading
        //            // EF Core will issue a SQL query to load the related Address
        //            if (student.Address != null)
        //            {
        //                Console.WriteLine($"\nAddress: {student.Address.Street}, {student.Address.City}, {student.Address.State}, Pin: {student.Address.PostalCode}");
        //            }
        //            else
        //            {
        //                Console.WriteLine("\nAddress data not available.");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Student data not found.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle any errors that occur during data retrieval
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //    }
        //}
        //// Final Output
        //Console.WriteLine("\nEager loading of Branch and lazy loading of Address completed.");


        //using (var context = new EFCoreDbContext())
        //{
        //    try
        //    {
        //        // Lazy Loading Example
        //        Console.WriteLine("Lazy Loading Student and related data\n");
        //        // Load a student (only student data is loaded initially)
        //        var student = context.Students.FirstOrDefault(s => s.StudentId == 1);
        //        // Display basic student information
        //        if (student != null)
        //        {
        //            Console.WriteLine($"\nStudent Id: {student.StudentId}, Name: {student.FirstName} {student.LastName}, Gender: {student.Gender} \n");
        //            //Disabling Lazy Loading Here
        //            context.ChangeTracker.LazyLoadingEnabled = false;
        //            // Check if Branch is null before accessing its properties
        //            if (student.Branch != null)
        //            {
        //                Console.WriteLine($"\nBranch Location: {student.Branch.BranchLocation}, Email: {student.Branch.BranchEmail}, Phone: {student.Branch.BranchPhoneNumber} \n");
        //            }
        //            else
        //            {
        //                Console.WriteLine("\nBranch data not available.\n");
        //            }
        //            //Enabling Lazy Loading Here
        //            context.ChangeTracker.LazyLoadingEnabled = true;
        //            // Check if Address is null before accessing its properties
        //            if (student.Address != null)
        //            {
        //                Console.WriteLine($"\nAddress: {student.Address.Street}, {student.Address.City}, {student.Address.State}, Pin: {student.Address.PostalCode} \n");
        //            }
        //            else
        //            {
        //                Console.WriteLine("\nAddress data not available.\n");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Student data not found.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle any errors that occur during data retrieval
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //    }
        //}
        //// Final Output
        //Console.WriteLine("\nLazy loading of related entities completed.");
        #endregion Lazy Loading


        #region Explicit Loading
        //using var context = new EFCoreDbContext();
        //try
        //{
        //    // Lazy Loading Example
        //    Console.WriteLine("Lazy Loading Student and related data\n");
        //    // Load a student (only student data is loaded initially)
        //    var student = context.Students.FirstOrDefault(s => s.StudentId == 1);
        //    // Display basic student information
        //    if (student != null)
        //    {
        //        Console.WriteLine($"\nStudent Id: {student.StudentId}, Name: {student.FirstName} {student.LastName}, Gender: {student.Gender} \n");
        //        // Check if Branch is null before accessing its properties
        //        if (student.Branch != null)
        //        {
        //            Console.WriteLine($"\nBranch Location: {student.Branch.BranchLocation}, Email: {student.Branch.BranchEmail}, Phone: {student.Branch.BranchPhoneNumber} \n");
        //        }
        //        else
        //        {
        //            Console.WriteLine("\nBranch data not available.\n");
        //        }
        //        // Check if Address is null before accessing its properties
        //        if (student.Address != null)
        //        {
        //            Console.WriteLine($"\nAddress: {student.Address.Street}, {student.Address.City}, {student.Address.State}, Pin: {student.Address.PostalCode} \n");
        //        }
        //        else
        //        {
        //            Console.WriteLine("\nAddress data not available.\n");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Student data not found.");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    // Handle any errors that occur during data retrieval
        //    Console.WriteLine($"An error occurred: {ex.Message}");
        //}

        //using var context = new EFCoreDbContext();
        //try
        //{
        //    Console.WriteLine("\nExplicit Loading Student Related Data\n");
        //    // Load a student (only student data is loaded initially)
        //    var student = context.Students.FirstOrDefault(s => s.StudentId == 1);
        //    // Display basic student information
        //    if (student != null)
        //    {
        //        Console.WriteLine($"\nStudent Id: {student.StudentId}, Name: {student.FirstName} {student.LastName}, Gender: {student.Gender} \n");
        //        // Explicitly load the Branch navigation property for the student
        //        context.Entry(student).Reference(s => s.Branch).Load();
        //        // Check if Branch is null before accessing its properties
        //        if (student.Branch != null)
        //        {
        //            Console.WriteLine($"\nBranch Location: {student.Branch.BranchLocation}, Email: {student.Branch.BranchEmail}, Phone: {student.Branch.BranchPhoneNumber} \n");
        //        }
        //        else
        //        {
        //            Console.WriteLine("\nBranch data not available.\n");
        //        }
        //        // Explicitly load the Address navigation property for the student
        //        context.Entry(student).Reference(s => s.Address).Load();
        //        // Check if Address is null before accessing its properties
        //        if (student.Address != null)
        //        {
        //            Console.WriteLine($"\nAddress: {student.Address.Street}, {student.Address.City}, {student.Address.State}, Pin: {student.Address.PostalCode} \n");
        //        }
        //        else
        //        {
        //            Console.WriteLine("\nAddress data not available.\n");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Student data not found.");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    // Handle any errors that occur during data retrieval
        //    Console.WriteLine($"An error occurred: {ex.Message}");
        //}

        //using var context = new EFCoreDbContext();
        //try
        //{
        //    Console.WriteLine("\nExplicit Loading Student Related Data\n");
        //    // Load a student (only student data is loaded initially)
        //    var student = context.Students.FirstOrDefault(s => s.StudentId == 1);
        //    // Display basic student information
        //    if (student != null)
        //    {
        //        Console.WriteLine($"\nStudent Id: {student.StudentId}, Name: {student.FirstName} {student.LastName}, Gender: {student.Gender} \n");
        //        // Explicitly load the Courses collection for the student
        //        context.Entry(student).Collection(s => s.Courses).Load();
        //        // Loop through the loaded courses and display course names
        //        foreach (var course in student.Courses)
        //        {
        //            Console.WriteLine($"Course: {course.Name}");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Student data not found.");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    // Handle any errors that occur during data retrieval
        //    Console.WriteLine($"An error occurred: {ex.Message}");
        //}


        using var context = new EFCoreDbContext();
        try
        {
            Console.WriteLine("\nExplicit Loading Student Related Data\n");
            // Load a student (only student data is loaded initially)
            var student = context.Students.FirstOrDefault(s => s.StudentId == 1);
            // Display basic student information
            if (student != null)
            {
                Console.WriteLine($"\nStudent Id: {student.StudentId}, Name: {student.FirstName} {student.LastName}, Gender: {student.Gender} \n");
                // Explicitly load the Branch navigation property for the student
                context.Entry(student).Reference(s => s.Branch).Load();
                // Check if Branch is null before accessing its properties
                if (student.Branch != null)
                {
                    Console.WriteLine($"\nBranch Location: {student.Branch.BranchLocation}, Email: {student.Branch.BranchEmail}, Phone: {student.Branch.BranchPhoneNumber} \n");
                }
                else
                {
                    Console.WriteLine("\nBranch data not available.\n");
                }
                // Explicitly load the Branch navigation property for the student
                context.Entry(student).Reference(s => s.Branch).Load();
                // Check if Branch is null before accessing its properties
                if (student.Branch != null)
                {
                    Console.WriteLine($"\nBranch Location: {student.Branch.BranchLocation}, Email: {student.Branch.BranchEmail}, Phone: {student.Branch.BranchPhoneNumber} \n");
                }
                else
                {
                    Console.WriteLine("\nBranch data not available.\n");
                }
            }
            else
            {
                Console.WriteLine("Student data not found.");
            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during data retrieval
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        #endregion Explicit Loading
    }
}