namespace AnonymousMethods
{
    internal class AnonymousMethods
    {
        //#region Delegates        
        //public delegate string GreetingsDelegate(string name);
        //public static string Greetings(string name)
        //{
        //    return "Hello @" + name + " Welcome to Dotnet Tutorials";
        //}
        //static void Main(string[] args)
        //{
        //    GreetingsDelegate gd = new GreetingsDelegate(AnonymousMethods.Greetings);
        //    string GreetingsMessage = gd.Invoke("Pranaya");
        //    Console.WriteLine(GreetingsMessage);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Anonymous method
        //public delegate string GreetingsDelegate(string name);
        //static void Main(string[] args)
        //{
        //    GreetingsDelegate gd = delegate (string name)
        //    {
        //        return "Hello @" + name + " Welcome to Dotnet Tutorials";
        //    };
        //    string GreetingsMessage = gd.Invoke("Pranaya");
        //    Console.WriteLine(GreetingsMessage);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Anonymous Method Accessing Variables Defined Outside
        //public delegate string GreetingsDelegate(string name);
        //static void Main(string[] args)
        //{
        //    string Message = "Welcome to Dotnet Tutorials";
        //    GreetingsDelegate gd = delegate (string name)
        //    {
        //        return "Hello @" + name + " " + Message;
        //    };
        //    string GreetingsMessage = gd.Invoke("Pranaya");
        //    Console.WriteLine(GreetingsMessage);
        //    Console.ReadKey();
        //}
        //#endregion
    }
}
