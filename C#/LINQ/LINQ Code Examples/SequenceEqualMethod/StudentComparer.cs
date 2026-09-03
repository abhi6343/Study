using System.Diagnostics.CodeAnalysis;

namespace SequenceEqualMethod
{
    internal class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return x.ID == y.ID && x.Name == y.Name;
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            return obj.ID.GetHashCode() ^ obj.Name.GetHashCode();
        }
    }
}
