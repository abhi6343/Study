namespace ElementAtandElementAtOrDefaultMethod
{
    internal class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public static List<Student> GetAllStudents()
        {
            return new List<Student>()
            {
                new Student { ID = 1, Name = "Preety", Department= "IT"},
                new Student { ID = 2, Name = "Priyanka", Department= "HR"},
                new Student { ID = 3, Name = "Anurag", Department= "HR"},
                new Student { ID = 4, Name = "Pranaya", Department= "IT"},
                new Student { ID = 5, Name = "Hina", Department= "IT"}
            };
        }
    }
}
