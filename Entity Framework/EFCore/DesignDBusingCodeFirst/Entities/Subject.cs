namespace DesignDBusingCodeFirst.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
        //public ICollection<Teacher> Teachers { get; set; }
        //public ICollection<Course> Courses { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
