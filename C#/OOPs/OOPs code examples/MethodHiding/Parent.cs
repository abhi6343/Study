namespace MethodHiding
{
    internal class Parent
    {
        public virtual void Show()
        {
            Console.WriteLine("Parent Class Show Method");
        }
        public void Display()
        {
            Console.WriteLine("Parent Class Display Method");
        }
        public virtual void Method1()
        {
            Console.WriteLine("Parent Class Method1 Method");
        }
        public void Method2()
        {
            Console.WriteLine("Parent Class Method2 Method");
        }
        public virtual void Method3()
        {
            Console.WriteLine("Parent Class Method3 Method");
        }
        public void Method4()
        {
            Console.WriteLine("Parent Class Method4 Method");
        }
    }
}
