// See https://aka.ms/new-console-template for more information
using MVCDesignPattern;

// Fetch student record based on his roll no from the database
Student model = retrieveStudentFromDatabase();
// Create a view : to write student details on console
StudentView view = new StudentView();
StudentController controller = new StudentController(model, view);
controller.updateView();
Console.WriteLine("");
// Update model data
controller.setStudentName("John");
controller.updateView();

static Student retrieveStudentFromDatabase()
{
    Student student = new Student();
    student.setName("Robert");
    student.setRollNo("10");
    return student;
}