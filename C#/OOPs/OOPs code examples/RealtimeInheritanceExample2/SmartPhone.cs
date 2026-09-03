namespace RealtimeInheritanceExample2
{
    //Derived Class (Child Class) - SmartPhone
    internal class SmartPhone : MobilePhone
    {
        public void BrowseWeb(string website)
        {
            Console.WriteLine($"Browsing {website} on {Brand} smartphone.");
        }
        public void InstallApp(string appName)
        {
            Console.WriteLine($"Installing {appName} on {Brand} smartphone.");
        }
    }
}
