namespace Enums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a collection to store list of employees
            List<Employee> empList = new List<Employee>
            {
                new Employee() { Name = "Anurag", Gender = 0 },
                new Employee() { Name = "Pranaya", Gender = 1 },
                new Employee() { Name = "Priyanka", Gender = 2 },
                new Employee() { Name = "Sambit", Gender = 3 }
            };

            //Loop through Each Employees and Print the Name and Gender
            foreach (var emp in empList)
            {
                //To Print the Actual Gender of the Employee, 
                //we need to call the GetGender Method by passing the Integer Gender Value
                Console.WriteLine($"Name = {emp.Name} && Gender = {GetGender(emp.Gender)}");
            }


            // This following line will not compile.
            // Cannot implicitly convert type 'Season' to 'Gender'.
            // An explicit conversion is required.

            // Gender gender = Season.Winter;

            // The following line compiles as we have an explicit cast
            Gender gender = (Gender)Season.Winter;


            //GetValues Method return an array of Values of Gender Enum
            //Values are nothing but Integer numbers i.e. 1, 2, and 3
            int[] EnumValues = (int[])Enum.GetValues(typeof(Gender));
            Console.WriteLine("Gender Enum Values");
            //Looping through the EnumValues array to Print all the Values
            foreach (int value in EnumValues)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();
            //GetNames Method return an array of Names of Gender Enum
            //Names are nothing but the string named constants i.e. Unknown, Male, and Female
            string[] EnumNames = Enum.GetNames(typeof(Gender));
            Console.WriteLine("Gender Enum Names");
            //Looping through the EnumNames array to Print all the Names
            foreach (string Name in EnumNames)
            {
                Console.WriteLine(Name);
            }


            Console.ReadLine();
        }


        //#region Integer based GetGender
        ////This Method is used to return the Actual Gender Based on the Integer Gender Value
        //public static string GetGender(int gender)
        //{
        //    // The switch case here is less readable because of these integral numbers
        //    switch (gender)
        //    {
        //        case 0:
        //            return "Unknown";
        //        case 1:
        //            return "Male";
        //        case 2:
        //            return "Female";
        //        default:
        //            return "Invalid Data for Gender";
        //    }
        //}
        //#endregion



        #region Enum based GetGender
        //This Method is used to return the Actual Gender Based on the Enum Gender Value
        public static string GetGender(int gender)
        {
            // The switch case here is now more readable and maintainable because 
            // of replacing the integral numbers with Gender Enum
            switch (gender)
            {
                case (int)Gender.Unknown:
                    return "Unknown";
                case (int)Gender.Male:
                    return "Male";
                case (int)Gender.Female:
                    return "Female";
                default:
                    return "Invalid Data for Gender";
            }
        }
        #endregion
    }
    //Gender Enum
    public enum Gender
    {
        Unknown,
        Male,
        Female
    }
    //Season Enum
    public enum Season : int
    {
        Winter = 1,
        Spring = 2,
        Summer = 3
    }
}
