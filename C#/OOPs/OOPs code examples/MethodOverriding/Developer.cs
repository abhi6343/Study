namespace MethodOverriding
{
    internal class Developer : Employee
    {
        //50000 or 20% Bonus to Developers which is greater
        public override double CalculateBonus(double Salary)
        {
            double baseSalry = base.CalculateBonus(Salary);
            double calculatedSalary = Salary * .20;
            if (baseSalry >= calculatedSalary)
            {
                return baseSalry;
            }
            else
            {
                return calculatedSalary;
            }
        }
    }
}
