namespace DecoratorDesignPattern
{
    public class Rectangle : IShape
    {
        public void draw()
        {
            Console.WriteLine("Shape: Rectangle");
        }
    }
}
