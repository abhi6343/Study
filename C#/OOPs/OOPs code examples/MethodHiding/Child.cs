namespace MethodHiding
{
    internal class Child : Parent
    {
        //Method Overriding
        public override void Show()
        {
            //Using Parent class instance to Invoke the Parent Methods
            Parent parent = new Parent();
            parent.Show();
            //Using base keyword to invoke the Parent method
            base.Display();
            Console.WriteLine("Child Class Show Method");
        }
        //Method Hiding/Shadowing
        public new void Display()
        {
            //Using Parent class instance to Invoke the Parent Methods
            Parent parent = new Parent();
            parent.Display();
            //Using base keyword to invoke the Parent method
            base.Show();
            Console.WriteLine("Child Class Display Method");
        }
        //Overriding Virtual Method
        //Method Overriding
        public override void Method1()
        {
            Console.WriteLine("Child Class Method1 Method");
        }
        //Overriding Non-Virtual Method
        //Not Possible. Compile Time Error
        //public override void Method2()
        //{
        //    Console.WriteLine("Child Class Method2 Method");
        //}
        //Method Hiding/Shadowing Virtual Method
        public new void Method3()
        {
            Console.WriteLine("Child Class Method3 Method");
        }
        //Method Hiding/Shadowing Non-Virtual Method
        public new void Method4()
        {
            Console.WriteLine("Child Class Method4 Method");
        }
    }
}
