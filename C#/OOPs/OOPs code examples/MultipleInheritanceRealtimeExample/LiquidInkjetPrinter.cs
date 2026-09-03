namespace MultipleInheritanceRealtimeExample
{
    //internal class LiquidInkjetPrinter : IPrinterTasks
    //{
    //    public void Print(string PrintContent)
    //    {
    //        Console.WriteLine(PrintContent);
    //    }
    //    public void Scan(string ScanContent)
    //    {
    //        Console.WriteLine(ScanContent);
    //    }
    //    public void Fax(string FaxContent)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public void PrintDuplex(string PrintDuplexContent)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}


    #region Multiple Inheritance
    class LiquidInkjetPrinter : IPrinterTasks
    {
        public void Print(string PrintContent)
        {
            Console.WriteLine(PrintContent);
        }
        public void Scan(string ScanContent)
        {
            Console.WriteLine(ScanContent);
        }
    }
    #endregion
}
