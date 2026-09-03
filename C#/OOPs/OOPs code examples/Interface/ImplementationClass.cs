namespace Interface
{
    internal class ImplementationClass : ITestInterface1
    {
        //Interface Method Implementation
        public void Add(int num1, int num2)
        {
            Console.WriteLine($"Sum of {num1} and {num2} is {num1 + num2}");
        }

        ////This method purely belongs to ImplementationClass
        //public void Sub(int num1, int num2)
        //{
        //    Console.WriteLine($"Divison of {num1} and {num2} is {num1 - num2}");
        //}

        //This method purely belongs to ImplementationClass
        void ITestInterface1.Sub(int num1, int num2)
        {
            Console.WriteLine($"Divison of {num1} and {num2} is {num1 - num2}");
        }
    }
}
