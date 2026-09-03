namespace MethodHiding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Child obj = new Child();
            //obj.Show();
            //obj.Display();


            //obj.Method1();
            //obj.Method2();
            //obj.Method3();
            //obj.Method4();


            Parent obj = new Child();
            obj.Show();
            obj.Display();


            Console.ReadKey();
        }
    }
}
