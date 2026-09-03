namespace FlyWeightDesignPattern
{
    public class Circle: IShape
    {
        private string color;
        private int x, y, radius;
        public Circle(string color) 
        {
            this.color = color;
        }
        public void setRadius(int radius)
        {
            this.radius = radius;
        }
        public void setX(int x)
        {
            this.x = x;
        }
        public void setY(int y)
        {
            this.y = y;
        }
        public void draw()
        {
            Console.WriteLine("Circle: Draw() [Color : " + color + ", x : " + x + ", y : " + y + ", radius :" + radius);
        }
    }
}
