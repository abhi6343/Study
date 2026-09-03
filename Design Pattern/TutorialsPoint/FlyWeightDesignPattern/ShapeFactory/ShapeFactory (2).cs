using System.Collections;
#pragma warning disable CS8600

namespace FlyWeightDesignPattern
{
    public class ShapeFactory
    {
        private static Hashtable circleMap = new Hashtable();   
        public static IShape getCircle(string color)
        {
            Circle circle = (Circle)circleMap[color];
            if(circle == null)
            {
                circle = new Circle(color);
                //circleMap[color] = circle;
                circleMap.Add(key: color, value: circle);
                Console.WriteLine("Creating circle of color : " + color);
            }
            return circle;
        }
    }
}
#pragma warning restore CS8600