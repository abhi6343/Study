namespace ContainsMethod
{
    internal class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student? x, Student? y)
        {
            //If both object refernces are equal then return true
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }
            //If one of the object refernce is null then return false
            if (x is null || y is null)
            {
                return false;
            }
            return x.ID == y.ID && x.Name == y.Name && x.TotalMarks == y.TotalMarks;
        }

        public int GetHashCode(Student obj)
        {
            //If obj is null then return 0
            if (obj is null)
            {
                return 0;
            }
            int IDHashCode = obj.ID.GetHashCode();
            int NameHashCode = obj.Name == null ? 0 : obj.Name.GetHashCode();
            int TotalMarksHashCode = obj.TotalMarks.GetHashCode();
            return IDHashCode ^ NameHashCode ^ TotalMarksHashCode;
        }
    }
}
