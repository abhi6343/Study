namespace Ploymorphism
{
    internal class Class2 : Class1
    {
        //Overriding Method
        public override void Show()
        {
            //Child Class Reimplementing the Logic
            Console.WriteLine("Child Class Show Method");
        }
        public void Add()
        {
            Console.WriteLine("Child Class Add Method");
        }
    }
}
