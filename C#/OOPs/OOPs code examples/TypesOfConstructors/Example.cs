namespace TypesOfConstructors
{
    internal class Example
    {
        int i;
        static int j;
        static Example()
        {
            j = 100; //Allowed
            //i = 101; //Not Allowed
        }
        public Example()
        {
            j = 100;
            i = 100; //Allowed
        }
    }
}
