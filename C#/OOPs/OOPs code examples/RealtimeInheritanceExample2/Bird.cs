namespace RealtimeInheritanceExample2
{
    //Derived Class (Child Class) - Bird
    internal class Bird : Animal
    {
        public bool CanFly { get; set; }
        public Bird(string name, int age, string diet, bool canFly)
            : base(name, age, diet)
        {
            CanFly = canFly;
        }
        public void Fly()
        {
            if (CanFly)
                Console.WriteLine($"{Name} is flying.");
            else
                Console.WriteLine($"{Name} cannot fly.");
        }
        public override void Display()
        {
            base.Display();
            Fly();
        }
    }
}
