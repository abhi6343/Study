namespace AbstractFactoryDesignPattern
{
    public class ShapeFactory : AbstractFactory
    {
        public override IShape? getShape(string shapeType)
        {
            if (shapeType == null) return null;

            if(shapeType.ToLowerInvariant().Contains("circle"))             return new Circle();
            else if(shapeType.ToLowerInvariant().Contains("rectangle"))     return new Rectangle(); 
            else if(shapeType.ToLowerInvariant().Contains("square"))        return new Square();    
            
            return null;
        }
        public override IColor? getColor(string Icolor)
        {
            return null;
        }
    }
}
