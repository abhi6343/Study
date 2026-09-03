using EFCore;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the DbContext class
            //using var context = new EFCoreDbContextFactory().CreateDbContext(args);
            //// Adding two new Branches
            //AddBranches(context);
            //// Adding two new Students
            //AddStudents(context);
            //// Retrieve and display all students
            //GetAllStudents(context);
            //// Retrieve and display a single student by ID
            //GetStudentById(context, 1); // Assuming 1 is the StudentId
            //                            // Update a student's information
            //UpdateStudent(context, 1); // Assuming 1 is the StudentId
            //                           // Delete a student by ID
            //DeleteStudent(context, 2); // Assuming 2 is the StudentId
            //                           // Final retrieval to confirm operations
            //GetAllStudents(context);
            //Console.WriteLine("All operations completed successfully!");

            //try
            //{
            //    // Create an instance of the DbContext class
            //    using var context1 = new EFCoreDbContext();
            //    AddBranches(context1);
            //    // Adding two new Students
            //    AddStudents(context1);
            //    // Retrieve and display all students
            //    GetAllStudents(context1);
            //    // Retrieve and display a single student by ID
            //    GetStudentById(context1, 1); // Assuming 1 is the StudentId
            //                                // Update a student's information
            //    UpdateStudent(context1, 1); // Assuming 1 is the StudentId
            //                               // Delete a student by ID
            //    DeleteStudent(context1, 2); // Assuming 2 is the StudentId
            //                               // Final retrieval to confirm operations
            //    GetAllStudents(context1);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error: {ex.Message}"); ;
            //}
            //try
            //{
            //    // Create an instance of your EFCoreDbContext to interact with the database
            //    using var context = new EFCoreDbContext();
            //    // Create two new Branch objects
            //    var CSEBranch = new Branch
            //    {
            //        BranchName = "Computer Science",
            //        Description = "Focuses on software development and computing technologies.",
            //        PhoneNumber = "123-456-7890",
            //        Email = "cs@dotnettutorials.net"
            //    };
            //    var ElectricalBranch = new Branch
            //    {
            //        BranchName = "Electrical Engineering",
            //        Description = "Focuses on electrical systems and circuit design.",
            //        PhoneNumber = "987-654-3210",
            //        Email = "ee@dotnettutorials.net"
            //    };
            //    // Adding the Branch objects to the Branches DbSet
            //    // This prepares the object to be inserted into the database
            //    context.Branches.Add(CSEBranch);
            //    context.Branches.Add(ElectricalBranch);
            //    // Alternatively, you can use the DbContext.Add method to add entities
            //    // context.Add(CSEBranch);
            //    // context.Add(ElectricalBranch);
            //    // Create two new Student objects
            //    var student1 = new Student
            //    {
            //        FirstName = "Pranaya",
            //        LastName = "Rout",
            //        DateOfBirth = new DateTime(2000, 1, 15),
            //        Gender = "Female",
            //        Email = "Pranaya.Rout@dotnettutorials.net",
            //        PhoneNumber = "555-1234",
            //        EnrollmentDate = DateTime.Now,
            //        Branch = CSEBranch // Assign the Computer Science branch
            //    };
            //    var student2 = new Student
            //    {
            //        FirstName = "Rakesh",
            //        LastName = "Kumar",
            //        DateOfBirth = new DateTime(1999, 10, 22),
            //        Gender = "Male",
            //        Email = "Rakesh.Kumar@dotnettutorials.net",
            //        PhoneNumber = "555-5678",
            //        EnrollmentDate = DateTime.Now,
            //        Branch = ElectricalBranch // Assign the Electrical Engineering branch
            //    };
            //    // Adding the Student objects to the Students DbSet
            //    // This prepares the object to be inserted into the database
            //    context.Students.Add(student1);
            //    context.Students.Add(student2);
            //    // Alternatively, you can use the DbContext.Add method to add entities
            //    // context.Add(student1);
            //    // context.Add(student2);
            //    // Save the changes to the database
            //    // This actually performs the INSERT operation in the database
            //    context.SaveChanges();
            //    // Display a success message on the console
            //    Console.WriteLine("Branch and Student records have been successfully inserted into the database.");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error: {ex.Message}"); ;
            //}
            //try
            //{
            //    // Create an instance of your EFCoreDbContext to interact with the database
            //    using var context = new EFCoreDbContext();
            //    // Retrieve the student whose Id is 1 from the database using Find method
            //    // The Find method takes the Primary Key
            //    var student = context.Students.Find(1);

            //    // Check if a student was found with ID 1
            //    if (student != null)
            //    {
            //        // Display the original data before updating
            //        Console.WriteLine("Original Student Data:");
            //        Console.WriteLine($"Name: {student.FirstName} {student.LastName}");
            //        Console.WriteLine($"Email: {student.Email}");
            //        // Modify the student's properties that need to be updated
            //        student.FirstName = "Paresh"; // Changing the first name
            //        student.LastName = "Mohanty"; // Changing the last name
            //        student.Email = "Paresh.Mohanty@dotnettutrials.net"; // Changing the email
            //                                                             // Save the changes to the database
            //        context.SaveChanges();
            //        // Display a success message on the console
            //        Console.WriteLine("Student data has been successfully updated.");
            //        // Display the updated data
            //        Console.WriteLine("Updated Student Data:");
            //        Console.WriteLine($"Name: {student.FirstName} {student.LastName}");
            //        Console.WriteLine($"Email: {student.Email}");
            //    }
            //    else
            //    {
            //        // Display a message if no student was found
            //        Console.WriteLine("No student found to update.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error: {ex.Message}"); ;
            //}

            //try
            //{
            //    // Create an instance of your EFCoreDbContext to interact with the database
            //    using var context = new EFCoreDbContext();
            //    // Retrieve the student with ID 1 from the database using LINQ's FirstOrDefault method
            //    var student = context.Students.FirstOrDefault(s => s.StudentId == 1);
            //    // Check if a student with ID 1 was found to avoid null reference exceptions
            //    if (student != null)
            //    {
            //        // Display the student data before deletion
            //        Console.WriteLine("Student Data Before Deletion:");
            //        Console.WriteLine($"ID: {student.StudentId}");
            //        Console.WriteLine($"Name: {student.FirstName} {student.LastName}");
            //        Console.WriteLine($"Email: {student.Email}");
            //        // Remove the student entity from the DbSet
            //        // This marks the entity for deletion in the context
            //        context.Students.Remove(student);
            //        // Alternatively, you can use the DbContext.Remove method to remove entities
            //        // context.Remove(student);
            //        // Save the changes to the database
            //        // This actually performs the DELETE operation in the database
            //        context.SaveChanges();
            //        // Display a success message on the console
            //        Console.WriteLine("Student record has been successfully deleted from the database.");
            //    }
            //    else
            //    {
            //        // Display a message if no student with the specified ID was found
            //        Console.WriteLine("No student found with ID 1 to delete.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error: {ex.Message}"); ;
            //}

            //try
            //{
            //    using var context = new EFCoreDbContext();
            //    // Create a new Branch
            //    var branch = new Branch
            //    {
            //        BranchName = "Computer Science",
            //        Description = "Computer Science Department",
            //        PhoneNumber = "123-456-7890",
            //        Email = "cs@example.com"
            //    };
            //    // Create a new Student
            //    var student = new Student
            //    {
            //        FirstName = "John",
            //        LastName = "Doe",
            //        DateOfBirth = new DateTime(2000, 1, 1),
            //        Gender = "Male",
            //        Email = "john.doe@example.com",
            //        PhoneNumber = "555-555-5555",
            //        EnrollmentDate = DateTime.Now,
            //        Branch = branch
            //    };
            //    // Display the Student Entity state before adding to the context
            //    Console.WriteLine($"Student Entity State before adding to the context: {context.Entry(student).State}");
            //    // Add the student to the context
            //    // Using DbSet Add Methid
            //    context.Students.Add(student);
            //    // Using DbContext Add Methid
            //    // context.Add(student);
            //    // Display the Student Entity state after adding to the context
            //    Console.WriteLine($"Student Entity State after adding to the context: {context.Entry(student).State} \n");
            //    // Save changes to the database
            //    // This will save both Branch and Student entity to the database
            //    context.SaveChanges();
            //    // Display the Student Entity state after saving changes
            //    Console.WriteLine($"\nStudent Entity State after saving changes: {context.Entry(student).State}");
            //}
            //catch (DbUpdateException dbEx)
            //{
            //    Console.WriteLine($"Database update error: {dbEx.Message}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"An error occurred: {ex.Message}");
            //}

            //try
            //{
            //    using var context = new EFCoreDbContext();
            //    // Retrieve the Student with StudentId 1 from the database
            //    var student = context.Students.Find(1);
            //    if (student == null)
            //    {
            //        Console.WriteLine("Student with ID 1 not found.");
            //        return;
            //    }
            //    // Display the state of the student after retrieval
            //    Console.WriteLine($"Entity State after retrieval: {context.Entry(student).State}");
            //    // Simulate calling SaveChanges without modifying the entity
            //    context.SaveChanges();
            //    Console.WriteLine("SaveChanges called. Since the entity was in the Unchanged state, no operations were performed on the database.");
            //    Console.WriteLine($"Entity State after SaveChanges: {context.Entry(student).State}");
            //}
            //catch (DbUpdateException dbEx)
            //{
            //    Console.WriteLine($"Database update error: {dbEx.Message}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"An error occurred: {ex.Message}");
            //}

            //try
            //{
            //    // Simulating a list of student phone number updates received from an external source
            //    var studentUpdates = new List<Student>
            //    {
            //        //Currently we have only one entity in the database with Id 1
            //        new() { StudentId = 1, PhoneNumber = "111-111-1111", Email="john.doe@dotnettutorials.com" }
            //    };
            //    using var context = new EFCoreDbContext();
            //    foreach (var updatedStudent in studentUpdates)
            //    {
            //        // Initial state before attaching (Detached)
            //        Console.WriteLine($"Before Attach: StudentId {updatedStudent.StudentId}, State: {context.Entry(updatedStudent).State}");
            //        // Attach the student to the context (state should be Unchanged)
            //        context.Students.Attach(updatedStudent);
            //        Console.WriteLine($"After Attach: StudentId {updatedStudent.StudentId}, State: {context.Entry(updatedStudent).State}");
            //        // Mark the PhoneNumber and Email properties as modified (state should be Modified)
            //        context.Entry(updatedStudent).Property(s => s.PhoneNumber).IsModified = true;
            //        context.Entry(updatedStudent).Property(s => s.Email).IsModified = true;
            //        Console.WriteLine($"After Marking PhoneNumber as Modified: StudentId {updatedStudent.StudentId}, State: {context.Entry(updatedStudent).State}");
            //    }
            //    // Save all changes to the database in one batch
            //    context.SaveChanges();
            //    Console.WriteLine("Student Phone numbers and Emails Updated successfully.");
            //    // Final state after saving (should be Unchanged)
            //    foreach (var updatedStudent in studentUpdates)
            //    {
            //        Console.WriteLine($"After SaveChanges: StudentId {updatedStudent.StudentId}, State: {context.Entry(updatedStudent).State}");
            //    }
            //}
            //catch (DbUpdateException dbEx)
            //{
            //    Console.WriteLine($"Database update error: {dbEx.Message}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"An error occurred: {ex.Message}");
            //}

            //try
            //{
            //    using var context = new EFCoreDbContext();
            //    // Fetching students from the database who have an email with "dotnettutorials.com" domain
            //    var studentsToProcess = context.Students
            //                                   .Where(s => s.Email.Contains("dotnettutorials.com"))
            //                                   .ToList();
            //    foreach (var student in studentsToProcess)
            //    {
            //        // Update the student's Email address by replacing the domain with "example.com"
            //        student.Email = ReplaceDomain(student.Email, "example.com");
            //        // Save changes to the database
            //        context.SaveChanges();
            //        Console.WriteLine($"StudentId {student.StudentId} email updated to '{student.Email}'");
            //        // Detach the student to free up memory after processing
            //        context.Entry(student).State = EntityState.Detached;
            //        Console.WriteLine($"Detached StudentId {student.StudentId}, State: {context.Entry(student).State}");
            //    }
            //    Console.WriteLine("All students processed successfully.");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"An error occurred: {ex.Message}");
            //}

            //try
            //{
            //    using var context = new EFCoreDbContext();
            //    // Fetch the student from the database
            //    var student = context.Students.FirstOrDefault(s => s.StudentId == 1);
            //    if (student != null)
            //    {
            //        Console.WriteLine($"Initial State: {context.Entry(student).State}");
            //        // Update the student's phone number
            //        student.PhoneNumber = "555-123-4567";
            //        // EF Core will automatically mark the entity as Modified
            //        Console.WriteLine($"State after modifying PhoneNumber: {context.Entry(student).State}");
            //        // Save changes to the database
            //        context.SaveChanges();
            //        Console.WriteLine("Student phone number updated successfully.");
            //        // State after saving changes should be Unchanged
            //        Console.WriteLine($"State after SaveChanges: {context.Entry(student).State}");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Student not found.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"An error occurred: {ex.Message}");
            //}

            try
            {
                using var context = new EFCoreDbContext();
                // Fetch the student from the database
                // When the student is retrieved, its initial state is Unchanged, indicating that no changes have been made.
                var student = context.Students.FirstOrDefault(s => s.StudentId == 1);
                if (student != null)
                {
                    Console.WriteLine($"Initial State: {context.Entry(student).State}");
                    //The Remove method is called on the student entity.
                    //This method marks the entity as Deleted.
                    context.Students.Remove(student);
                    //After calling Remove, the entity’s state changes to Deleted, which is tracked by EF Core.
                    // The state should now be Deleted
                    Console.WriteLine($"State after marking for deletion: {context.Entry(student).State}");
                    // When SaveChanges() is called, EF Core generates a DELETE SQL statement to remove the student's record from the database.
                    // Save changes to the database (this will delete the record)
                    context.SaveChanges();
                    //After SaveChanges() completes, the entity is no longer tracked by the context because it has been deleted.
                    Console.WriteLine("Student record deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        // Helper method to replace the email domain
        static string ReplaceDomain(string email, string newDomain)
        {
            var atIndex = email.IndexOf('@');
            if (atIndex >= 0)
            {
                return email[..(atIndex + 1)] + newDomain;
            }
            return email; // In case the email doesn't contain '@', return it as is
        }
        


        private static void AddBranches(EFCoreDbContext context)
        {
            // Create two new Branch objects
            var branch1 = new Branch
            {
                BranchName = "Computer Science",
                Description = "Focuses on software development and computing technologies.",
                PhoneNumber = "123-456-7890",
                Email = "cs@dotnettutorials.net"
            };
            var branch2 = new Branch
            {
                BranchName = "Electrical Engineering",
                Description = "Focuses on electrical systems and circuit design.",
                PhoneNumber = "987-654-3210",
                Email = "ee@dotnettutorials.net"
            };
            // Add the branches to the context
            context.Branches.Add(branch1);
            context.Branches.Add(branch2);
            // Save changes to the database
            context.SaveChanges();
            Console.WriteLine("Branches added successfully!");
        }
        private static void AddStudents(EFCoreDbContext context)
        {
            // Retrieve the branches from the context
            var csBranch = context.Branches.FirstOrDefault(b => b.BranchName == "Computer Science");
            var eeBranch = context.Branches.FirstOrDefault(b => b.BranchName == "Electrical Engineering");
            // Create two new Student objects
            var student1 = new Student
            {
                FirstName = "Pranaya",
                LastName = "Rout",
                DateOfBirth = new DateTime(2000, 1, 15),
                Gender = "Female",
                Email = "Pranaya.Rout@dotnettutorials.net",
                PhoneNumber = "555-1234",
                EnrollmentDate = DateTime.Now,
                Branch = csBranch // Assign the Computer Science branch
            };
            var student2 = new Student
            {
                FirstName = "Rakesh",
                LastName = "Kumar",
                DateOfBirth = new DateTime(1999, 10, 22),
                Gender = "Male",
                Email = "Rakesh.Kumar@dotnettutorials.net",
                PhoneNumber = "555-5678",
                EnrollmentDate = DateTime.Now,
                Branch = eeBranch // Assign the Electrical Engineering branch
            };
            // Add the students to the context
            context.Students.Add(student1);
            context.Students.Add(student2);
            // Save changes to the database
            context.SaveChanges();
            Console.WriteLine("Students added successfully!");
        }
        private static void GetAllStudents(EFCoreDbContext context)
        {
            // Retrieve all students from the context
            var students = context.Students.Include(s => s.Branch).ToList();
            // Display the students in the console
            Console.WriteLine("All Students:");
            foreach (var student in students)
            {
                Console.WriteLine($"\t{student.StudentId}: {student.FirstName} {student.LastName}, Branch: {student.Branch?.BranchName}");
            }
        }
        private static void GetStudentById(EFCoreDbContext context, int studentId)
        {
            // Retrieve a single student by ID
            var student = context.Students.Include(s => s.Branch).FirstOrDefault(s => s.StudentId == studentId);
            if (student != null)
            {
                Console.WriteLine($"Student found: {student.FirstName} {student.LastName}, Branch: {student.Branch?.BranchName}");
            }
            else
            {
                Console.WriteLine($"Student with ID {studentId} not found.");
            }
        }
        private static void UpdateStudent(EFCoreDbContext context, int studentId)
        {
            // Retrieve the student from the context
            var student = context.Students.FirstOrDefault(s => s.StudentId == studentId);
            if (student != null)
            {
                // Update the student's information
                student.LastName = "UpdatedLastName";
                student.Email = "updated.email@dotnettutorials.net";
                // Save changes to the database
                context.SaveChanges();
                Console.WriteLine($"Student with ID {studentId} updated successfully.");
            }
            else
            {
                Console.WriteLine($"Student with ID {studentId} not found.");
            }
        }
        private static void DeleteStudent(EFCoreDbContext context, int studentId)
        {
            // Retrieve the student from the context
            var student = context.Students.FirstOrDefault(s => s.StudentId == studentId);
            if (student != null)
            {
                // Remove the student from the context
                context.Students.Remove(student);
                // Save changes to the database
                context.SaveChanges();
                Console.WriteLine($"Student with ID {studentId} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Student with ID {studentId} not found.");
            }
        }
    }
}