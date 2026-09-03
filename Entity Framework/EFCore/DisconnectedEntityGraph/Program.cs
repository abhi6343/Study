using DisconnectedEntityGraph.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisconnectedEntityGraph
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Creating the Disconnected Entity Graph
                //Student Entity Graph (Student plus Standard, and StudentAddress)
                //Student is the Main Entity
                //Standard, and StudentAddress are the Child Entities
                var student = new Student()
                {
                    //Root Entity with Empty key
                    FirstName = "Pranaya",
                    LastName = "Rout",
                    StandardId = 1,
                    //Make Sure the StandardId with Value 1 Exists in the Database, else you will get Exception
                    Standard = new Standard()   //Child Entity with key value
                    {
                        StandardId = 1,
                        StandardName = "STD1",
                        Description = "STD1 Description"
                    },
                    StudentAddress = new StudentAddress() //Child Entity with Empty Key
                    {
                        Address1 = "Address Line1",
                        Address2 = "Address Line2"
                    }
                };
                //Creating an Instance of the Context class
                using var context = new EFCoreDbContext();
                //Attaching the Disconnected Student Entity Graph to the Context Object 
                context.Attach(student).State = EntityState.Added;
                //Checking the Entity State of Each Entity of student Entity Graph
                foreach (var entity in context.ChangeTracker.Entries())
                {
                    Console.WriteLine($"Entity: {entity.Entity.GetType().Name}, State: {entity.State} ");
                }
                // Save changes to persist the changes to the database
                context.SaveChanges();
                Console.WriteLine("Entity Graph Saved Successfully");
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}"); ;
            }







            try
            {
                //Creating the Disconnected Entity Graph
                //Student Entity Graph (Student plus Standard, and StudentAddress)
                //Student is the Main Entity
                //Standard, and StudentAddress are the Child Entities
                var student = new Student()
                {
                    //Root Entity with Empty key
                    FirstName = "Pranaya",
                    LastName = "Rout",
                    StandardId = 1,
                    Standard = new Standard()   //Child Entity with key value
                    {
                        StandardId = 1,
                        StandardName = "STD1",
                        Description = "STD1 Description"
                    },
                    StudentAddress = new StudentAddress() //Child Entity with Empty Key
                    {
                        Address1 = "Address Line1",
                        Address2 = "Address Line2"
                    }
                };
                //Creating an Instance of the Context class
                using var context = new EFCoreDbContext();
                //Attaching the Disconnected Student Entity Graph to the Context Object 
                context.Entry(student).State = EntityState.Added;
                //Checking the Entity State of Each Entity of student Entity Graph
                foreach (var entity in context.ChangeTracker.Entries())
                {
                    Console.WriteLine($"Entity: {entity.Entity.GetType().Name}, State: {entity.State} ");
                }
                // Save changes to persist the changes to the database
                context.SaveChanges();
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}"); ;
            }



            try
            {
                //Creating the Disconnected Entity Graph
                //Student Entity Graph (Student plus Standard, and StudentAddress)
                //Student is the Main Entity
                //Standard, and StudentAddress are the Child Entities
                var student = new Student()
                {
                    //Root Entity with key
                    //StudentId = 1, //It is Identity, so you cannot set Explicit Value
                    FirstName = "Pranaya",
                    LastName = "Rout",
                    StandardId = 1,
                    Standard = new Standard()   //Child Entity with key value
                    {
                        // StandardId = 1, //It is Identity, so you cannot set Explicit Value
                        StandardName = "STD1",
                        Description = "STD1 Description"
                    },
                    StudentAddress = new StudentAddress() //Child Entity with Empty Key
                    {
                        Address1 = "Address Line1",
                        Address2 = "Address Line2"
                    }
                };
                //Creating an Instance of the Context class
                using var context = new EFCoreDbContext();
                //Attaching the Disconnected Student Entity Graph to the Context Object 
                context.Students.Add(student);
                //Checking the Entity State of Each Entity of student Entity Graph
                foreach (var entity in context.ChangeTracker.Entries())
                {
                    Console.WriteLine($"Entity: {entity.Entity.GetType().Name}, State: {entity.State} ");
                }
                // Save changes to persist the changes to the database
                context.SaveChanges();
                Console.WriteLine("Entity Graph Added");
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}"); ;
            }







            try
            {
                //Creating the Disconnected Entity Graph
                //Student Entity Graph (Student plus Standard, and StudentAddress)
                //Student is the Main Entity
                //Standard, and StudentAddress are the Child Entities
                var student = new Student()
                {
                    //Root Entity without key
                    FirstName = "Pranaya",
                    LastName = "Rout",
                    StandardId = 1,
                    Standard = new Standard()   //Child Entity with key value
                    {
                        StandardId = 1,
                        StandardName = "STD1",
                        Description = "STD1 Description"
                    },
                    StudentAddress = new StudentAddress() //Child Entity with Empty Key
                    {
                        Address1 = "Address Line1",
                        Address2 = "Address Line2"
                    }
                };
                //Creating an Instance of the Context class
                using var context = new EFCoreDbContext();
                context.ChangeTracker.TrackGraph(student, e =>
                {
                    if (e.Entry.IsKeySet)
                    {
                        //If Key is Available set the State as Unchanged or Modified as Per Your Requirement
                        e.Entry.State = EntityState.Unchanged;
                    }
                    else
                    {
                        // If Key is not Available set the State as Added
                        e.Entry.State = EntityState.Added;
                    }
                });
                //Checking the Entity State of Each Entity of student Entity Graph
                foreach (var entity in context.ChangeTracker.Entries())
                {
                    Console.WriteLine($"Entity: {entity.Entity.GetType().Name}, State: {entity.State} ");
                }
                // Save changes to persist the changes to the database
                context.SaveChanges();
                Console.WriteLine("Entity Graph Saved..");
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}"); ;
            }




            try
            {
                //Creating the Disconnected Entity Graph
                //Student Entity Graph (Student plus Standard, and StudentAddress)
                //Student is the Main Entity
                //Standard, and StudentAddress are the Child Entities
                var student = new Student()
                {
                    //Root Entity without key
                    FirstName = "Hina",
                    LastName = "Sharma",
                    StandardId = 1,
                    Standard = new Standard()   //Child Entity with key value
                    {
                        StandardId = 1,
                        StandardName = "STD1",
                        Description = "STD1 Description"
                    },
                    StudentAddress = new StudentAddress() //Child Entity with Empty Key
                    {
                        Address1 = "Address Line1",
                        Address2 = "Address Line2"
                    }
                };
                using var context = new EFCoreDbContext();
                // Use TrackGraph to track the entire graph
                context.ChangeTracker.TrackGraph(student, nodeEntry =>
                {
                    // Customize tracking behavior for each entity
                    //Setting the Root Entity, i.e., Student
                    if (nodeEntry.Entry.Entity is Student std)
                    {
                        if (std.StudentId > 0)
                        {
                            nodeEntry.Entry.State = EntityState.Modified;
                        }
                        else
                        {
                            nodeEntry.Entry.State = EntityState.Added;
                        }
                    }
                    //Setting the Child Entity i.e. Standard and StudentAddress
                    else
                    {
                        if (nodeEntry.Entry.IsKeySet)
                        {
                            //If Key is Available set the State as Unchanged as Per Your Requirement
                            nodeEntry.Entry.State = EntityState.Unchanged;
                        }
                        else
                        {
                            // If Key is not Available set the State as Added as Per Your Requirement
                            nodeEntry.Entry.State = EntityState.Added;
                        }
                    }
                });
                //Checking the Entity State of Each Entity of student Entity Graph
                foreach (var entity in context.ChangeTracker.Entries())
                {
                    Console.WriteLine($"Entity: {entity.Entity.GetType().Name}, State: {entity.State} ");
                }
                // Save changes to persist the changes to the database
                context.SaveChanges();
                Console.WriteLine("Entity Graph Saved..");
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}"); ;
            }
        }
    }
}