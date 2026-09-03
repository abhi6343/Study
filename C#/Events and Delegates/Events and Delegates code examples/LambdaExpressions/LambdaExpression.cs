namespace LambdaExpressions
{
    internal class LambdaExpression
    {
        //#region Delegate
        //public delegate string GreetingsDelegate(string name);
        //static void Main(string[] args)
        //{
        //    GreetingsDelegate obj = delegate (string name)
        //    {
        //        return "Hello @" + name + " welcome to Dotnet Tutorials";
        //    };
        //    string GreetingsMessage = obj.Invoke("Pranaya");
        //    Console.WriteLine(GreetingsMessage);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Anonymous method
        //public delegate string GreetingsDelegate(string name);
        //static void Main(string[] args)
        //{
        //    GreetingsDelegate obj = delegate (string name)
        //    {
        //        return "Hello @" + name + " welcome to Dotnet Tutorials";
        //    };
        //    string GreetingsMessage = obj.Invoke("Pranaya");
        //    Console.WriteLine(GreetingsMessage);
        //    Console.ReadKey();
        //}
        //#endregion


        #region Lambda expressin
        public delegate string GreetingsDelegate(string name);
        static void Main(string[] args)
        {
            GreetingsDelegate obj = (name) =>
            {
                return "Hello @" + name + " welcome to Dotnet Tutorials";
            };
            string GreetingsMessage = obj.Invoke("Pranaya");
            Console.WriteLine(GreetingsMessage);
            Console.ReadKey();
        }
        #endregion
    }
}
