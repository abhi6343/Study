using System.Collections;
#pragma warning disable CS8600, CS8602 // Converting null literal or possible null value to non-nullable type.
//#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace PrototypeDesignPattern
{
    public class ShapeCache
    {
        private static Hashtable? shapeMap = new Hashtable();
        public static Shape? GetShape(string shapeId)
        {
            Shape? cachedShape= (Shape)shapeMap[key: shapeId];
            return (Shape)cachedShape.Clone();
        }

        // For each Shape run database query and create Shape
        // shapeMap.Add(shapeKey, Shape);
        // For example, we are adding these Shapes
        public static void loadCache()
        {
            Circle circle = new Circle();
            circle.setId("1");
            shapeMap.Add(key: circle.getId(), value: circle);
            Square square = new Square();
            square.setId("2");
            shapeMap.Add(square.getId(), square);
            Rectangle rectangle = new Rectangle();  
            rectangle.setId("3");
            shapeMap.Add(key: rectangle.getId(), rectangle);
        }
    }
}
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8602 // Dereference of a possibly null reference.