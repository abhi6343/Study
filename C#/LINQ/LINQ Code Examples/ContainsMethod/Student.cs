namespace ContainsMethod
{
    //internal class Student
    //{
    //    public int ID { get; set; }
    //    public string Name { get; set; }
    //    public int TotalMarks { get; set; }
    //    public override bool Equals(object obj)
    //    {
    //        //As the obj parameter type is object, so we need to
    //        //cast it to Student Type
    //        return this.ID == ((Student)obj).ID && this.Name == ((Student)obj).Name && this.TotalMarks == ((Student)obj).TotalMarks;
    //    }
    //    public override int GetHashCode()
    //    {
    //        return this.ID.GetHashCode() ^ this.Name.GetHashCode() ^ this.TotalMarks.GetHashCode();
    //    }
    //}


    #region Student class with IEquatable<T> interface
    public class Student : IEquatable<Student>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TotalMarks { get; set; }
        public bool Equals(Student obj)
        {
            return this.ID == obj.ID && this.Name == obj.Name && this.TotalMarks == obj.TotalMarks;
        }
        public override int GetHashCode()
        {
            return this.ID.GetHashCode() ^ this.Name.GetHashCode() ^ this.TotalMarks.GetHashCode();
        }
    }
    #endregion
}
