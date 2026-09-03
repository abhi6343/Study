namespace Indexers
{
    internal class Employee
    {
        #region Properties
        //Declare the Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public double Salary { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        #endregion


        #region Constructor
        //Initialize the Properties through Constructor
        public Employee(int ID, string Name, string Job, int Salary, string Location,
                        string Department, string Gender)
        {
            this.ID = ID;
            this.Name = Name;
            this.Job = Job;
            this.Salary = Salary;
            this.Location = Location;
            this.Department = Department;
            this.Gender = Gender;
        }
        #endregion


        #region int Indexer
        //Creating the Indexer using Integer Index Position
        public object this[int index]
        {
            //Get accessor is used for returning a value
            get
            {
                //based on the index position, return the appropriate property value
                if (index == 0)
                    return ID;
                else if (index == 1)
                    return Name;
                else if (index == 2)
                    return Job;
                else if (index == 3)
                    return Salary;
                else if (index == 4)
                    return Location;
                else if (index == 5)
                    return Department;
                else if (index == 6)
                    return Gender;
                else
                    return null;
            }
            //Set accessor is used to assigning a value
            set
            {
                //based on the index position, set the appropriate property value
                if (index == 0)
                    ID = Convert.ToInt32(value);
                else if (index == 1)
                    Name = value.ToString();
                else if (index == 2)
                    Job = value.ToString();
                else if (index == 3)
                    Salary = Convert.ToDouble(value);
                else if (index == 4)
                    Location = value.ToString();
                else if (index == 5)
                    Department = value.ToString();
                else if (index == 6)
                    Gender = value.ToString();
            }
        }
        #endregion


        #region string Indexer
        public object this[string Name]
        {
            //Get accessor is used for returning a value
            get
            {
                //based on the index name, return the appropriate property value
                if (Name == "ID")
                    return ID;
                else if (Name == "Name")
                    return Name;
                else if (Name == "Job")
                    return Job;
                else if (Name == "Salary")
                    return Salary;
                else if (Name == "Location")
                    return Location;
                else if (Name == "Department")
                    return Department;
                else if (Name == "Gender")
                    return Gender;
                else
                    return null;
            }
            //Set accessor is used to assigning a value
            set
            {
                //based on the index name, set the appropriate property value
                if (Name == "ID")
                    ID = Convert.ToInt32(value);
                else if (Name == "Name")
                    Name = value.ToString();
                else if (Name == "Job")
                    Job = value.ToString();
                else if (Name == "Salary")
                    Salary = Convert.ToDouble(value);
                else if (Name == "Location")
                    Location = value.ToString();
                else if (Name == "Department")
                    Department = value.ToString();
                else if (Name == "Gender")
                    Gender = value.ToString();
            }
        }
        #endregion
    }
}
