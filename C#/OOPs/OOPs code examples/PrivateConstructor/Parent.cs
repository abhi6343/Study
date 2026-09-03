namespace PrivateConstructor
{
    internal class Parent
    {
        //Private Constructor
        private Parent()
        {
            Console.WriteLine("Parent Class Private Constructor is Called");
        }
        //Public Constructor
        public Parent(string Message)
        {
            Console.WriteLine("Parent Class Public Constructor is Called");
        }
    }

    //#region Child inner class
    //internal sealed class Parent
    ////internal class Parent
    //{
    //    //Private Constructor
    //    private Parent()
    //    {
    //        Console.WriteLine("Parent Class Private Constructor is Called");
    //    }
    //    public class Child : Parent
    //    {
    //        public Child()
    //        {
    //            Console.WriteLine("Child Class Public Constructor is Called");
    //        }
    //    }
    //}
    //public class Child2 : Parent
    //{
    //    public Child2()
    //    {
    //        Console.WriteLine("Child2 Class Public Constructor is Called");
    //    }
    //}
    //#endregion
}
