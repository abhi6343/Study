namespace BridgeDesignPattern
{
    public class GreenCircle : IDrawAPI
    {
        public void drawCircle(int radius, int x, int y)
        {
            Console.WriteLine("Drawing Circle [ color: green, radius: " + radius + ", x: " + x + ", y: " + y + "]");
        }
    }
}
