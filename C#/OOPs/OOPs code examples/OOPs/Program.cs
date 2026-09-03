namespace OOPs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creating object
            Calculator calObject = new Calculator();

            //Accessing Calculator class member using Calculator class object
            int result = calObject.CalculateSum(10, 20);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
