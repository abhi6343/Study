namespace RealtimeAbstractClassExample
{
    //Dog.cs (Concrete Class)
    internal class Dog : Animal
    {
        public Dog(string name)
        {
            Name = name;
        }
        // Concrete implementation of the Speak method for Dog
        public override void Speak()
        {
            Console.WriteLine($"{Name} says: Woof!");
        }
    }
}
