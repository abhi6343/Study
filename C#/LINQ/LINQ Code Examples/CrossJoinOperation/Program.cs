namespace CrossJoinOperation
{
    internal class Program
    {
        //#region Cross join using query syntax
        //static void Main(string[] args)
        //{
        //    //Cross Join using Query Syntax
        //    var CrossJoinResult = from student in Student.GetAllStudents() //First Data Source
        //                          from subject in Subject.GetAllSubjects() //Cross Join with Second Data Source
        //                          //Projecting the Result to Anonymous Type
        //                          select new
        //                          {
        //                              StudentName = student.Name,
        //                              SubjectName = subject.SubjectName
        //                          };

        //    //Accessing the Elements using For Each Loop
        //    foreach (var item in CrossJoinResult)
        //    {
        //        Console.WriteLine($"Name : {item.StudentName}, Subject: {item.SubjectName}");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Cross join with defined type
        //static void Main(string[] args)
        //{
        //    //Cross Join using Query Syntax
        //    var CrossJoinResult = from student in Student.GetAllStudents() //First Data Source
        //                          from subject in Subject.GetAllSubjects() //Cross Join with Second Data Source
        //                          //Projecting the Result to Anonymous Type
        //                          select new StudentSubject
        //                          {
        //                              StudentName = student.Name,
        //                              SubjectName = subject.SubjectName
        //                          };

        //    //Accessing the Elements using For Each Loop
        //    foreach (var item in CrossJoinResult)
        //    {
        //        Console.WriteLine($"Name : {item.StudentName}, Subject: {item.SubjectName}");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Cross join using method syntax
        //static void Main(string[] args)
        //{
        //    //Cross Join using SelectMany Method
        //    var CrossJoinResult = Student.GetAllStudents()
        //                          .SelectMany(sub => Subject.GetAllSubjects(),
        //                           (std, sub) => new
        //                           {
        //                               StudentName = std.Name,
        //                               SubjectName = sub.SubjectName
        //                           });

        //    //Cross Join using Join Method
        //    var CrossJoinResult2 = Student.GetAllStudents()
        //                           .Join(Subject.GetAllSubjects(),
        //                               std => true,
        //                               sub => true,
        //                               (std, sub) => new
        //                               {
        //                                   StudentName = std.Name,
        //                                   SubjectName = sub.SubjectName
        //                               }
        //                            );

        //    foreach (var item in CrossJoinResult2)
        //    {
        //        Console.WriteLine($"Name : {item.StudentName}, Subject: {item.SubjectName}");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        #region Cross join with defined type
        static void Main(string[] args)
        {
            //Cross Join using SelectMany Method
            var CrossJoinResult = Student.GetAllStudents()
                                  .SelectMany(sub => Subject.GetAllSubjects(),
                                   (std, sub) => new StudentSubject
                                   {
                                       StudentName = std.Name,
                                       SubjectName = sub.SubjectName
                                   });

            //Cross Join using Join Method
            var CrossJoinResult2 = Student.GetAllStudents()
                                   .Join(Subject.GetAllSubjects(),
                                       std => true,
                                       sub => true,
                                       (std, sub) => new StudentSubject
                                       {
                                           StudentName = std.Name,
                                           SubjectName = sub.SubjectName
                                       }
                                    );

            foreach (var item in CrossJoinResult2)
            {
                Console.WriteLine($"Name : {item.StudentName}, Subject: {item.SubjectName}");
            }
            Console.ReadLine();
        }
        #endregion
    }
}
