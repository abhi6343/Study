namespace AbstractFactoryDesignPattern
{
    public class ColorFactory : AbstractFactory
    {
        public override IShape? getShape(string shapeType)
        {
            return null;
        }
        public override IColor? getColor(string color)
        {
            if (color == null) return null;

            if (color.ToLowerInvariant().Contains("red"))           return new Red();
            else if(color.ToLowerInvariant().Contains("green"))     return new Green(); 
            else if(color.ToLowerInvariant().Contains("blue"))      return new Blue();
            return null;
        }
    }
}
