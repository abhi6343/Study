namespace PrototypeDesignPattern
{
    public class Rectangle : Shape
    {
        public Rectangle()
        {
            type = "Rectangle";
        }
        public override void draw()
        {
            Console.WriteLine("Inside Rectangle:: draw() method.");   
        }
    }
}
