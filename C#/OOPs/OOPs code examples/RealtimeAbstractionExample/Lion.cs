namespace RealtimeAbstractionExample
{
    //Concrete Implementations
    //Now, let's implement this interface for various animals
    internal class Lion : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("Lion roars!");
        }
    }
}
