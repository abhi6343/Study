using AssemblyOne;

namespace AccessSpecifiers
{
    //You cannot make inheritance relationship because AssemblyOneClass1 is in
    //Internal cannot be accessible to outside assembly
    //internal class AnotherAssemblyClass1 : AssemblyOneClass1
    public class AnotherAssemblyClass1 : AssemblyOneClass1
    {
        public void Display4()
        {
            //You cannot access the Private Member from the Derived Class
            //from Other Assemblies
            Console.WriteLine(Id); //Compile Time Error
        }
    }
}
