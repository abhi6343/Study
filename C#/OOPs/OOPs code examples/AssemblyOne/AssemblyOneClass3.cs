using System;

namespace AssemblyOne
{
    internal class AssemblyOneClass3
    //public class AssemblyOneClass3
    {
        public void Dispplay3()
        {
            //You cannot access the Private Member from the Non-Derived Classe
            //Within the Same Assembly
            AssemblyOneClass1 obj = new AssemblyOneClass1();
            Console.WriteLine(obj.Id); //Compile Time Error
        }
    }
}
