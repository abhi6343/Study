namespace SealedMethod
{
    internal class Class3 : Class2
    {
        //We cannot override Method1 because it is sealed in Class2
        //But this method is inherited and hence we can access this method
        //using Class3 instance
        //public override void Method1()
        //{
        // Console.WriteLine("InkJet Printer Printing...");
        //}
        //Class2 Private Method Method2 is not inherited to child class and he
        //you can define the same method here
        public void Method2()
        {
            Console.WriteLine("Class3 public Method2");
        }
    }
}
