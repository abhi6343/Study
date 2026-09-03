namespace Paging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //We want to display 4 Records Per page
            int RecordsPerPage = 4;
            //Set the Initial Page Number as 0
            int PageNumber = 0;

            do
            {
                Console.WriteLine("\nEnter the Page Number Between 1 and 4");
                //Read the Value and if its integer type, then store that value in the PageNumber variable
                if (int.TryParse(Console.ReadLine(), out PageNumber))
                {
                    //Check if PageNumber is > 0 and < 5
                    if (PageNumber > 0 && PageNumber < 5)
                    {
                        //Logic to Implement Paging
                        var employees = Employee.GetAllEmployees() //Data Source
                                    .Skip((PageNumber - 1) * RecordsPerPage) //Skip Logic
                                    .Take(RecordsPerPage).ToList(); //Take Logic

                        Console.WriteLine();
                        Console.WriteLine("Page Number : " + PageNumber);
                        foreach (var emp in employees)
                        {
                            Console.WriteLine($"ID : {emp.ID}, Name : {emp.Name}, Department : {emp.Department}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nPlease Enter a Valid Page Number");
                    }
                }
                else
                {
                    Console.WriteLine("\nPlease Enter a Valid Page Number");
                }
            } while (true);
        }
    }
}
