namespace OpenClosedPrinciple
{
    //public class Employee
    //{
    //    public int ID { get; set; }
    //    public string Name { get; set; }
    //    public string EmployeeType { get; set; }
    //    Employee() { }
    //    public Employee(int id, string name, string type)
    //    {
    //        this.ID = id;
    //        this.Name = name;
    //        this.EmployeeType = type;
    //    }
    //    public decimal CalculateBonus(decimal salary)
    //    {
    //        //  return salary * 0.1M;
    //        if (this.EmployeeType == "Permanent")
    //            return salary * .1M;
    //        else
    //            return salary * .05M;
    //    }
    //    public override string ToString()
    //    {
    //        return string.Format("ID : {0} Name : {1}", this.ID, this.Name);
    //    }
    //}
    public abstract class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Employee() { }
        public Employee(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
        public abstract decimal CalculateBonus(decimal salary);
        public override string ToString()
        {
            return string.Format("ID : {0} Name : {1}", this.ID, this.Name);
        }
    }
}
