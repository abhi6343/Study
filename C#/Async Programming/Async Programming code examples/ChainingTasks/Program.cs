namespace ChainingTasks
{
    internal class Program
    {
        #region Continuation for a single antecedent
        //static void Main(string[] args)
        //{
        //    Task<string> task1 = Task.Run(() =>
        //    {
        //        return 12;
        //    }).ContinueWith((antecedent) =>
        //    {
        //        return $"The Square of {antecedent.Result} is: {antecedent.Result * antecedent.Result}";
        //    });
        //    Console.WriteLine(task1.Result);

        //    Console.ReadKey();
        //}
        #endregion

        #region Scheduling different continuation tasks
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Task<int> task = Task.Run(() =>
            {
                return 10;
            });


            task.ContinueWith((i) =>
            {
                Console.WriteLine("Task Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);


            task.ContinueWith((i) =>
            {
                Console.WriteLine("Task Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);


            var completedTask = task.ContinueWith((i) =>
            {
                Console.WriteLine("Task Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);


            completedTask.Wait();
            Console.ReadKey();
        }
        #endregion
    }
}
