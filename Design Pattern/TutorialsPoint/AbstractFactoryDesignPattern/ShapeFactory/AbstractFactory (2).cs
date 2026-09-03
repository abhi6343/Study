namespace AbstractFactoryDesignPattern
{
    public abstract class AbstractFactory
    {
        public abstract IColor? getColor(string color);
        public abstract IShape? getShape(string shape);    
    }
}
  