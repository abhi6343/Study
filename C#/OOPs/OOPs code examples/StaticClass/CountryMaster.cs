using System.Diagnostics.Metrics;

namespace StaticClass
{
    //internal class CountryMaster
    //{
    //    //public string CountryCode { get; set; }
    //    //public string CountryName { get; set; }
    //    //private string ComputerName
    //    //{
    //    //    get
    //    //    {
    //    //        return System.Environment.MachineName;
    //    //    }
    //    //}
    //    //public void Insert()
    //    //{
    //    //    //Insert the data
    //    //}




    //    public string CountryCode { get; set; }
    //    public string CountryName { get; set; }
    //    private string ComputerName
    //    {
    //        get
    //        {
    //            CommonTask commonTask = new CommonTask();
    //            return commonTask.GetComputerName();
    //        }
    //    }
    //    public void Insert()
    //    {
    //        CommonTask commonTask = new CommonTask();
    //        if (!commonTask.IsEmpty(CountryCode) && !commonTask.IsEmpty(CountryName))
    //        {
    //            //Insert the data
    //        }
    //    }
    //}



    internal class CountryMaster
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        private string ComputerName
        {
            get
            {
                return CommonTask.GetComputerName();
            }
        }
        public void Insert()
        {
            if (!CommonTask.IsEmpty(CountryCode) && !CommonTask.IsEmpty(CountryName))
            {
                //Insert the data
            }
        }
    }
}
