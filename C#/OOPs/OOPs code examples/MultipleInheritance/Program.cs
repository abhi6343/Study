namespace MultipleInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MultipleInheritanceTest obj = new MultipleInheritanceTest();
            obj.Test();


            //You cannot call the Show method using obj
            //obj.Show();
            //Using Interface Reference call the Show method
            Interface1 i1 = obj;
            i1.Show();
            //Typecast the object to interface type and call the show method
            ((Interface2)obj).Show();


            Demo DemoObject = new Demo();
            ((Car)DemoObject).Drive();
            ((Bus)DemoObject).Drive();


            Console.ReadKey();
        }
    }
}
