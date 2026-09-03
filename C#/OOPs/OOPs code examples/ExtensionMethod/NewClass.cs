namespace ExtensionMethod
{
    internal static class NewClass
    {
        public static void Test3(this OldClass O)
        {
            Console.WriteLine("Method Three");
        }
        public static void Test4(this OldClass O, int x)
        {
            Console.WriteLine("Method Four: " + x);
        }
        public static void Test5(this OldClass O)
        {
            Console.WriteLine("Method Five: " + O.x);
        }
    }
}
