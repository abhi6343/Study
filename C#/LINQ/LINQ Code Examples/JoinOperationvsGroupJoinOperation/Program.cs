namespace JoinOperationvsGroupJoinOperation
{
    internal class Program
    {
        #region
        static void Main(string[] args)
        {
            // Define the school and student collections
            var schools = new List<School> {
                new School{ SchoolID = 1, Name = "Springfield High" },
                new School{ SchoolID = 2, Name = "Westfield Academy" },
                new School{ SchoolID = 3, Name = "Dot Net School" }
            };
            var students = new List<Student> {
                new Student{ StudentID = 1, SchoolID = 1, Name = "John Doe" },
                new Student{ StudentID = 2, SchoolID = 1, Name = "Jane Smith" },
                new Student{ StudentID = 3, SchoolID = 2, Name = "Will Johnson" },
                new Student{ StudentID = 4, SchoolID = 3, Name = "Sara Taylor" },
                new Student{ StudentID = 5, SchoolID = 3, Name = "Steven Smith" }
            };

            // JOIN example: List all students with their respective schools
            var joinQuery = from s in schools
                            join st in students on s.SchoolID equals st.SchoolID
                            select new { StudentName = st.Name, SchoolName = s.Name };

            Console.WriteLine("List all students with their respective schools");
            foreach (var studentschool in joinQuery)
            {
                Console.WriteLine($"\tStudent Name: {studentschool.StudentName}, School Name: {studentschool.SchoolName}");
            }

            // GROUP JOIN example: List schools along with all their students
            var groupJoinQuery = from s in schools
                                 join st in students on s.SchoolID equals st.SchoolID into schoolGroup
                                 select new { SchoolName = s.Name, Students = schoolGroup };

            Console.WriteLine("\nList schools along with all their students");
            foreach (var school in groupJoinQuery)
            {
                Console.WriteLine($"School Name: {school.SchoolName}");
                foreach (var student in school.Students)
                {
                    Console.WriteLine($"\tStudent Id: {student.StudentID}, Name: {student.Name}");
                }
            }
            Console.ReadLine();
        }
        #endregion
    }
}
