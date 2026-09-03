namespace GeneralizationandSpecialization
{
    internal class Rectangle
    {
        public int Length;
        public int Breadth;
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
