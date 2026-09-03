using System.Numerics;
using System;

namespace ChildTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //#region Parent not waiting for detached child execution to complete
            //Console.WriteLine("Main Method Started");

            ////Creating the Parent Task
            //var parentTask = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("Outer Task Started");
            //    //Creating the Child Task
            //    var childTask = Task.Factory.StartNew(() =>
            //    {
            //        Console.WriteLine("Child Task Started.");
            //        Thread.Sleep(5000);
            //        Console.WriteLine("Child Task Completed");
            //    });
            //    Console.WriteLine("Outer Task Completed");
            //});

            ////Waiting for the parent task execution to be completed. Not the child task
            //parentTask.Wait();

            //Console.WriteLine("Main Method Completed");
            //Console.ReadKey();
            //#endregion


            //#region Parent waiting for detached child execution to complete
            //Console.WriteLine("Main Method Started");
            ////Creating the Parent Task
            //var parentTask = Task<string>.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("Outer Task Started");
            //    //Creating the Child Task
            //    var childTask = Task<string>.Factory.StartNew(() =>
            //    {
            //        Console.WriteLine("Child Task Started");
            //        Thread.Sleep(5000);
            //        Console.WriteLine("Child Task Completed");
            //        return "Task Completed";
            //    });
            //    // Parent Task will wait for detached Child Task to complete its execution
            //    return childTask.Result;
            //});
            ////Here, parentTask.Result will block the Main thread, till the Parent complete its execution
            //Console.WriteLine($"Parent Task Returned: {parentTask.Result}");
            //Console.WriteLine("Main Method Completed");
            //Console.ReadKey();
            //#endregion


            //#region Attached task
            //Console.WriteLine("Main Method Started");

            ////Creating the Parent Task
            //var parentTask = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("Outer Task Started");
            //    //Creating the Child Task
            //    var childTask = Task.Factory.StartNew(() =>
            //    {
            //        Console.WriteLine("Child Task Started");
            //        Thread.Sleep(5000);
            //        Console.WriteLine("Child Task Completed");
            //    }, TaskCreationOptions.AttachedToParent);
            //    Console.WriteLine("Outer Task Completed");
            //});

            ////Waiting for the parent task to be completed.
            //parentTask.Wait();

            //Console.WriteLine("Main Method Completed");
            //Console.ReadKey();
            //#endregion


            //#region Deny child attach in parent
            //Console.WriteLine("Main Method Started");

            ////Creating the Parent Task using Task.Run Method
            //var parentTask = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("Outer Task Started");
            //    //Creating the Child Task with AttachedToParent
            //    var childTask = Task.Factory.StartNew(() =>
            //    {
            //        Console.WriteLine("Child Task Started");
            //        Thread.Sleep(5000);
            //        Console.WriteLine("Child Task Completed");
            //    }, TaskCreationOptions.AttachedToParent);
            //    Console.WriteLine("Outer Task Completed");
            //}, TaskCreationOptions.DenyChildAttach);

            ////Waiting for the Parent Task to completed.
            //parentTask.Wait();

            //Console.WriteLine("Main Method Completed");
            //Console.ReadKey();
            //#endregion


            //#region Deny child attach in parent using Task.Run
            //Console.WriteLine("Main Method Started");

            ////Creating the Parent Task using Task.Run Method
            //var parentTask = Task.Run(() => {
            //    Console.WriteLine("Outer Task Started");
            //    //Creating the Child Task with AttachedToParent
            //    var childTask = Task.Factory.StartNew(() => {
            //        Console.WriteLine("Child Task Started");
            //        Thread.Sleep(5000);
            //        Console.WriteLine("Child Task Completed");
            //    }, TaskCreationOptions.AttachedToParent);
            //    Console.WriteLine("Outer Task Completed");
            //});

            ////Waiting for the Parent Task to completed.
            //parentTask.Wait();

            //Console.WriteLine("Main Method Completed");
            //Console.ReadKey();
            //#endregion


            //#region Exception in detached child
            //Console.WriteLine("Main Method Started");

            //try
            //{
            //    //Creating the Parent Task using Task.Run Method
            //    var parentTask = Task.Factory.StartNew(() =>
            //    {
            //        Console.WriteLine("Outer Task Started");
            //        //Creating the Child Task with AttachedToParent
            //        var childTask = Task.Factory.StartNew(() =>
            //        {
            //            Console.WriteLine("Child Task Started");
            //            int x = 10, y = 0;
            //            int z = x / y; //It will throw an Exception
            //            Console.WriteLine("Child Task Completed");
            //        });
            //        Console.WriteLine("Outer Task Completed");
            //    });

            //    //Waiting for the Parent Task to completed.
            //    parentTask.Wait();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Exception Occurred: {ex.Message}");
            //}
            //Console.WriteLine("Main Method Completed");
            //Console.ReadKey();
            //#endregion

            #region Exception in attached child
            Console.WriteLine("Main Method Started");

            try
            {
                //Creating the Parent Task using Task.Run Method
                var parentTask = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Outer Task Started");
                    //Creating the Child Task with AttachedToParent
                    var childTask = Task.Factory.StartNew(() =>
                    {
                        Console.WriteLine("Child Task Started");
                        int x = 10, y = 0;
                        int z = x / y; //It will throw an Exception
                        Console.WriteLine("Child Task Completed");
                    }, TaskCreationOptions.AttachedToParent);
                    Console.WriteLine("Outer Task Completed");
                });

                //Waiting for the Parent Task to completed.
                parentTask.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }

            Console.WriteLine("Main Method Completed");
            Console.ReadKey();
            #endregion
        }
    }
}
