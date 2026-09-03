namespace AsyncTaskClass
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Main Method Started......");
        //    SomeMethod();
        //    Console.WriteLine("Main Method End");
        //    Console.ReadKey();
        //}
        //public async static void SomeMethod()
        //{
        //    Console.WriteLine("Some Method Started......");
        //    await Wait();
        //    Console.WriteLine("Some Method End");
        //}
        //private static async Task Wait()
        //{
        //    await Task.Delay(TimeSpan.FromSeconds(10));
        //    Console.WriteLine("\n10 Seconds wait Completed\n");
        //}
        //public async static void SomeMethod()
        //{
        //    Console.WriteLine("Some Method Started......");
        //    Wait();
        //    Console.WriteLine("Some Method End");
        //}
        //private static async void Wait()
        //{
        //    await Task.Delay(TimeSpan.FromSeconds(10));
        //    Console.WriteLine("\n10 Seconds wait Completed\n");
        //}

        static void Main(string[] args)
        {
            Console.WriteLine($"Main Thread Started");
            SomeMethod();
            Console.WriteLine($"Main Thread Completed");
            Console.ReadKey();
        }
        private async static void SomeMethod()
        {
            Employee emp = await GetEmployeeDetails();
            Console.WriteLine($"ID: {emp.ID}, Name : {emp.Name}, Salary : {emp.Salary}");
        }
        static async Task<Employee> GetEmployeeDetails()
        {
            Employee employee = new Employee()
            {
                ID = 101,
                Name = "James",
                Salary = 10000
            };
            return employee;
        }
    }
}
