namespace RealtimeInheritanceExample2
{
    //Derived Class (Child Class) - DVD
    internal class DVD : LibraryItem
    {
        public int Runtime { get; set; } // Runtime in minutes
        public DVD(string id, string title, int runtime)
        : base(id, title)
        {
            Runtime = runtime;
        }
        public void DisplayDVDInfo()
        {
            Console.WriteLine($"DVD: '{Title}', Runtime: {Runtime} minutes.");
        }
    }
}
