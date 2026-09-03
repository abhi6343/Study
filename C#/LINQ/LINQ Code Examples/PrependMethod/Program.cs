namespace PrependMethod
{
    internal class Program
    {
        #region Prepend
        static void Main(string[] args)
        {
            // Creating a list of numbers
            List<int> numberSequence = new List<int> { 10, 20, 30, 40 };

            // Trying to prepend 50
            numberSequence.Prepend(50);

            // It will not work because the original sequence has not been changed
            Console.WriteLine(string.Join(", ", numberSequence));

            // It works now because we are using a changed copy of the original list
            Console.WriteLine(string.Join(", ", numberSequence.Prepend(50)));

            // If you prefer, you can create a new list explicitly
            List<int> newnumberSequence = numberSequence.Prepend(50).ToList();

            // And then write to the console output
            Console.WriteLine(string.Join(", ", newnumberSequence));
            Console.ReadKey();
        }
        #endregion
    }
}
