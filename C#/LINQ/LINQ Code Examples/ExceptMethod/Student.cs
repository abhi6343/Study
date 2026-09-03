namespace ExceptMethod
{
    //    internal class Student
    //    {
    //        public int ID { get; set; }
    //        public string Name { get; set; }
    //        public override bool Equals(object obj)
    //        {
    //            //As the obj parameter type is object, so we need to
    //            //cast it to Student Type
    //            return this.ID == ((Student)obj).ID && this.Name == ((Student)obj).Name;
    //}
    //        public override int GetHashCode()
    //        {
    //            //Get the ID hash code value
    //            int IDHashCode = this.ID.GetHashCode();
    //            //Get the string HashCode Value
    //            //Check for null refernece exception
    //            int NameHashCode = this.Name == null ? 0 : this.Name.GetHashCode();
    //            return IDHashCode ^ NameHashCode;
    //        }
    //    }

    #region Implementing IEquitable interface
    public class Student : IEquatable<Student>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Equals(Student other)
        {
            return this.ID.Equals(other.ID) && this.Name.Equals(other.Name);
        }
        public override int GetHashCode()
        {
            int IDHashCode = this.ID.GetHashCode();
            int NameHashCode = this.Name == null ? 0 : this.Name.GetHashCode();
            return IDHashCode ^ NameHashCode;
        }
    }
    #endregion
}
