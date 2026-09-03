namespace ExtensionMethods
{
    internal class Program
    {
        //#region Extension method syntax and Wrapper class style syntax
        //static void Main(string[] args)
        //{
        //    string sentence = "Welcome to Dotnet Tutorials";
        //    //Extension method syntax
        //    //int wordCount = sentence.GetWordCount();

        //    //Wrapper class style syntax
        //    int wordCount = ExtensionHelper.GetWordCount(sentence);
        //    Console.WriteLine($"Count : {wordCount}");
        //    Console.ReadKey();
        //}
        //#endregion


        #region LINQ extension method as wrapper class style
        static void Main(string[] args)
        {
            List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> EvenNumbers = Enumerable.Where(intList, n => n % 2 == 0);
            foreach (var item in EvenNumbers)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
        }
        #endregion
    }
}
