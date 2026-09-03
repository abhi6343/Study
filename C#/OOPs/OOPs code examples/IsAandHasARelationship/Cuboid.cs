namespace IsAandHasARelationship
{
    //Establishing Parent-Child Relationship
    //IS-A Relationship i.e. Cuboid IS-A Rectangle
    internal class Cuboid : Rectangle
    {
        public int Height;
        public Cuboid(int l, int b, int h)
        {
            Length = l;
            Breadth = b;
            Height = h;
        }
        public int Volume()
        {
            return Length * Breadth * Height;
        }
    }
}
