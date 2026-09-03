namespace RealtimePolymorphismExample
{
    // Another derived class
    internal class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("The cat meows.");
        }
    }
}
