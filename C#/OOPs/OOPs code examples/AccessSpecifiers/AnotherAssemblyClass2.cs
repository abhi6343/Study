using AssemblyOne;

namespace AccessSpecifiers
{
    internal class AnotherAssemblyClass2
    {
        public void Dispplay3()
        {
            //You cannot access the Private Member from the Non-Derived Classe
            //from Other Assemblies
            AssemblyOneClass1 obj = new AssemblyOneClass1();
            Console.WriteLine(obj.Id); //Compile Time Error
        }
    }
}
