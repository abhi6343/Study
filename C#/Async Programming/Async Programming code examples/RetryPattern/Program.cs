namespace RetryPattern
{
    internal class Program
    {
        //#region Retry pattern
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Main Method Started");
        //    RetryMethod();

        //    Console.WriteLine("Main Method Completed");
        //    Console.ReadKey();
        //}
        //public static async void RetryMethod()
        //{
        //    //It tells the number of times we will retry the operation if it is failing
        //    //Of course, if it is not failing then we will not retry
        //    var RetryTimes = 3;
        //    //The idea is that we don't want to immediately retry, but 
        //    //we may want to retry after a certain amount of time.
        //    //In our case, it is five hundred milliseconds or half a second.
        //    var WaitTime = 500;
        //    for (int i = 0; i < RetryTimes; i++)
        //    {
        //        try
        //        {
        //            //Do the Operation
        //            //If the Operation Successful break the loop
        //            await RetryOperation();
        //            Console.WriteLine("Operation Successful");
        //            break;
        //        }
        //        catch (Exception Ex)
        //        {
        //            //If the operations throws an error
        //            //Log the Exception if you want
        //            Console.WriteLine($"Retry {i + 1}: Getting Exception : {Ex.Message}");
        //            //Wait for 500 milliseconds
        //            await Task.Delay(WaitTime);
        //        }
        //    }
        //}

        //public static async Task RetryOperation()
        //{
        //    //Doing Some Processing
        //    await Task.Delay(500);
        //    //Throwing Exception so that retry will work
        //    throw new Exception("Exception Occurred in while Processing...");
        //}
        //#endregion

        //#region Generic Retry Pattern 
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Main Method Started");
        //    RetryMethod();

        //    Console.WriteLine("Main Method Completed");
        //    Console.ReadKey();
        //}
        //public static async void RetryMethod()
        //{
        //    //It will retry 3 times, here the function is RetryOperation1
        //    await Retry(RetryOperation1);
        //    //It will retry 4 times, here the function is RetryOperation2
        //    await Retry(RetryOperation2, 4);
        //}
        ////Generic Retry Method
        ////Func is a generate delegate which returns something, in our case it is returning a Task
        ////We are setting the default value for RetryTimes = 3 and WaitTime = 500 milliseconds
        //public static async Task Retry(Func<Task> fun, int RetryTimes = 3, int WaitTime = 500)
        //{
        //    for (int i = 0; i < RetryTimes; i++)
        //    {
        //        try
        //        {
        //            //Do the Operation
        //            //We are going to invoke whatever function the generic func delegate points to
        //            await fun();
        //            Console.WriteLine("Operation Successful");
        //            break;
        //        }
        //        catch (Exception Ex)
        //        {
        //            //If the operations throws an error
        //            //Log the Exception if you want
        //            Console.WriteLine($"Retry {i + 1}: Getting Exception : {Ex.Message}");
        //            //Wait for 500 milliseconds
        //            await Task.Delay(WaitTime);
        //        }
        //    }
        //}
        //public static async Task RetryOperation1()
        //{
        //    //Doing Some Processing
        //    await Task.Delay(500);
        //    //Throwing Exception so that retry will work
        //    throw new Exception("Exception Occurred in RetryOperation1");
        //}
        //public static async Task RetryOperation2()
        //{
        //    //Doing Some Processing
        //    await Task.Delay(500);
        //    //Throwing Exception so that retry will work
        //    throw new Exception("Exception Occurred in RetryOperation2");
        //}
        //#endregion

        //#region Indicate Operation failed or not
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Main Method Started");
        //    RetryMethod();

        //    Console.WriteLine("Main Method Completed");
        //    Console.ReadKey();
        //}
        //public static async void RetryMethod()
        //{
        //    //It will retry 3 times, here the function is RetryOperation1
        //    try
        //    {
        //        await Retry(RetryOperation1);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("The Operation was Failed");
        //    }
        //}
        ////Generic Retry Method
        ////Func is a generate delegate which returns something, in our case it is returning a Task
        ////We are setting the default value for RetryTimes = 3 and WaitTime = 500 milliseconds
        //public static async Task Retry(Func<Task> fun, int RetryTimes = 3, int WaitTime = 500)
        //{
        //    //Reducing the for loop Exection for 1 time
        //    for (int i = 0; i < RetryTimes - 1; i++)
        //    {
        //        try
        //        {
        //            //Do the Operation
        //            //We are going to invoke whatever function the generic func delegate points to
        //            await fun();
        //            Console.WriteLine("Operation Successful");
        //            break;
        //        }
        //        catch (Exception Ex)
        //        {
        //            //If the operations throws an error
        //            //Log the Exception if you want
        //            Console.WriteLine($"Retry {i + 1}: Getting Exception : {Ex.Message}");
        //            //Wait for 500 milliseconds
        //            await Task.Delay(WaitTime);
        //        }
        //    }
        //    //Final try to execute the operation
        //    await fun();
        //}
        //public static async Task RetryOperation1()
        //{
        //    //Doing Some Processing
        //    await Task.Delay(500);
        //    //Throwing Exception so that retry will work
        //    throw new Exception("Exception Occurred in RetryOperation1");
        //}
        //#endregion

        #region Retry return value
        static void Main(string[] args)
        {
            Console.WriteLine("Main Method Started");
            RetryMethod();

            Console.WriteLine("Main Method Completed");
            Console.ReadKey();
        }
        public static async void RetryMethod()
        {
            //It will retry 3 times, here the function is RetryOperation1
            try
            {
                var result = await Retry(RetryOperationValueReturning);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("The Operation was Failed");
            }
        }

        //Generic Retry Method Returning Value
        //Func is a generate delegate which returns something, in our case it is returning a Task
        //We are setting the default value for RetryTimes = 3 and WaitTime = 500 milliseconds
        public static async Task<T> Retry<T>(Func<Task<T>> fun, int RetryTimes = 3, int WaitTime = 500)
        {
            //Reducing the for loop Exection for 1 time
            for (int i = 0; i < RetryTimes - 1; i++)
            {
                try
                {
                    //Do the Operation
                    //We are going to invoke whatever function the generic func delegate points to
                    //We will return from here if the operation was successful
                    return await fun();

                }
                catch (Exception Ex)
                {
                    //If the operations throws an error
                    //Log the Exception if you want
                    Console.WriteLine($"Retry {i + 1}: Getting Exception : {Ex.Message}");
                    //Wait for 500 milliseconds
                    await Task.Delay(WaitTime);
                }
            }
            //Final try to execute the operation
            return await fun();
        }
        public static async Task<string> RetryOperationValueReturning()
        {
            //Doing some processing and return the value
            await Task.Delay(500);
            //Uncomment the below code to successfully return a string
            //return "Operation Successful";
            //Throwing exception so that retry will work
            throw new Exception("Exception Occurred in RetryOperation1");
        }
        #endregion

        //#region Successful operation
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Main Method Started");
        //    RetryMethod();

        //    Console.WriteLine("Main Method Completed");
        //    Console.ReadKey();
        //}
        //public static async void RetryMethod()
        //{
        //    try
        //    {
        //        var result = await Retry(RetryOperationValueReturning);
        //        Console.WriteLine(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("The Operation was Failed");
        //    }
        //}
        //public static async Task<T> Retry<T>(Func<Task<T>> fun, int RetryTimes = 3, int WaitTime = 500)
        //{
        //    for (int i = 0; i < RetryTimes - 1; i++)
        //    {
        //        try
        //        {
        //            return await fun();
        //        }
        //        catch (Exception Ex)
        //        {
        //            Console.WriteLine($"Retry {i + 1}: Getting Exception : {Ex.Message}");
        //            await Task.Delay(WaitTime);
        //        }
        //    }
        //    return await fun();
        //}
        //public static async Task<string> RetryOperationValueReturning()
        //{
        //    await Task.Delay(500);
        //    return "Operation Successful";
        //}
        //#endregion
    }
}
