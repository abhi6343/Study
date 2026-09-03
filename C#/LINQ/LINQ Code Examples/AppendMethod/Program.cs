namespace AppendMethod
{
    internal class Program
    {
        //#region Append
        //static void Main(string[] args)
        //{
        //    // Creating a list of integer
        //    List<int> intSequence = new List<int> { 10, 20, 30, 40 };

        //    // Trying to append 5 at the end of the intSequence
        //    intSequence.Append(5);

        //    //It doesn't work because the original list has not been changed
        //    Console.WriteLine(string.Join(", ", intSequence));

        //    // It works now because we are using a changed copy of the original sequence
        //    Console.WriteLine(string.Join(", ", intSequence.Append(5)));

        //    // Creating a new sequence explicitly
        //    List<int> newintSequence = intSequence.Append(5).ToList();

        //    // Printing the new sequence in the console
        //    Console.WriteLine(string.Join(", ", newintSequence));
        //    Console.ReadKey();
        //}
        //#endregion


        #region Complex example
        static void Main(string[] args)
        {
            var numbers = new[] { 1, 2, 3 };
            var result = numbers
                        .Where(x => x % 2 == 1) // Take odd numbers
                        .Select(x => x * 10)    // Multiply them by 10
                        .Append(100);           // Append the number 100 to the end

            // result now contains 10, 30, 100
            foreach (var item in result)
            {
                Console.Write($"{item} ");
            }
            Console.ReadKey();
        }
        #endregion
    }
}
