namespace StaticClass
{
    //internal class CommonTask
    //{
    //    public bool IsEmpty(string value)
    //    {
    //        if (value.Length > 0)
    //        {
    //            return true;
    //        }
    //        return false;
    //    }
    //    public string GetComputerName()
    //    {
    //        return System.Environment.MachineName;
    //    }
    //}



    internal static class CommonTask
    {
        public static bool IsEmpty(string value)
        {
            if (value.Length > 0)
            {
                return true;
            }
            return false;
        }
        public static string GetComputerName()
        {
            return System.Environment.MachineName;
        }
    }
}
