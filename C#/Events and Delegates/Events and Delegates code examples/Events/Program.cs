namespace Events
{
    internal class Program
    {
        //#region Attach events
        //static void Main(string[] args)
        //{
        //    Worker worker = new Worker();
        //    //Attaching Worker_WorkPerformed with WorkPerformed Event
        //    worker.WorkPerformed +=
        //        new EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed);
        //    //Attaching Worker_WorkCompleted with WorkCompleted Event
        //    worker.WorkCompleted +=
        //        new EventHandler(Worker_WorkCompleted);
        //    worker.DoWork(4, WorkType.GenerateReports);
        //    Console.ReadKey();
        //}
        ////Event Handler Method or Event Listener Method
        //static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        //{
        //    Console.WriteLine($"Worker work {e.Hours} Hours compelted for {e.WorkType}");
        //}
        ////Event Handler Method or Event Listener Method
        //static void Worker_WorkCompleted(object sender, EventArgs e)
        //{
        //    Console.WriteLine($"Worker Work Completed");
        //}
        //#endregion


        #region Attach events using anonymous method
        static void Main(string[] args)
        {
            Worker worker = new Worker();
            //Attaching Worker_WorkPerformed with WorkPerformed Event
            worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
            {
                Console.WriteLine($"Worker work {e.Hours} Hours compelted for {e.WorkType}");
            };
            //Attaching Worker_WorkCompleted with WorkCompleted Event
            worker.WorkCompleted += delegate (object sender, EventArgs e)
            {
                Console.WriteLine($"Worker Work Completed");
            };
            worker.DoWork(4, WorkType.GenerateReports);
            Console.ReadKey();
        }
        #endregion
    }
}
