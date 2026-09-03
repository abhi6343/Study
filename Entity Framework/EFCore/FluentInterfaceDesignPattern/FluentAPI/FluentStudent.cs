using FluentInterfaceDesignPattern.Entities;

namespace FluentInterfaceDesignPattern.FluentAPI
{
    internal class FluentStudent
    {
        private readonly Student student = new();
        public FluentStudent StudentRegedNumber(string RegdNo)
        {
            student.RegdNo = RegdNo;
            return this;
        }
        public FluentStudent NameOfTheStudent(string Name)
        {
            student.Name = Name;
            return this;
        }
        public FluentStudent BornOn(string DOB)
        {
            student.DOB = Convert.ToDateTime(DOB);
            return this;
        }
        public FluentStudent StudyOn(string Branch)
        {
            student.Branch = Branch;
            return this;
        }
        public FluentStudent StaysAt(string Address)
        {
            student.Address = Address;
            return this;
        }
    }
}
