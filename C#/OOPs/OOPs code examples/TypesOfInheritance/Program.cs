namespace TypesOfInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Single Inheritance
            // Creating object of Child class and
            // invoke the methods of Parent and Child classes
            Cuboid obj = new Cuboid(2, 4, 6);
            Console.WriteLine($"Volume is : {obj.Volume()}");
            Console.WriteLine($"Area is : {obj.Area()}");
            Console.WriteLine($"Perimeter is : {obj.Perimeter()}");
            #endregion


            //#region Multiple Inheritance
            //// Creating object of Child class and
            //// invoke the methods of Parent classes and Child class
            //SmartPhone obj = new SmartPhone(); ;
            //obj.GetPhoneModel();
            //obj.GetCameraDetails();
            //obj.GetDetails();
            //#endregion


            Console.ReadKey();
        }
    }
}
