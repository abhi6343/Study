namespace Inheritance
{
    //internal class B
    //{
    //    public void Method1()
    //    {
    //        Console.WriteLine("Method 1");
    //    }
    //    public void Method2()
    //    {
    //        Console.WriteLine("Method 2");
    //    }
    //}


    #region Inhertitance
    internal class B : A
    {
        public B() : base(10)
        {
            Console.WriteLine("Class B Constructor is Called");
        }
        public B(int num) : base(num)
        {
            Console.WriteLine("Class B Constructor is Called");
        }
        public void Method3()
        {
            Console.WriteLine("Method 3");
        }
    }
    #endregion
}
