namespace MultipleInheritanceRealtimeExample
{
    //internal interface IPrinterTasks
    //{
    //    void Print(string PrintContent);
    //    void Scan(string ScanContent);
    //    void Fax(string FaxContent);
    //    void PrintDuplex(string PrintDuplexContent);
    //}


    #region Multiple Inheritance
    internal interface IPrinterTasks
    {
        void Print(string PrintContent);
        void Scan(string ScanContent);
    }
    #endregion
}
