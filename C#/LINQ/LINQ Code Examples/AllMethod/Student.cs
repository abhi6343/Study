namespace AllMethod
{
    internal class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TotalMarks { get; set; }
        public List<Subject> Subjects { get; set; }
        public static List<Student> GetAllStudnets()
        {
            List<Student> listStudents = new List<Student>()
            {
                new Student
                {
                    ID= 101,Name = "Preety", TotalMarks = 265,
                    Subjects = new List<Subject>()
                    {
                        new Subject(){SubjectName = "Math", Marks = 80},
                        new Subject(){SubjectName = "Science", Marks = 90},
                        new Subject(){SubjectName = "English", Marks = 95}
                    }
                },
                new Student
                {
                    ID= 102,Name = "Priyanka", TotalMarks = 278,
                    Subjects = new List<Subject>()
                    {
                        new Subject(){SubjectName = "Math", Marks = 90},
                        new Subject(){SubjectName = "Science", Marks = 95},
                        new Subject(){SubjectName = "English", Marks = 93}
                    }
                },
                new Student
                {
                    ID= 103,Name = "James", TotalMarks = 240,
                    Subjects = new List<Subject>()
                    {
                        new Subject(){SubjectName = "Math", Marks = 70},
                        new Subject(){SubjectName = "Science", Marks = 80},
                        new Subject(){SubjectName = "English", Marks = 90}
                    }
                },
                new Student
                {
                    ID= 104,Name = "Hina", TotalMarks = 275,
                    Subjects = new List<Subject>()
                    {
                        new Subject(){SubjectName = "Math", Marks = 90},
                        new Subject(){SubjectName = "Science", Marks = 90},
                        new Subject(){SubjectName = "English", Marks = 95}
                    }
                },
                new Student
                {
                    ID= 105,Name = "Anurag", TotalMarks = 255,
                    Subjects = new List<Subject>()
                    {
                        new Subject(){SubjectName = "Math", Marks = 80},
                        new Subject(){SubjectName = "Science", Marks = 90},
                        new Subject(){SubjectName = "English", Marks = 85}
                    }
                },
            };
            return listStudents;
        }
    }
}
