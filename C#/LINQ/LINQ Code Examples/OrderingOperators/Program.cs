namespace OrderingOperators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>()
            {
                new Person { FirstName = "John", LastName = "Doe", Age = 30 },
                new Person { FirstName = "Jane", LastName = "Doe", Age = 25 },
                new Person { FirstName = "Joe", LastName = "Bloggs", Age = 30 },
                // ... other people ...
            };

            var sortedPeople = people
                                .OrderBy(p => p.LastName)
                                .ThenBy(p => p.FirstName)
                                .ThenByDescending(p => p.Age);
            foreach (var person in sortedPeople)
            {
                Console.WriteLine($"{person.LastName}, {person.FirstName}: { person.Age}");
            }
            Console.ReadKey();
        }
    }
}
