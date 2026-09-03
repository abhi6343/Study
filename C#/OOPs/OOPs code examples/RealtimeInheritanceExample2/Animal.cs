namespace RealtimeInheritanceExample2
{
    //Base Class (Parent Class) - Animal
    internal class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Diet { get; set; }
        public Animal(string name, int age, string diet)
        {
            Name = name;
            Age = age;
            Diet = diet;
        }
        public void Eat()
        {
            Console.WriteLine($"{Name} is eating {Diet}.");
        }
        public virtual void Display()
        {
            Console.WriteLine($"I am {Name}, a {Age}-year-old animal that eats {Diet}.");
        }
    }
}
