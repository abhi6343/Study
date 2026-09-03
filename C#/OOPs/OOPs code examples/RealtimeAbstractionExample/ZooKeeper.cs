namespace RealtimeAbstractionExample
{
    //Using the Abstraction
    //With the abstraction in place, you can easily handle any animal without knowing its specific type
    internal class ZooKeeper
    {
        public void CheckAnimalSound(IAnimal animal)
        {
            animal.MakeSound();
        }
    }
}
