namespace Destructors
{
    internal class Second : First
    {
        ~Second()
        {
            Console.WriteLine("Destructor of Second Called");
        }
    }
}
