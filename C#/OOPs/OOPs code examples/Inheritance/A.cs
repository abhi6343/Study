namespace Inheritance
{
    internal class A
    {
        //public A()
        //{
        //    Console.WriteLine("Class A Constructor is Called");
        //}
        public A(int number)
        {
            Console.WriteLine($"Class A Constructor is Called : {number}");
        }
        public void Method1()
        {
            Console.WriteLine("Method 1");
        }
        public void Method2()
        {
            Console.WriteLine("Method 2");
        }
    }
}
