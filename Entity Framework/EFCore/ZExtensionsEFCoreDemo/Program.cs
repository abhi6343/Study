using Microsoft.EntityFrameworkCore;
using ZExtensionsEFCoreDemo.Entities;

namespace ZExtensionsEFCoreDemo
{
    internal class Program
    {
        //static void Main(string[] args)
        static async Task Main(string[] args)
        {
            //try
            //{
            //    // Create a list of new students to insert
            //    List<Student> newStudents =
            //    [
            //        new Student() { FirstName = "Pranaya", LastName = "Rout", Branch = "CSE" },
            //        new Student() { FirstName = "Hina", LastName = "Sharma", Branch = "CSE" },
            //        new Student() { FirstName = "Anurag", LastName = "Mohanty", Branch = "CSE" },
            //        new Student() { FirstName = "Prity", LastName = "Tiwary", Branch = "ETC" }
            //    ];

            //    using var context = new EFCoreDbContext();

            //    // Perform Bulk Insert using EF Extensions
            //    // Inserts all Student entities in the newStudents list into the database in a single, optimized operation.
            //    context.BulkInsert(newStudents);

            //    //No Need for SaveChanges():
            //    //The BulkInsert method handles database interactions internally, eliminating the need to call SaveChanges().
            //    Console.WriteLine("BulkInsert: Successfully inserted new students.");

            //    // Display all students belonging to the CSE branch
            //    DisplayStudentsByBranch("CSE");

            //    Console.ReadKey();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"BulkInsert Error: {ex.Message}");
            //}




            //try
            //{
            //    Console.WriteLine("Starting BulkUpdate Operation...");
            //    // Specify the branch to update
            //    var branchToUpdate = "CSE";
            //    // Perform Bulk Update
            //    BulkUpdateStudents(branchToUpdate);
            //    Console.WriteLine("BulkUpdate: Successfully updated student records.");
            //    // Display updated students to verify changes
            //    DisplayStudentsByBranch(branchToUpdate);
            //    Console.ReadKey();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"BulkUpdate Error: {ex.Message}");
            //}



            //try
            //{
            //    Console.WriteLine("Starting BulkDelete Operation...");
            //    // Specify the branch to delete students from
            //    string branchToDelete = "ETC";
            //    // Perform Bulk Delete
            //    BulkDeleteStudents(branchToDelete);
            //    Console.WriteLine("BulkDelete: Successfully deleted student records.");
            //    // Display remaining students to verify deletion
            //    DisplayStudentsByBranch("CSE");
            //    DisplayStudentsByBranch("ETC");
            //    Console.ReadKey();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"BulkDelete Error: {ex.Message}");
            //}




            //Console.WriteLine("=== EF Core Asynchronous CRUD Operations with EF Extensions ===\n");
            //try
            //{
            //    // Initialize the DbContext
            //    using var context = new EFCoreDbContext();
            //    // 1. Create (Bulk Insert) Operation
            //    await BulkInsertStudentsAsync(context);
            //    // 2. Read Operation
            //    await DisplayStudentsByBranchAsync(context, "CSE");
            //    // 3. Update (Bulk Update) Operation
            //    await BulkUpdateStudentsAsync(context, "CSE");
            //    // 4. Read Operation to verify updates
            //    await DisplayStudentsByBranchAsync(context, "CSE");
            //    // 5. Delete (Bulk Delete) Operation
            //    await BulkDeleteStudentsAsync(context, "ETC");
            //    // 6. Read Operations to verify deletions
            //    await DisplayStudentsByBranchAsync(context, "CSE");
            //    await DisplayStudentsByBranchAsync(context, "ETC");
            //}
            //catch (Exception ex)
            //{
            //    // Handle any unexpected exceptions
            //    Console.WriteLine($"\nAn unexpected error occurred: {ex.Message}");
            //}




            //try
            //{
            //    Console.WriteLine("Starting BulkMerge operation...");
            //    // Perform Bulk Merge operation
            //    await BulkMergeAsync();
            //    Console.WriteLine("BulkMerge operation completed.");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"An error occurred: {ex.Message}");
            //}




            try
            {
                Console.WriteLine("Starting BulkSaveChanges operation...");
                // Perform Bulk SaveChanges operation
                await BulkSaveChangesAsync();
                Console.WriteLine("BulkSaveChanges operation completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        private static async Task BulkSaveChangesAsync()
        {
            using var context = new EFCoreDbContext();
            // Fetch existing students from the database
            var existingStudents = await context.Students.Where(s => s.Branch == "CSE").ToListAsync();
            // Updating existing students (append 'Updated' to their names)
            foreach (var student in existingStudents)
            {
                student.FirstName += " Updated";
                student.LastName += " Updated";
            }
            // Adding a new student to the context
            context.Students.Add(new Student { FirstName = "New", LastName = "Student", Branch = "ETC" });
            // Deleting a student from the context (this will be batched in the BulkSaveChanges)
            var studentToDelete = await context.Students.Where(s => s.FirstName == "Sethy").FirstOrDefaultAsync();
            if (studentToDelete != null)
            {
                context.Students.Remove(studentToDelete);
            }
            // Perform BulkSaveChanges to save all updates, inserts, and deletes in one go
            await context.BulkSaveChangesAsync();
            // Display current students in the database after the save
            await DisplayStudentsAsync();
        }
        private static async Task BulkMergeAsync()
        {
            using var context = new EFCoreDbContext();
            // Existing list of students to merge (sync) with the database
            List<Student> studentsToMerge =
            [
                // Assume that StudentId 1 exists and will be updated
                new Student { StudentId = 1, FirstName = "John", LastName = "Doe Updated", Branch = "CSE" },
                
                // This is a new student that will be inserted
                new Student { FirstName = "Ramesh", LastName = "Sethy", Branch = "CSE" }
            ];
            // Perform BulkMerge operation:
            // - Updates student with StudentId = 1
            // - Inserts new student without an ID
            await context.BulkMergeAsync(studentsToMerge);
            // Display current students in the database after the merge
            await DisplayStudentsAsync();
        }

        private static async Task DisplayStudentsAsync()
        {
            using var context = new EFCoreDbContext();
            var students = await context.Students.ToListAsync();
            Console.WriteLine("Current Students in the database:");
            foreach (var student in students)
            {
                Console.WriteLine($"\tID: {student.StudentId}, Name: {student.FirstName} {student.LastName}, Branch: {student.Branch}");
            }
            Console.WriteLine();  // Blank line for better readability
        }
        // Performs bulk insert of new students asynchronously.
        private static async Task BulkInsertStudentsAsync(EFCoreDbContext context)
        {
            Console.WriteLine("1. Starting Bulk Insert Operation...");
            // Define a list of new students to insert
            List<Student> newStudents =
            [
                new Student() { FirstName = "Alice", LastName = "Johnson", Branch = "CSE" },
                new Student() { FirstName = "Bob", LastName = "Smith", Branch = "CSE" },
                new Student() { FirstName = "Charlie", LastName = "Brown", Branch = "ETC" },
                new Student() { FirstName = "Diana", LastName = "Prince", Branch = "ETC" }
            ];
            try
            {
                // Perform Bulk Insert asynchronously
                await context.BulkInsertAsync(newStudents);
                Console.WriteLine("Bulk Insert: Successfully inserted new students.\n");
            }
            catch (Exception ex)
            {
                // Handle exceptions related to bulk insert
                Console.WriteLine($"Bulk Insert Error: {ex.Message}\n");
            }
        }
        // Displays students belonging to a specific branch asynchronously.
        private static async Task DisplayStudentsByBranchAsync(EFCoreDbContext context, string branch)
        {
            Console.WriteLine($"2. Retrieving Students in '{branch}' Branch...\n");
            try
            {
                // Fetch students asynchronously with no tracking for performance
                var studentsList = await context.Students.AsNoTracking().Where(std => std.Branch == branch).ToListAsync();
                if (studentsList.Count != 0)
                {
                    Console.WriteLine($"Students in '{branch}' Branch:");
                    Console.WriteLine("-------------------------------------------------");
                    foreach (var student in studentsList)
                    {
                        Console.WriteLine($"\tID: {student.StudentId}, Name: {student.FirstName} {student.LastName}, Branch: {student.Branch}");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"No students found in '{branch}' Branch.\n");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions related to data retrieval
                Console.WriteLine($"Read Error: {ex.Message}\n");
            }
        }
        // Performs bulk update of students' names asynchronously.
        private static async Task BulkUpdateStudentsAsync(EFCoreDbContext context, string branch)
        {
            Console.WriteLine("3. Starting Bulk Update Operation...");
            try
            {
                // Fetch students asynchronously
                var studentsToUpdate = await context.Students.Where(std => std.Branch == branch).ToListAsync();
                if (studentsToUpdate.Count != 0)
                {
                    // Modify the desired properties for each student
                    foreach (var student in studentsToUpdate)
                    {
                        student.FirstName += " Updated";
                        student.LastName += " Updated";
                    }
                    // Perform Bulk Update asynchronously
                    await context.BulkUpdateAsync(studentsToUpdate);
                    Console.WriteLine("Bulk Update: Successfully updated student records.\n");
                }
                else
                {
                    Console.WriteLine($"No students found in '{branch}' Branch to update.\n");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions related to bulk update
                Console.WriteLine($"Bulk Update Error: {ex.Message}\n");
            }
        }
        // Performs bulk delete of students belonging to a specific branch asynchronously.
        private static async Task BulkDeleteStudentsAsync(EFCoreDbContext context, string branch)
        {
            Console.WriteLine("4. Starting Bulk Delete Operation...");
            try
            {
                // Fetch students asynchronously
                var studentsToDelete = await context.Students.Where(std => std.Branch == branch).ToListAsync();
                if (studentsToDelete.Count != 0)
                {
                    // Perform Bulk Delete asynchronously
                    await context.BulkDeleteAsync(studentsToDelete);
                    Console.WriteLine($"Bulk Delete: Successfully deleted students from '{branch}' Branch.\n");
                }
                else
                {
                    Console.WriteLine($"No students found in '{branch}' Branch to delete.\n");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions related to bulk delete
                Console.WriteLine($"Bulk Delete Error: {ex.Message}\n");
            }
        }
        // Deletes all students belonging to the specified branch.
        public static void BulkDeleteStudents(string branch)
        {
            using var context = new EFCoreDbContext();
            // Fetch students belonging to the specified branch
            var studentsToDelete = context.Students.Where(std => std.Branch == branch).ToList();
            // Perform Bulk Delete using EF Extensions
            context.BulkDelete(studentsToDelete);
        }

        //Updates the first and last names of students in the specified branch.
        public static void BulkUpdateStudents(string branch)
        {
            using var context = new EFCoreDbContext();
            // Fetch students belonging to the specified branch
            var studentsToUpdate = context.Students.Where(std => std.Branch == branch).ToList();
            // Modify the desired properties for each student
            foreach (var student in studentsToUpdate)
            {
                student.FirstName += " Updated";
                student.LastName += " Updated";
            }
            // Perform Bulk Update using EF Extensions
            context.BulkUpdate(studentsToUpdate);
        }

        // Retrieves and displays students from a specified branch.
        public static void DisplayStudentsByBranch(string branch)
        {
            using var context = new EFCoreDbContext();

            // Fetch all students where Branch matches the specified value
            var studentsList = context.Students.AsNoTracking() // Improves performance for read-only operations
                                      .Where(std => std.Branch == branch).ToList();

            Console.WriteLine($"\nStudents in {branch} Branch:");
            foreach (var student in studentsList)
            {
                Console.WriteLine($"\tStudent ID: {student.StudentId}, Name: {student.FirstName} {student.LastName}, Branch: {student.Branch}");
            }
        }
    }
}