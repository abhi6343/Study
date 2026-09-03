namespace RealtimeAbstractClassExample
{
    //Fish.cs (Concrete Class)
    internal class Fish : Animal
    {
        public Fish(string name)
        {
            Name = name;
        }
        // Fish don't traditionally "speak", so we'll implement this differently
        public override void Speak()
        {
            Console.WriteLine($"{Name} bubbles!");
        }
        // Overriding the Eat method specifically for Fish
        public override void Eat()
        {
            Console.WriteLine($"{Name} is nibbling on some seaweed.");
        }
    }
}
