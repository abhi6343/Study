namespace RealtimeAbstractClassExample
{
    //Circle.cs (Concrete Class)
    internal class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Name = "Circle";
            Radius = radius;
        }
        // Concrete implementation of the Area method for Circle
        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
