namespace Thread_Constructor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Thread t1 = new Thread(DisplayNumbers);

            //ThreadStart obj = new ThreadStart(DisplayNumbers);
            //Thread t1 = new Thread(obj);

            //Thread t1 = new Thread(delegate ()
            //{
            //    for (int i = 1; i <= 5; i++)
            //    {
            //        Console.WriteLine("Method1 :" + i);
            //    }
            //});

            //Thread t1 = new Thread(() =>
            //{
            //    for (int i = 1; i <= 5; i++)
            //    {
            //        Console.WriteLine("Method1 :" + i);
            //    }
            //});
            //t1.Start();

            //DisplayNumbers is now a non-static method, so we need to
            //refer it by using the instannce
            Program obj = new Program();
            Thread t1 = new Thread(obj.DisplayNumbers);

            //ParameterizedThreadStart PTSD = new ParameterizedThreadStart(obj.DisplayNumbers);
            //Thread t1 = new Thread(PTSD);

            //Thread t1 = new Thread(new ParameterizedThreadStart(obj.DisplayNumbers));
            //t1.Start(5);

            t1.Start("Hi");
            //int Max = 10;
            //NumberHelper obj = new NumberHelper(Max);
            //Thread T1 = new Thread(new ThreadStart(obj.DisplayNumbers));
            //T1.Start();

            //Create the ResultCallbackDelegate instance and to its constructor pass the callback method name
            //ResultCallbackDelegate resultCallbackDelegate = new ResultCallbackDelegate(ResultCallBackMethod);
            //int Number = 10;
            //Creating the instance of NumberHelper class by passing the Number and the callback delegate instance
            //NumberHelper obj = new NumberHelper(Number, resultCallbackDelegate);
            //Creating the Thread using ThreadStart delegate
            //Thread T1 = new Thread(new ThreadStart(obj.CalculateSum));
            //T1.Start();
            Console.Read();
        }

        //Callback method and the signature should be the same as the callback signature
        public static void ResultCallBackMethod(int Result)
        {
            Console.WriteLine("The Result is " + Result);
        }

        static void DisplayNumbers()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method1 :" + i);
            }
        }
        public void DisplayNumbers(object Max)
        {
            int Number = Convert.ToInt32(Max);
            for (int i = 1; i <= Number; i++)
            {
                Console.WriteLine("Method1 :" + i);
            }
        }
    }
}
