namespace DistinctMethod
{
    //internal class Student
    //{
    //    public int ID { get; set; }
    //    public string Name { get; set; }
    //    public static List<Student> GetStudents()
    //    {
    //        List<Student> students = new List<Student>()
    //        {
    //            new Student {ID = 101, Name = "Preety" },
    //            new Student {ID = 102, Name = "Sambit" },
    //            new Student {ID = 103, Name = "Hina"},
    //            new Student {ID = 104, Name = "Anurag"},
    //            new Student {ID = 102, Name = "Sambit"},
    //            new Student {ID = 103, Name = "Hina"},
    //            new Student {ID = 101, Name = "Preety" },
    //        };
    //        return students;
    //    }

    //    #region For Approach 2
    //    public override bool Equals(object obj)
    //    {
    //        //As the obj parameter type is object, so we need to
    //        //cast it to Student Type
    //        return this.ID == ((Student)obj).ID && this.Name == ((Student)obj).Name;
    //    }

    //    public override int GetHashCode()
    //    {
    //        //Get the ID hash code value
    //        int IDHashCode = this.ID.GetHashCode();
    //        //Get the string HashCode Value
    //        //Check for null refernece exception
    //        int NameHashCode = this.Name == null ? 0 : this.Name.GetHashCode();
    //        return IDHashCode ^ NameHashCode;
    //    }
    //    #endregion
    //}


    #region Approach 4
    public class Student : IEquatable<Student>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>()
            {
                new Student {ID = 101, Name = "Preety" },
                new Student {ID = 102, Name = "Sambit" },
                new Student {ID = 103, Name = "Hina"},
                new Student {ID = 104, Name = "Anurag"},
                new Student {ID = 102, Name = "Sambit"},
                new Student {ID = 103, Name = "Hina"},
                new Student {ID = 101, Name = "Preety" },
            };
            return students;
        }
        public bool Equals(Student other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return this.ID.Equals(other.ID) && this.Name.Equals(other.Name);
        }
        public override int GetHashCode()
        {
            int IDHashCode = this.ID.GetHashCode();
            int NameHashCode = this.Name == null ? 0 : this.Name.GetHashCode();
            return IDHashCode ^ NameHashCode;
        }
        #endregion
    }
}
