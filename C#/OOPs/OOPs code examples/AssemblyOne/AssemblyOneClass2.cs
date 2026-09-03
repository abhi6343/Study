using System;

namespace AssemblyOne
{
    internal class AssemblyOneClass2 : AssemblyOneClass1
    //public class AssemblyOneClass2 : AssemblyOneClass1
    {
        public void Display2()
        {
            //You cannot access the Private Member from the Derived Class
            //Within the Same Assembly
            Console.WriteLine(Id); //Compile Time Error
        }
    }
}
