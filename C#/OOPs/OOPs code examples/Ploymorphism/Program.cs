namespace Ploymorphism
{
    internal class Program
    {
        public void Add(int a, int b)
        {
            Console.WriteLine(a + b);
        }
        public void Add(float x, float y)
        {
            Console.WriteLine(x + y);
        }
        public void Add(string s1, string s2)
        {
            Console.WriteLine(s1 + " " + s2);
        }
        static void Main(string[] args)
        {
            #region Static polymorphism
            Program obj = new Program();
            obj.Add(10, 20);
            obj.Add(10.5f, 20.5f);
            obj.Add("Pranaya", "Rout");
            #endregion


            #region Run time polymorphism
            Class1 obj1 = new Class2();
            obj1.Show(); //Resolve at Runtime


            //obj1.Add();
            #endregion


            Console.ReadKey();
        }
    }
}
