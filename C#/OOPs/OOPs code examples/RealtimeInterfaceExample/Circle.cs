namespace RealtimeInterfaceExample
{
    //Step 2: Implement the interface for different shapes.
    // Circle.cs
    internal class Circle : IDrawable
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a circle.");
        }
    }
}
