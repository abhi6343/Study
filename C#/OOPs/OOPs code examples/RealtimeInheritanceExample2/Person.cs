namespace RealtimeInheritanceExample2
{
    //Base Class (Parent Class) - Person
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public Person(string name, int age, string address)
        {
            Name = name;
            Age = age;
            Address = address;
        }
        public void DisplayDetails()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Address: {Address}");
        }
    }
}
