namespace RealtimePolymorphismExample
{
    // Derived class
    internal class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("The dog barks.");
        }
    }
}
