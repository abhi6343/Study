namespace GeneralizationandSpecialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Specialization
            Cuboid cuboid = new Cuboid(3, 5, 7);
            Console.WriteLine($"Volume is : {cuboid.Volume()}");
            Console.WriteLine($"Area is : {cuboid.Area()}");
            Console.WriteLine($"Perimeter is : {cuboid.Perimeter()}");
            #endregion


            #region Generalization
            Innova innova = new Innova();
            innova.Start();
            innova.Stop();
            BMW bmw = new BMW();
            bmw.Start();
            bmw.Stop();
            #endregion


            Console.ReadKey();
        }
    }
}
