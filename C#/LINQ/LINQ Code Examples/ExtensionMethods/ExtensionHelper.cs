namespace ExtensionMethods
{
    //#region Not an Extension method
    ////Wrapper class
    //public class ExtensionHelper
    //{
    //    public static int GetWordCount(string str)
    //    {
    //        if (!string.IsNullOrEmpty(str))
    //            return str.Split(' ').Length;
    //        return 0;
    //    }
    //}
    ////int wordCount = sentence.GetWordCount(); --------->>>>> Not possible here
    ////int wordCount = ExtensionHelper.GetWordCount(sentence); ----------->>> This only possible
    //#endregion


    #region Extension method
    //To make the above GetWordCount() method an extension method, we need to make the following changes.
    //1. First, we need to make the ExtensionHelper class a static class.
    //2. Second, the type this method(i.e.,GetWordCount()) extends(i.e., string) should be passed as the 
    //first parameter preceding the “this” keyword to the GetWordCount() method
    public static class ExtensionHelper
    {
        public static int GetWordCount(this string str)
        {
            if (!string.IsNullOrEmpty(str))
                return str.Split(' ').Length;
            return 0;
        }
    }
    #endregion
}
