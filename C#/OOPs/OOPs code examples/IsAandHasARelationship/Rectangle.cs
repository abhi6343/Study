namespace IsAandHasARelationship
{
    internal class Rectangle
    {
        //Data Members
        public int Length;
        public int Breadth;
        //Member Functions
        public int Area()
        {
            return Length * Breadth;
        }
        public int Perimeter()
        {
            return 2 * (Length + Breadth);
        }
    }
}
