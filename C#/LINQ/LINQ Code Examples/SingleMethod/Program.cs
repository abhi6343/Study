namespace SingleMethod
{
    internal class Program
    {
        //#region Single method
        //static void Main(string[] args)
        //{
        //    //Sequence contains one element
        //    List<int> numbers = new List<int>() { 10 };

        //    //Fetching the Only Element from the Sequenece using Method Syntax
        //    int numberMS = numbers.Single();

        //    //Fetching the Only Element from the Sequenece using Query Syntax
        //    int numberQS = (from num in numbers
        //                    select num).Single();

        //    //Printing the Returned element by Single Method
        //    Console.WriteLine(numberQS);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Single with empty data source
        //static void Main(string[] args)
        //{
        //    //Sequence contains no element i.e. Empty Data Source
        //    List<int> numbers = new List<int>();

        //    //Fetching the Only Element from the Sequenece using Method Syntax
        //    int numberMS = numbers.Single();

        //    //Fetching the Only Element from the Sequenece using Query Syntax
        //    int numberQS = (from num in numbers
        //                    select num).Single();

        //    //Printing the Returned element by Single Method
        //    Console.WriteLine(numberQS);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Single with more than one element in data source
        //static void Main(string[] args)
        //{
        //    //Sequence contains more than one element
        //    List<int> numbers = new List<int>() { 10, 20, 30 };

        //    //Fetching the Only Element from the Sequenece using Method Syntax
        //    int numberMS = numbers.Single();

        //    //Fetching the Only Element from the Sequenece using Query Syntax
        //    int numberQS = (from num in numbers
        //                    select num).Single();

        //    //Printing the Returned element by Single Method
        //    Console.WriteLine(numberQS);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Single with predicate
        //static void Main(string[] args)
        //{
        //    //Sequence contains more than one element
        //    List<int> numbers = new List<int>() { 10, 20, 30 };

        //    //Fetching the Only Element from the Sequenece using Method Syntax
        //    //Where the Element is 20
        //    int numberMS = numbers.Single(num => num == 20);

        //    //Fetching the Only Element from the Sequenece using Query Syntax
        //    //Where the Element is 20
        //    int numberQS = (from num in numbers
        //                    select num).Single(num => num == 20);

        //    //Printing the Returned element by Single Method
        //    Console.WriteLine(numberQS);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Single with predicate returns more than one value
        //static void Main(string[] args)
        //{
        //    //Sequence contains more than one element
        //    List<int> numbers = new List<int>() { 10, 20, 30 };

        //    //Fetching the Only Element from the Sequenece using Method Syntax
        //    //Where the Element > 10
        //    int numberMS = numbers.Single(num => num > 10);

        //    //Fetching the Only Element from the Sequenece using Query Syntax
        //    //Where the Element > 10
        //    int numberQS = (from num in numbers
        //                    select num).Single(num => num > 10);

        //    //Printing the Returned element by Single Method
        //    Console.WriteLine(numberQS);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Single with predicate returns no value
        //static void Main(string[] args)
        //{
        //    //Sequence contains more than one element
        //    List<int> numbers = new List<int>() { 10, 20, 30 };

        //    //Fetching the Only Element from the Sequenece using Method Syntax
        //    //Where the Element < 10
        //    int numberMS = numbers.Single(num => num < 10);

        //    //Fetching the Only Element from the Sequenece using Query Syntax
        //    //Where the Element < 10
        //    int numberQS = (from num in numbers
        //                    select num).Single(num => num < 10);

        //    //Printing the Returned element by Single Method
        //    Console.WriteLine(numberQS);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region SingleOrDefault method
        //static void Main(string[] args)
        //{
        //    List<int> numbers = new List<int>() { 10, 20, 30 };

        //    int number = numbers.SingleOrDefault(num => num < 10);

        //    Console.WriteLine(number);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region SingleOrDefault with empty sequence
        //static void Main(string[] args)
        //{
        //    //Sequence contains no element
        //    List<int> numbers = new List<int>();

        //    //Fetching the Only Element from the Sequenece using Method Syntax
        //    //Where the Element < 10
        //    int numberMS = numbers.SingleOrDefault(num => num < 10);

        //    //Fetching the Only Element from the Sequenece using Query Syntax
        //    //Where the Element < 10
        //    int numberQS = (from num in numbers
        //                    select num).SingleOrDefault(num => num < 10);

        //    //Printing the Returned element by Single Method
        //    Console.WriteLine(numberQS);
        //    Console.ReadLine();
        //}
        //#endregion


        #region SingleOrDefault with predicate returns more than one value
        static void Main(string[] args)
        {
            //Sequence contains
            List<int> numbers = new List<int>() { 10, 20, 30 };

            //Fetching the Only Element from the Sequenece using Method Syntax
            //Where the Element > 10
            int numberMS = numbers.SingleOrDefault(num => num > 10);

            //Fetching the Only Element from the Sequenece using Query Syntax
            //Where the Element > 10
            int numberQS = (from num in numbers
                            select num).SingleOrDefault(num => num > 10);
            //Printing the Returned element by Single Method
            Console.WriteLine(numberQS);
            Console.ReadLine();
        }
        #endregion
    }
}
