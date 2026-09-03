using System.Net;

namespace DesignDBusingCodeFirst.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int BranchId { get; set; }
        //public Branch Branch { get; set; }
        //public Address Address { get; set; }
        //public ICollection<Subject> Subjects { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
