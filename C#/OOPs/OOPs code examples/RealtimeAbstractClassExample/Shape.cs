namespace RealtimeAbstractClassExample
{
    //Shape.cs (Abstract Class)
    internal abstract class Shape
    {
        public string Name { get; set; }
        // Abstract method with no body
        public abstract double Area();
        // Virtual method with a default implementation
        public virtual void Display()
        {
            Console.WriteLine($"{Name}: Area = {Area()}");
        }
    }
}
