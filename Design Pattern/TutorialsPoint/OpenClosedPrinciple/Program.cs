// See https://aka.ms/new-console-template for more information
using OpenClosedPrinciple;
// 1 without OCP only Employee class
//Employee empJohn = new Employee(1, "John", "Permanent");
//Employee empJason = new Employee(2, "Jason", "Temp");

//Console.WriteLine(string.Format("Employee {0} Bonus: {1}", empJohn.ToString(), empJohn.CalculateBonus(100000).ToString()));
//Console.WriteLine(string.Format("Employee {0} Bonus: {1}", empJason.ToString(), empJason.CalculateBonus(150000).ToString()));



Employee empJohn = new PermanentEmployee(1, "John");
Employee empJason = new TemporaryEmployee(2, "Jason");
Console.WriteLine(string.Format("Employee {0} Bonus: {1}", empJohn.ToString(), empJohn.CalculateBonus(100000).ToString()));
Console.WriteLine(string.Format("Employee {0} Bonus: {1}", empJason.ToString(), empJason.CalculateBonus(150000).ToString()));