namespace FactoryDesignPattern
{
    public class ShapeFcatory
    {
        // Use getShape to get the object of type IShape
        public IShape? getShape(string shapeType)
        {
            if (shapeType == null) return null;

            if(shapeType.ToLowerInvariant().Contains("rectangle"))      return new Rectangle();
            else if(shapeType.ToLowerInvariant().Contains("square"))    return new Square(); 
            else if (shapeType.ToLowerInvariant().Contains("circle"))   return new Circle();

            return null;
        }
    }
}
