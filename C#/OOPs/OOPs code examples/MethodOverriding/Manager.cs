namespace MethodOverriding
{
    internal class Manager : Employee
    {
        //50000 or 25% Bonus to Developers which is greater
        public override double CalculateBonus(double Salary)
        {
            double baseSalry = base.CalculateBonus(Salary);
            double calculatedSalary = Salary * .25;
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
