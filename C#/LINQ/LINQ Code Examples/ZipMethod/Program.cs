namespace ZipMethod
{
    internal class Program
    {
        //#region Zip
        //static void Main(string[] args)
        //{
        //    int[] numbersSequence = { 10, 20, 30, 40, 50 };
        //    string[] wordsSequence = { "Ten", "Twenty", "Thirty", "Fourty" };

        //    var resultSequence = numbersSequence.Zip(wordsSequence, (first, second) => first + " - " + second);

        //    foreach (var item in resultSequence)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        #region Complex example
        static void Main()
        {
            var keys = new List<string> { "ID", "Name", "Email", "Mobile" };
            var values = new List<string> { "1", "Pranaya", "Pranaya@example.com", "1234567890" };

            var dictionary = keys.Zip(values, (k, v) => new { k, v })
                                 .ToDictionary(x => x.k, x => x.v);

            // Now dictionary contains { { "ID", "1" }, { "Name", "Pranaya" }, { "Email", "Pranaya@example.com" }, { "Mobile", "1234567890" } }
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            Console.ReadKey();
        }
        #endregion
    }
}
