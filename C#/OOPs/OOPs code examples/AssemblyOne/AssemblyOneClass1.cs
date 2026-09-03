using System;

namespace AssemblyOne
{
    //internal class AssemblyOneClass1
    public class AssemblyOneClass1
    {
        //private int Id;
        //public int Id;
        //protected int Id;
        //internal int Id;
        //protected internal int Id;
        //private protected int Id;


        //For type access specifier
        public int Id;
        public void Display1()
        {
            //Private Member Accessible with the Containing Type only
            //Where they are created, they are available only within that type
            Console.WriteLine(Id);
        }
    }
}
