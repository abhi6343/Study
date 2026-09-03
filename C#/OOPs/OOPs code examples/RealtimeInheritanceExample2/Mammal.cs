namespace RealtimeInheritanceExample2
{
    //Derived Class (Child Class) - Mammal
    internal class Mammal : Animal
    {
        public string CommunicationSound { get; set; }
        public Mammal(string name, int age, string diet, string sound)
            : base(name, age, diet)
        {
            CommunicationSound = sound;
        }
        public void Communicate()
        {
            Console.WriteLine($"{Name} makes a {CommunicationSound} sound.");
        }
        public override void Display()
        {
            base.Display();
            Communicate();
        }
    }
}
