namespace RealtimeIndexerExample
{
    internal class Company
    {
        //Create a varibale to hold list of Employees
        private List<Employee> listEmployees = new List<Employee>();

        //Through the constructor initialize the listEmployees variable
        public Company()
        {
            listEmployees.Add(new Employee { EmployeeId = 101, Name = "Pranaya", Gender = "Male", Salary = 1000 });
            listEmployees.Add(new Employee { EmployeeId = 102, Name = "Preety", Gender = "Female", Salary = 2000 });
            listEmployees.Add(new Employee { EmployeeId = 103, Name = "Anurag", Gender = "Male", Salary = 5000 });
            listEmployees.Add(new Employee { EmployeeId = 104, Name = "Priyanka", Gender = "Female", Salary = 4000 });
            listEmployees.Add(new Employee { EmployeeId = 105, Name = "Hina", Gender = "Female", Salary = 3000 });
            listEmployees.Add(new Employee { EmployeeId = 106, Name = "Sambit", Gender = "Male", Salary = 6000 });
            listEmployees.Add(new Employee { EmployeeId = 107, Name = "Tarun", Gender = "Male", Salary = 8000 });
            listEmployees.Add(new Employee { EmployeeId = 108, Name = "Santosh", Gender = "Male", Salary = 7000 });
            listEmployees.Add(new Employee { EmployeeId = 109, Name = "Trupti", Gender = "Female", Salary = 5000 });
        }

        // Integer Indexer
        // The indexer takes an employeeId as parameter and returns the employee name
        public string this[int employeeId]
        {
            get
            {
                //Using get accessor return the name of the Employee
                return listEmployees.FirstOrDefault(x => x.EmployeeId == employeeId).Name;
            }
            set
            {
                //Using set accessor return the name of the Employee
                listEmployees.FirstOrDefault(x => x.EmployeeId == employeeId).Name = value;
            }
        }

        //String Indexer
        //The indexer takes an gender as parameter and returns the total count of employees based on the gender
        public string this[string gender]
        {
            get
            {
                // Returns the total count of employees whose gender matches
                // with the gender that is passed in.
                return listEmployees.Count(x => x.Gender.ToLower() == gender.ToLower()).ToString();
            }
            set
            {
                // Changes the gender of all employees whose gender matches
                // with the gender that is passed in.
                foreach (Employee employee in listEmployees)
                {
                    if (employee.Gender == gender)
                    {
                        employee.Gender = value;
                    }
                }
            }
        }
    }
}
