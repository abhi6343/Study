namespace MethodOverloading
{
    internal class ConstructorOverloading
    {
        int x, y, z;
        public ConstructorOverloading(int x)
        {
            Console.WriteLine("Constructor1 Called");
            this.x = 10;
        }
        public ConstructorOverloading(int x, int y)
        {
            Console.WriteLine("Constructor2 Called");
            this.x = x;
            this.y = y;
        }
        public ConstructorOverloading(int x, int y, int z)
        {
            Console.WriteLine("Constructor3 Called");
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public void Display()
        {
            Console.WriteLine($"X={x}, Y={y}, Z={z}");
        }
    }
}
