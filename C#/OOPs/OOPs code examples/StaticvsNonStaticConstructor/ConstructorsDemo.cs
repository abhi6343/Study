namespace StaticvsNonStaticConstructor
{
    internal class ConstructorsDemo
    {
        public static int x; //It is going to be initialized by static constructor
        public int y; //It is going to be initialized by non-static constructor

        //Static Constructor
        static ConstructorsDemo()
        {
            //This constructor initialized the static variable x with default value i.e. 0
            Console.WriteLine("Static Constructor is Called");
        }

        //Static Constructor
        // A static constructor must be parameterless.
        //static ConstructorsDemo(int x)
        //{
        //    //This constructor initialized the static variable x with default value i.e. 0
        //    Console.WriteLine("Static Constructor is Called");
        //}

        //Non-Static Constructor
        public ConstructorsDemo()
        {
            //This constructor initialized the static variable y with default value i.e. 0
            Console.WriteLine("Non-Static Constructor is Called");
        }
    }
}
