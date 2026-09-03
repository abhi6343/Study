using FluentInterfaceDesignPattern.FluentAPI;

namespace FluentInterfaceDesignPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            FluentStudent student = new();
            student.StudentRegedNumber("BQPPR123456")
                   .NameOfTheStudent("Pranaya Rout")
                   .BornOn("10/10/1992")
                   .StudyOn("CSE")
                   .StaysAt("BBSR, Odisha");
            Console.Read();
        }
    }
}