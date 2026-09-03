namespace Indexers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creating the Employee instance
            Employee emp = new Employee(101, "Pranaya", "SSE", 10000, "Mumbai", "IT", "Male");


            #region int Indexer
            //Accessing Employee Properties using Indexers i.e. using Index positions
            Console.WriteLine("EID = " + emp[0]);
            Console.WriteLine("Name = " + emp[1]);
            Console.WriteLine("Job = " + emp[2]);
            Console.WriteLine("Salary = " + emp[3]);
            Console.WriteLine("Location = " + emp[4]);
            Console.WriteLine("Department = " + emp[5]);
            Console.WriteLine("Gender = " + emp[6]);


            //Set the Employee Object using Indexer i.e. using Integer Index P
            emp[1] = "Kumar";
            emp[3] = 65000;
            emp[5] = "BBSR";

            Console.WriteLine("========After Modification========");
            //Access the Employee Object using Indexer i.e. using Integer Inde
            Console.WriteLine("EID = " + emp[0]);
            Console.WriteLine("Name = " + emp[1]);
            Console.WriteLine("Job = " + emp[2]);
            Console.WriteLine("Salary = " + emp[3]);
            Console.WriteLine("Location = " + emp[4]);
            Console.WriteLine("Department = " + emp[5]);
            Console.WriteLine("Gender = " + emp[6]);
            #endregion


            #region string Indexer
            //Access the Employee Object using Indexer i.e. using string Index name
            Console.WriteLine("EID = " + emp["ID"]);
            Console.WriteLine("Name = " + emp["Name"]);
            Console.WriteLine("Job = " + emp["job"]);
            Console.WriteLine("Salary = " + emp["salary"]);
            Console.WriteLine("Location = " + emp["Location"]);
            Console.WriteLine("Department = " + emp["department"]);
            Console.WriteLine("Gender = " + emp["Gender"]);
            //Set the Employee Object using Indexer i.e. using string Index name
            emp["Name"] = "Kumar";
            emp["salary"] = 65000;
            emp["Location"] = "BBSR";

            Console.WriteLine("========Afrer Modification========");
            //Access the Employee Object using Indexer i.e. using string Index name
            Console.WriteLine("EID = " + emp["ID"]);
            Console.WriteLine("Name = " + emp["Name"]);
            Console.WriteLine("Job = " + emp["job"]);
            Console.WriteLine("Salary = " + emp["salary"]);
            Console.WriteLine("Location = " + emp["Location"]);
            Console.WriteLine("Department = " + emp["department"]);
            Console.WriteLine("Gender = " + emp["Gender"]);
            #endregion

            Console.ReadLine();
        }
    }
}
