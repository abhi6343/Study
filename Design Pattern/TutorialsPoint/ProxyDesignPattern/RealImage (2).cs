namespace ProxyDesignPattern
{
    public class RealImage : IImage
    {
        private string fileName;
        public RealImage(string fileName)
        {
            this.fileName = fileName;
            loadFromDisk(this.fileName);
        }
        private void loadFromDisk(string fileName)
        {
            Console.WriteLine("Loading " + fileName);
        }
        public void display()
        {
            Console.WriteLine("Displaying " + fileName);
        }
    }
}
