namespace RealtimeIndexerExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //#region int indexer
            ////Create an Instance of the Company class
            //Company company = new Company();
            ////Accessing the Name of the Employee using Integer Indexer of Company Object
            //Console.WriteLine("Name of Employee with Id = 101: " + company[101]);
            //Console.WriteLine("Name of Employee with Id = 105: " + company[105]);
            //Console.WriteLine("Name of Employee with Id = 107: " + company[107]);

            //Console.WriteLine();
            //Console.WriteLine("Changing the names of employees with Id = 101,105,107");
            ////Setting the Name of the Employee using Integer Indexer of Company Object
            //company[101] = "Employee 101 Name Changed";
            //company[105] = "Employee 105 Name Changed";
            //company[107] = "Employee 107 Name Changed";
            //Console.WriteLine();
            ////Accessing the Name of the Employee using Integer Indexer of Company Object
            //Console.WriteLine("Name of Employee with Id = 101: " + company[101]);
            //Console.WriteLine("Name of Employee with Id = 105: " + company[105]);
            //Console.WriteLine("Name of Employee with Id = 107: " + company[107]);
            //#endregion


            #region String indexer
            // Create an Instance of the Company Class
            Company company = new Company();
            Console.WriteLine("Before changing the Gender of all the male employees to Female");
            Console.WriteLine();
            // Get accessor of string indexer is invoked to return the total count of male employees
            Console.WriteLine("Total Number Employees with Gender = Male:" + company["Male"]);
            Console.WriteLine();
            Console.WriteLine("Total Number Employees with Gender = Female:" + company["Female"]);
            Console.WriteLine();
            // Set accessor of string indexer is invoked to change the gender all "Male" employees to "Female"
            company["Male"] = "Female";
            Console.WriteLine("After changing the Gender of all male employees to Female");
            Console.WriteLine();
            Console.WriteLine("Total Employees with Gender = Male:" + company["Male"]);
            Console.WriteLine();
            Console.WriteLine("Total Employees with Gender = Female:" + company["Female"]);
            #endregion
        }
    }
}
