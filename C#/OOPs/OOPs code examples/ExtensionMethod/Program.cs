namespace ExtensionMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OldClass obj = new OldClass();
            obj.Test1();
            obj.Test2();


            //Calling Extension Methods
            obj.Test3();
            obj.Test4(10);
            obj.Test5();


            string myWord = "Welcome to Dotnet Tutorials Extension Methods Article";
            int wordCount = myWord.GetWordCount();
            Console.WriteLine("string : " + myWord);
            Console.WriteLine("Count : " + wordCount);


            List<int> intList = new List<int>() { 10, 20, 30, 40, 50 };
            //If you go to the definition of Where method, then you will see t
            //it is implemented as an extension method
            var List1 = intList.Where(x => x > 20).ToList();


            Console.ReadLine();
        }
    }
}
