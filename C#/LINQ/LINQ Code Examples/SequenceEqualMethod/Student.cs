namespace SequenceEqualMethod
{
    //internal class Student
    //{
    //    public int ID { get; set; }
    //    public string Name { get; set; }
    //    public static List<Student> GetStudents1()
    //    {
    //        List<Student> listStudents = new List<Student>()
    //        {
    //            new Student{ID= 101,Name = "Preety"},
    //            new Student{ID= 102,Name = "Priyanka"}
    //        };
    //        return listStudents;
    //    }
    //    public static List<Student> GetStudents2()
    //    {
    //        List<Student> listStudents = new List<Student>()
    //        {
    //            new Student{ID= 101,Name = "Preety"},
    //            new Student{ID= 102,Name = "Priyanka"}
    //        };
    //        return listStudents;
    //    } 
    //    //Overriding the Object class Equals Method
    //    public override bool Equals(object x)
    //    {
    //        return this.ID == ((Student)x).ID && this.Name == ((Student)x).Name;
    //    }
    //    //Overriding the Object class GetHashCode Method
    //    public override int GetHashCode()
    //    {
    //        return this.ID.GetHashCode() ^ this.Name.GetHashCode();
    //    }
    //}


    #region IEquitable interface
    internal class Student : IEquatable<Student>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public static List<Student> GetStudents1()
        {
            List<Student> listStudents = new List<Student>()
            {
                new Student{ID= 101,Name = "Preety"},
                new Student{ID= 102,Name = "Priyanka"}
            };
            return listStudents;
        }
        public static List<Student> GetStudents2()
        {
            List<Student> listStudents = new List<Student>()
            {
                new Student{ID= 101,Name = "Preety"},
                new Student{ID= 102,Name = "Priyanka"}
            };
            return listStudents;
        }
        //Implementing the Equals Method of IEquatable Interface
        public bool Equals(Student other)
        {
            return this.ID.Equals(other.ID) && this.Name.Equals(other.Name);
        }
        //Overriding the Object class GetHashCode Method
        public override int GetHashCode()
        {
            return this.ID.GetHashCode() ^ this.Name.GetHashCode();
        }
    }
    #endregion
}
