namespace TaskClass
{
    internal class Program
    {
        //#region Task object
        //static void Main(string[] args)
        //{
        //    Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Statred");
        //    Action actionDelegate = new Action(PrintCounter);

        //    //Task task1 = new Task(actionDelegate);
        //    //You can directly pass the PrintCounter method as its signature is same as Action delegate
        //    //Task task1 = new Task(PrintCounter);
        //    //task1.Start();

        //    //Task task1 = Task.Factory.StartNew(PrintCounter);

        //    //Task task1 = Task.Run(() => { PrintCounter(); });

        //    Task task1 = Task.Run(() => { PrintCounter(); });
        //    task1.Wait();

        //    Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
        //    Console.ReadKey();
        //}
        //static void PrintCounter()
        //{
        //    Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
        //    for (int count = 1; count <= 5; count++)
        //    {
        //        Console.WriteLine($"count value: {count}");
        //    }
        //    Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
        //}
        //#endregion

        #region Task using Lamda
        static void Main(string[] args)
        {
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Statred");

            #region Start Method
            //Creating Task using Method
            Task task1 = new Task(PrintCounter);
            task1.Start();
            //Creating Task using Anonymous Method
            Task task2 = new Task(delegate ()
            {
                Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
                Task.Delay(200);
                Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
            });
            task2.Start();
            //Creating Task using Lambda Expression
            Task task3 = new Task(() =>
            {
                Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
                Task.Delay(200);
                Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
            });
            task3.Start();
            #endregion

            #region StartNew
            //Creating Task using Method
            Task task4 = Task.Factory.StartNew(PrintCounter);
            //Creating Task using Anonymous Method
            Task task5 = Task.Factory.StartNew(delegate ()
            {
                Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
                Task.Delay(200);
                Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
            });
            //Creating Task using Lambda Expression
            Task task6 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
                Task.Delay(200);
                Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
            });
            #endregion

            #region Run
            //Creating Task using Method
            Task task7 = Task.Run(() => { PrintCounter(); });
            //Creating Task using Anonymous Method
            Task task8 = Task.Run(delegate ()
            {
                Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
                Task.Delay(200);
                Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
            });
            //Creating Task using Lambda Expression
            Task task9 = Task.Run(() =>
            {
                Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
                Task.Delay(200);
                Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
            });
            #endregion

            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
            Console.ReadKey();
        }
        static void PrintCounter()
        {
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            Thread.Sleep(200);
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
        }
        #endregion
    }
}
