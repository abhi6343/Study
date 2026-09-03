namespace TypesOfInheritance
{
    //Parent class
    internal class Rectangle
    {
        public int length;
        public int breadth;
        public int Area()
        {
            return length * breadth;
        }
        public int Perimeter()
        {
            return 2 * (length + breadth);
        }
    }
}
