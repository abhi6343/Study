namespace RealtimeInterfaceExample
{
    // Airplane.cs
    internal class Airplane : IMovable
    {
        public void Move()
        {
            Console.WriteLine("The airplane flies in the sky.");
        }
    }
}
