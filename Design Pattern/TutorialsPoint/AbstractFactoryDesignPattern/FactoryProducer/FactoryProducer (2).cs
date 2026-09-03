namespace AbstractFactoryDesignPattern
{
    public class FactoryProducer
    {
        public static AbstractFactory? getFactory(string choice)
        {
            if(choice.ToLowerInvariant().Contains("shape"))         return new ShapeFactory();  
            else if(choice.ToLowerInvariant().Contains("color"))    return new ColorFactory();  
            return null;
        }
    }
}
