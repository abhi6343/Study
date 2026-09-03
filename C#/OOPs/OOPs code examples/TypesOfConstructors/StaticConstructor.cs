namespace TypesOfConstructors
{
    internal class StaticConstructor
    {
        int i;
        static int j;

        // static constructor
        static StaticConstructor()
        {
            // i = 10; // Not Allowed
            j = 100;
            Console.WriteLine("Static Constructor Executed!");
        }
        public StaticConstructor()
        {
            i = 10; // Allowed
            j = 100;
        } 
        static void Main(string[] args)
        {
            Console.WriteLine("Main Method Exceution Started...");
            Console.ReadKey();
        }
        
    }
}
