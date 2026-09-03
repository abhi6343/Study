namespace IsAandHasARelationship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //#region Is A relationship
            //Cuboid cuboid = new Cuboid(3, 5, 7);
            //Console.WriteLine($"Volume is : {cuboid.Volume()}");
            //Console.WriteLine($"Area is : {cuboid.Area()}");
            //Console.WriteLine($"Perimeter is : {cuboid.Perimeter()}");
            //#endregion


            #region Has A relationship
            Address address = new Address("B1-3029", "BBSR", "Odisha");
            Employee employee = new Employee(1001, "Ramesh", address);
            employee.Display();
            #endregion


            Console.ReadKey();
        }
    }
}
