namespace DesignDBusingCodeFirst.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Fees { get; set; }
        //public ICollection<Student> Students { get; set; }
        //public ICollection<Subject> Subjects { get; set; }

        public virtual ICollection<Student> Students { get; set; } //Marking the Property as Virtual to Support Lazy Loading
        public virtual ICollection<Subject> Subjects { get; set; } //Marking the Property as Virtual to Support Lazy Loading
    }
}
