namespace DelegateRealtimeExamples
{
    internal class Program
    {
        //#region Example 1
        //static void Main(string[] args)
        //{
        //    WorkPerformedHandler del1 = new WorkPerformedHandler(Worker_WorkPerformed);
        //    WorkCompletedHandler del2 = new WorkCompletedHandler(Worker_WorkCompleted);
        //    Worker worker = new Worker();
        //    worker.DoWork(5, "Generating Report", del1, del2);
        //    Console.ReadKey();
        //}
        ////Delegate Signature must match with the method signature
        //static void Worker_WorkPerformed(int hours, string workType)
        //{
        //    Console.WriteLine($"{hours} Hours compelted for {workType}");
        //}
        //static void Worker_WorkCompleted(string workType)
        //{
        //    Console.WriteLine($"{workType} work compelted");
        //}
        //#endregion


        #region Example 2
        static void Main()
        {
            Employee emp1 = new Employee()
            {
                ID = 101,
                Name = "Pranaya",
                Gender = "Male",
                Experience = 5,
                Salary = 10000
            };
            Employee emp2 = new Employee()
            {
                ID = 102,
                Name = "Priyanka",
                Gender = "Female",
                Experience = 10,
                Salary = 20000
            };
            Employee emp3 = new Employee()
            {
                ID = 103,
                Name = "Anurag",
                Experience = 15,
                Salary = 30000
            };

            List<Employee> lstEmployess = new List<Employee>();
            lstEmployess.Add(emp1);
            lstEmployess.Add(emp2);
            lstEmployess.Add(emp3);
            EligibleToPromotion eligibleTopromote = new EligibleToPromotion(Program.Promote);
            Employee.PromoteEmployee(lstEmployess, eligibleTopromote);

            //Lambda expression
            //Employee.PromoteEmployee(lstEmployess, x => x.Experience > 5);

            Console.ReadKey();
        }
        public static bool Promote(Employee employee)
        {
            if (employee.Salary > 10000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
