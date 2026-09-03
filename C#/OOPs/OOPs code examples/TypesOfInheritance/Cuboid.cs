namespace TypesOfInheritance
{
    //Child class
    internal class Cuboid : Rectangle
    {
        public int height;
        public Cuboid(int l, int b, int h)
        {
            length = l;
            breadth = b;
            height = h;
        }
        public int Volume()
        {
            return length * breadth * height;
        }
    }
}
