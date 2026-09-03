namespace PrivateConstructor
{
    internal class Child : Parent
    {
        public Child() : base("Hello")
        {
            Console.WriteLine("Child Class Public Constructor is Called");
        }
    }
}
