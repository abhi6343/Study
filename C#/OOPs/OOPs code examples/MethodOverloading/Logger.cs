namespace MethodOverloading
{
    internal class Logger
    {
        public static void Log(string ClassName, string MethodName, string Message)
        {
            Console.WriteLine($"DateTime: {DateTime.Now.ToString()}, ClassName: { ClassName}, MethodName: { MethodName}, Message: { Message}");
        }
        public static void Log(string uniqueId, string ClassName, string MethodName, string Message)
        {
            Console.WriteLine($"DateTime: {DateTime.Now.ToString()}, UniqueId: {uniqueId}, ClassName: {ClassName}, MethodName: {MethodName}, Message: {Message}");
        }
        public static void Log(string Message)
        {
            Console.WriteLine($"DateTime: {DateTime.Now.ToString()}, Message: { Message}");
        }
        public static void Log(string ClassName, string MethodName, Exception ex)
        {
            Console.WriteLine($"DateTime: {DateTime.Now.ToString()}, ClassName: { ClassName}, MethodName: { MethodName}, Exception Message:{ ex.Message}, \nExcept StackTrace: { ex.StackTrace}");
        }
        //You create many overloaded versions as per your business requirements
    }
}
