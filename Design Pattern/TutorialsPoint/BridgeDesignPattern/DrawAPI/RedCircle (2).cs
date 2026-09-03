namespace BridgeDesignPattern
{
    public class RedCircle : IDrawAPI
    {
        public void drawCircle(int radius, int x, int y)
        {
            Console.WriteLine("Drawing Circle [ color: red, radius: " + radius + ", x: " + x + ", y: " + y + "]");
        }
    }
}
