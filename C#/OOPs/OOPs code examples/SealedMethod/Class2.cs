namespace SealedMethod
{
    internal class Class2 : Class1
    {
        //Private Method
        private void Method2()
        {
            Console.WriteLine("Class2 Private Method2");
        }
        //Sealed Method
        public sealed override void Method1()
        {
            Console.WriteLine("Class2 Sealed Method1");
        }
    }
}
