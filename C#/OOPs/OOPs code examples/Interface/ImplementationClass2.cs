namespace Interface
{
    internal class ImplementationClass2 : ITestInterface2
    {
        //Implement Both Add and Sub method
        public void Add(int num1, int num2)
        {
            Console.WriteLine($"Sum of {num1} and {num2} is {num1 + num2}");
        }
        public void Sub(int num1, int num2)
        {
            Console.WriteLine($"Divison of {num1} and {num2} is {num1 - num2}");
        }
    }
}
