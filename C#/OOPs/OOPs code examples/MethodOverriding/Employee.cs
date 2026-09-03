namespace MethodOverriding
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public double Salary { get; set; }
        public virtual double CalculateBonus(double Salary)
        {
            return 50000;
        }
    }
}
