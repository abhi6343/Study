namespace TypesOfInheritance
{
    //Child Class derived from more than one Parent class
    internal class SmartPhone : Phone//, Camera
    {
        public void GetDetails()
        {
            Console.WriteLine("Its a RedMi Smart Phone");
        }
    }
}
