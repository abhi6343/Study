namespace StaticClass
{
    //internal class Customer
    //{
    //    //public string CustomerCode { get; set; }
    //    //public string CustomerName { get; set; }
    //    //private string MachineName = "";
    //    //private bool IsEmpty(string value)
    //    //{
    //    //    if (value.Length > 0)
    //    //    {
    //    //        return true;
    //    //    }
    //    //    return false;
    //    //}
    //    //public void Insert()
    //    //{
    //    //    if (IsEmpty(CustomerCode) && IsEmpty(CustomerName))
    //    //    {
    //    //        //Insert the data
    //    //    }
    //    //}



    //    public string CustomerCode { get; set; }
    //    public string CustomerName { get; set; }
    //    private string MachineName = "";
    //    public Customer()
    //    {
    //        CommonTask commonTask = new CommonTask();
    //        MachineName = commonTask.GetComputerName();
    //    }
    //    public void Insert()
    //    {
    //        CommonTask commonTask = new CommonTask();
    //        if (!commonTask.IsEmpty(CustomerCode) && !commonTask.IsEmpty(CustomerName))
    //        {
    //            //Insert the data
    //        }
    //    }
    //}



    internal class Customer
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        private string MachineName = "";
        public Customer()
        {
            MachineName = CommonTask.GetComputerName();
        }
        public void Insert()
        {
            if (!CommonTask.IsEmpty(CustomerCode) && !CommonTask.IsEmpty(CustomerName))
            {
                //Insert the data
            }
        }
    }
}
