namespace Destructors
{
    internal class Third : Second
    {
        ~Third()
        {
            Console.WriteLine("Destructor of Third Called");
        }
    }
}
