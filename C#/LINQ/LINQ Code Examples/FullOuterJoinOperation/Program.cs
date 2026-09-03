namespace FullOuterJoinOperation
{
    internal class Program
    {
        //#region Full outer join using query syntax
        //static void Main(string[] args)
        //{
        //    //Full Outer Join = Left Outer Join UNION Right Outer Join
        //    //Performinng Left Outer Join
        //    var LeftOuterJoin = from emp in Employee.GetAllEmployees()
        //                        join dept in Department.GetAllDepartments()
        //                        on emp.DepartmentId equals dept.ID into EmployeeDepartmentGroup
        //                        from department in EmployeeDepartmentGroup.DefaultIfEmpty()
        //                        select new
        //                        {
        //                            //To Avoid Runtime Null Reference Exception, check NULL 
        //                            EmployeeId = emp?.ID,
        //                            EmployeeName = emp?.Name ?? "NA",
        //                            DepartmentName = department?.Name ?? "NA"
        //                        };

        //    var RightOuterJoin = from dept in Department.GetAllDepartments()
        //                         join emp in Employee.GetAllEmployees()
        //                         on dept.ID equals emp.DepartmentId into EmployeeDepartmentGroup
        //                         from employee in EmployeeDepartmentGroup.DefaultIfEmpty()
        //                         select new
        //                         {
        //                             //To Avoid Runtime Null Reference Exception, check NULL 
        //                             EmployeeId = employee?.ID,
        //                             EmployeeName = employee?.Name ?? "NA",
        //                             DepartmentName = dept?.Name ?? "NA"
        //                         };

        //    var FullOuterJoin = LeftOuterJoin.Union(RightOuterJoin);

        //    foreach (var emp in FullOuterJoin)
        //    {
        //        Console.WriteLine($"EmployeeId: {emp.EmployeeId}, Name: {emp.EmployeeName}, Department: {emp.DepartmentName}");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        #region Full outer join using method syntax
        static void Main(string[] args)
        {
            //Full Outer Join = Left Outer Join UNION Right Outer Join
            //Performinng Left Outer Join
            var LeftOuterJoin = from emp in Employee.GetAllEmployees()
                                join dept in Department.GetAllDepartments()
                                on emp.DepartmentId equals dept.ID into EmployeeDepartmentGroup
                                from department in EmployeeDepartmentGroup.DefaultIfEmpty()
                                select new
                                {
                                    //To Avoid Runtime Null Reference Exception, check NULL 
                                    EmployeeId = emp?.ID,
                                    EmployeeName = emp?.Name ?? "NA",
                                    DepartmentName = department?.Name ?? "NA"
                                };

            var RightOuterJoin = from dept in Department.GetAllDepartments()
                                 join emp in Employee.GetAllEmployees()
                                 on dept.ID equals emp.DepartmentId into EmployeeDepartmentGroup
                                 from employee in EmployeeDepartmentGroup.DefaultIfEmpty()
                                 select new
                                 {
                                     //To Avoid Runtime Null Reference Exception, check NULL 
                                     EmployeeId = employee?.ID,
                                     EmployeeName = employee?.Name ?? "NA",
                                     DepartmentName = dept?.Name ?? "NA"
                                 };

            var FullOuterJoin = LeftOuterJoin.Union(RightOuterJoin);
            foreach (var emp in FullOuterJoin)
            {
                Console.WriteLine($"EmployeeId: {emp.EmployeeId}, Name: {emp.EmployeeName}, Department: {emp.DepartmentName}");
            }
            Console.ReadLine();
        }
        #endregion
    }
}
