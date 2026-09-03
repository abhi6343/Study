namespace OnlyOnePattern
{
    internal class Program
    {
        //#region Only one pattern
        //static void Main(string[] args)
        //{
        //    OnlyOnePattern();
        //    Console.ReadKey();
        //}
        //public static async void OnlyOnePattern()
        //{
        //    //Creating the Cancellation Token
        //    var CTS = new CancellationTokenSource();
        //    //Creating the list of names to process by the ProcessingName method
        //    List<string> names = ["Pranaya", "Anurag", "James", "Smith"];
        //    Console.WriteLine($"All Names");
        //    foreach (var item in names)
        //    {
        //        Console.Write($"{item} ");
        //    }
        //    //Creating the tasks by passing the name and cancellation token using Linq
        //    //It will invoke the ProcessingName method by passing name and cancellation token
        //    var tasks = names.Select(x => ProcessingName(x, CTS.Token));

        //    var task = await Task.WhenAny(tasks);
        //    //Fetch the first completed result
        //    var content = await task;
        //    //Cancel the token
        //    CTS.Cancel();
        //    //Print the content
        //    Console.WriteLine($"\n{content}");
        //}
        //public static async Task<string> ProcessingName(string name, CancellationToken token)
        //{
        //    //Creating dynamic waiting time
        //    //The following statement will generate a number between 1 and 10 dynamically
        //    var WaitingTime = new Random().NextDouble() * 10 + 1;
        //    await Task.Delay(TimeSpan.FromSeconds(WaitingTime), token);
        //    string message = $"Hello {name}";
        //    return message;
        //}
        //#endregion

        #region Generic only one pattern
        static void Main(string[] args)
        {
            SomeMethod();
            Console.ReadKey();
        }
        public static async void SomeMethod()
        {
            //Creating the collection of names
            List<string> names = ["Pranaya", "Anurag", "James", "Smith"];
            Console.WriteLine($"All Names");
            foreach (var item in names)
            {
                Console.Write($"{item} ");
            }
            //Creating the IEnumerable of Generic Func which points to ProcessName method
            //by passing the name and cancellation token
            var tasks = names.Select(name =>
            {
                Task<string> func(CancellationToken ct) => ProcessName(name, ct);
                return (Func<CancellationToken, Task<string>>)func;
            });
            //Calling the GenericOnlyOnePattern method by passing the collection of Func delegate
            var content = await GenericOnlyOnePattern(tasks);
            //Printing the content
            Console.WriteLine($"\n{content}");
        }
        //The Generic OnlyOne Pattern 
        //Here the parameter IEnumerable<Func<CancellationToken, Task<T>>> functions specify
        //a collection of method that takes Cancellation Token as a parameter and returns a Task<T>
        public static async Task<T> GenericOnlyOnePattern<T>(IEnumerable<Func<CancellationToken, Task<T>>> functions)
        {
            //Creating local CancellationTokenSource
            var cancellationTokenSource = new CancellationTokenSource();

            //Invoking the function by passing the Cancellation Token
            //It will invoke the functions which is pointed by the Func Generic Delegate
            var tasks = functions.Select(function => function(cancellationTokenSource.Token));
            //Calling the WhenAny method by passing the list of tasks
            //It create a task that represents the completion of one of the supplied tasks. 
            //The return task's Result is the task that completed. 
            var task = await Task.WhenAny(tasks);
            //Cancel the token
            cancellationTokenSource.Cancel();
            //Return the content
            return await task;
        }
        public static async Task<string> ProcessName(string name, CancellationToken token)
        {
            //Creating Dynamic Waiting Time
            //The following statement will generate a number between 1 and 10 dynamically
            var WaitingTime = new Random().NextDouble() * 10 + 1;
            await Task.Delay(TimeSpan.FromSeconds(WaitingTime), token);
            string message = $"Hello {name}";
            return message;
        }
        #endregion

        //#region Generic only one pattern with different method
        //static void Main(string[] args)
        //{
        //    SomeMethod();
        //    Console.ReadKey();
        //}
        //public static async void SomeMethod()
        //{
        //    //Calling two Different Method using Generic Only One Pattern
        //    var content = await GenericOnlyOnePattern(
        //          //Calling the HelloMethod
        //          (ct) => HelloMethod("Pranaya", ct),
        //          //Calling the GoodbyeMethod
        //          (ct) => GoodbyeMethod("Anurag", ct)
        //          );
        //    //Printing the result on the Console
        //    Console.WriteLine($"{content}");
        //}
        //public static async Task<T> GenericOnlyOnePattern<T>(params Func<CancellationToken, Task<T>>[] functions)
        //{
        //    var cancellationTokenSource = new CancellationTokenSource();
        //    var tasks = functions.Select(function => function(cancellationTokenSource.Token));
        //    var task = await Task.WhenAny(tasks);
        //    cancellationTokenSource.Cancel();
        //    return await task;
        //}

        //public static async Task<string> HelloMethod(string name, CancellationToken token)
        //{
        //    var WaitingTime = new Random().NextDouble() * 10 + 1;
        //    await Task.Delay(TimeSpan.FromSeconds(WaitingTime));
        //    string message = $"Hello {name}";
        //    return message;
        //}
        //public static async Task<string> GoodbyeMethod(string name, CancellationToken token)
        //{
        //    var WaitingTime = new Random().NextDouble() * 10 + 1;
        //    await Task.Delay(TimeSpan.FromSeconds(WaitingTime));
        //    string message = $"Goodbye {name}";
        //    return message;
        //}
        //#endregion
    }
}
