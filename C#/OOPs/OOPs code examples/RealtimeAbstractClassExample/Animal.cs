namespace RealtimeAbstractClassExample
{
    //Animal.cs (Abstract Class)
    internal abstract class Animal
    {
        public string Name { get; set; }
        // Abstract method with no body
        public abstract void Speak();
        // Virtual method with a default implementation
        public virtual void Eat()
        {
            Console.WriteLine($"{Name} is eating.");
        }
    }
}
