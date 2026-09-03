namespace MultipleInheritance
{
    internal class MultipleInheritanceTest : Interface1, Interface2
    {
        //Normal Implementation
        public void Test()
        {
            Console.WriteLine("Test Method is Implemented in Child Class");
        }

        //Explicit Interface Implementation
        void Interface1.Show()
        {
            Console.WriteLine("Interface1 Show Method is Implemented in Child Class");
        }
        //Explicit Interface Implementation
        void Interface2.Show()
        {
            Console.WriteLine("Interface2 Show Method is Implemented in Child Class");
        }
    }
}
