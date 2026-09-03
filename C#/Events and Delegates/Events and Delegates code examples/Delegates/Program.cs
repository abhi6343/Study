using System.Reflection;

namespace Delegates
{
    internal class Program
    {

        //#region Delegate example
        //public delegate void WorkPerformedHandler(int hours, WorkType workType);

        //static void Main(string[] args)
        //{
        //    WorkPerformedHandler del1 = new WorkPerformedHandler(Manager_WorkPerformed);
        //    del1(10, WorkType.Golf);
        //    //del1.Invoke(50, WorkType.GotoMeetings);
        //    Console.ReadKey();
        //}
        //public static void Manager_WorkPerformed(int workHours, WorkType wType)
        //{
        //    Console.WriteLine("Work Performed by Event Handler");
        //    Console.WriteLine($"Work Hours: {workHours}, Work Type: {wType}");
        //}
        //#endregion


        //#region Callback
        //public delegate void CallbackMethodHandler(string message);
        //static void Main(string[] args)
        //{
        //    Program obj = new Program();
        //    CallbackMethodHandler del1 = new CallbackMethodHandler(obj.CallbackMethod);
        //    //Here, I am calling the DoSomework function and I want the 
        //    //DoSomework function to call the delegate at some point of time
        //    //which will invoke the CallbackMethod method
        //    DoSomework(del1);
        //    Console.ReadKey();
        //}
        //public static void DoSomework(CallbackMethodHandler del)
        //{
        //    Console.WriteLine("Processing some Task");
        //    del("Pranaya");
        //}
        //public void CallbackMethod(string message)
        //{
        //    Console.WriteLine("CallbackMethod Executed");
        //    Console.WriteLine($"Hello: {message}, Good Morning");
        //}
        //#endregion


        #region Properties of delegate
        public delegate void DoSomeMethodHandler(string message);
        static void Main(string[] args)
        {
            SomeClass obj = new SomeClass();
            DoSomeMethodHandler del1 = new DoSomeMethodHandler(obj.DoSomework);
            MethodInfo Method = del1.Method;
            object? Target = del1.Target;
            Delegate[] InvocationList = del1.GetInvocationList();
            Console.WriteLine($"Method Property: {Method}");
            Console.WriteLine($"Target Property: {Target}");

            foreach (var item in InvocationList)
            {
                Console.WriteLine($"InvocationList: {item}");
            }

            Console.ReadKey();
        }
        #endregion
    }
    public enum WorkType
    {
        Golf,
        GotoMeetings,
        GenerateReports
    }
}
