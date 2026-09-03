namespace GroupJoinOperation
{
    internal class Program
    {
        //#region GroupJoin method syntax
        //static void Main(string[] args)
        //{
        //    //Group Employees by Department using Method Syntax
        //    var GroupJoinMS = Department.GetAllDepartments(). //Outer Data Source i.e. Departments
        //                        GroupJoin( //Performing Group Join with Inner Data Source
        //                            Employee.GetAllEmployees(), //Inner Data Source
        //                            dept => dept.ID, //Outer Key Selector  i.e. the Common Property
        //                            emp => emp.DepartmentId, //Inner Key Selector  i.e. the Common Property
        //                            (dept, emp) => new { dept, emp } //Projecting the Result to an Anonymous Type
        //                        );

        //    //Printing the Result set
        //    //Outer Foreach is for Each department
        //    foreach (var item in GroupJoinMS)
        //    {
        //        Console.WriteLine("Department :" + item.dept.Name);
        //        //Inner Foreach loop for each employee of a Particular department
        //        foreach (var employee in item.emp)
        //        {
        //            Console.WriteLine("  EmployeeID : " + employee.ID + " , Name : " + employee.Name);
        //        }
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        //#region GroupJoin query syntax
        //static void Main(string[] args)
        //{
        //    //Group Employees by Department using Query Syntax
        //    var GroupJoinQS = from dept in Department.GetAllDepartments() //Outer Data Source i.e. Departments
        //                      join emp in Employee.GetAllEmployees() //Joining with Inner Data Source i.e. Employees
        //                      on dept.ID equals emp.DepartmentId //Joining Condition
        //                      into EmployeeGroups //Projecting the Joining Result into EmployeeGroups
        //                      //Final Result include each department and the corresponding employees
        //                      select new { dept, EmployeeGroups };

        //    //Printing the Result set
        //    //Outer Foreach is for Each department
        //    foreach (var item in GroupJoinQS)
        //    {
        //        Console.WriteLine("Department :" + item.dept.Name);
        //        //Inner Foreach loop for each employee of a Particular department
        //        foreach (var employee in item.EmployeeGroups)
        //        {
        //            Console.WriteLine("  EmployeeID : " + employee.ID + " , Name : " + employee.Name);
        //        }
        //    }

        //    Console.ReadLine();
        //}
        //#endregion


        //#region GroupJoin with defined type
        //static void Main(string[] args)
        //{
        //    //Group Employees by Department using Method Syntax
        //    var GroupJoinMS = Department.GetAllDepartments(). //Outer Data Source i.e. Departments
        //                        GroupJoin( //Performing Group Join with Inner Data Source
        //                            Employee.GetAllEmployees(), //Inner Data Source
        //                            dept => dept.ID, //Outer Key Selector  i.e. the Common Property
        //                            emp => emp.DepartmentId, //Inner Key Selector  i.e. the Common Property
        //                            //Projecting the Result to a Named Type
        //                            (dept, emp) => new GroupEmployeeByDepartment
        //                            {
        //                                Department = dept,
        //                                Employees = emp.ToList()
        //                            }
        //                        );

        //    //Group Employees by Department using Query Syntax
        //    var GroupJoinQS = from dept in Department.GetAllDepartments() //Outer Data Source i.e. Departments
        //                      join emp in Employee.GetAllEmployees() //Joining with Inner Data Source i.e. Employees
        //                      on dept.ID equals emp.DepartmentId //Joining Condition
        //                      into EmployeeGroups //Projecting the Joining Result into EmployeeGroups
        //                      //Projecting the Result to a Named Type
        //                      select new GroupEmployeeByDepartment
        //                      {
        //                          Department = dept,
        //                          Employees = EmployeeGroups.ToList()
        //                      };

        //    foreach (var item in GroupJoinQS)
        //    {
        //        Console.WriteLine("Department :" + item.Department.Name);
        //        foreach (var employee in item.Employees)
        //        {
        //            Console.WriteLine("  EmployeeID : " + employee.ID + " , Name : " + employee.Name);
        //        }
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        #region Projecting to Anonymous Type with User-Defined Property Names in ResultSet
        static void Main(string[] args)
        {
            //Group Employees by Department using Method Syntax
            var GroupJoinMS = Department.GetAllDepartments(). //Outer Data Source i.e. Departments
                                GroupJoin( //Performing Group Join with Inner Data Source
                                    Employee.GetAllEmployees(), //Inner Data Source
                                    dept => dept.ID, //Outer Key Selector  i.e. the Common Property
                                    emp => emp.DepartmentId, //Inner Key Selector  i.e. the Common Property
                                    //Projecting the Result with User Defined Names
                                    (dept, emp) => new
                                    {
                                        Department = dept,
                                        Employees = emp.ToList()
                                    }
                                );

            //Group Employees by Department using Query Syntax
            var GroupJoinQS = from dept in Department.GetAllDepartments() //Outer Data Source i.e. Departments
                              join emp in Employee.GetAllEmployees() //Joining with Inner Data Source i.e. Employees
                              on dept.ID equals emp.DepartmentId //Joining Condition
                              into EmployeeGroups //Projecting the Joining Result into EmployeeGroups
                              //Projecting the Result with User Defined Names
                              select new
                              {
                                  Department = dept,
                                  Employees = EmployeeGroups.ToList()
                              };

            foreach (var item in GroupJoinQS)
            {
                Console.WriteLine("Department :" + item.Department.Name);
                foreach (var employee in item.Employees)
                {
                    Console.WriteLine("  EmployeeID : " + employee.ID + " , Name : " + employee.Name);
                }
            }
            Console.ReadLine();
        }
        #endregion
    }
}
