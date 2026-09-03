namespace OpenClosedPrinciple
{
    public class TemporaryEmployee : Employee
    {
        public TemporaryEmployee() { }
        public TemporaryEmployee(int id, string name) : base(id, name) { }
        public override decimal CalculateBonus(decimal salary)
        {
            return salary * 0.05M;
        }
    }
}
