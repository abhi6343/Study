namespace RealtimeAbstractClassExample
{
    //Rectangle.cs (Concrete Class)
    internal class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle(double width, double height)
        {
            Name = "Rectangle";
            Width = width;
            Height = height;
        }
        // Concrete implementation of the Area method for Rectangle
        public override double Area()
        {
            return Width * Height;
        }
    }
}
