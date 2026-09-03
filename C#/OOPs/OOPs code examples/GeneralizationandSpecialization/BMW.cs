namespace GeneralizationandSpecialization
{
    internal class BMW : ICar
    {
        public void Start()
        {
            Console.WriteLine($"BMW Start");
        }
        public void Stop()
        {
            Console.WriteLine($"BMW Stop");
        }
    }
}
