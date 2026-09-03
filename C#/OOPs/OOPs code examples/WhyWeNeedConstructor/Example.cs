namespace WhyWeNeedConstructor
{
    internal class Example
    {
        int i;
        static int j;
        //Default Constructor
        public Example()
        {
            Console.WriteLine("Default Constructor Executed");
            i = 100;
        }
        //static Constructor
        static Example()
        {
            Console.WriteLine("Static Constructor Executed");
            j = 100;
        }
        public void Increment()
        {
            i++;
            j++;
        }
        public void Display()
        {
            Console.WriteLine("Value of i : " + i); 
            Console.WriteLine("Value of j : " + j);
        }
    }
}
