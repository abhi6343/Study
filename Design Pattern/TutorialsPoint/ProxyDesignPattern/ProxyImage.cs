#pragma warning disable CS8618
namespace ProxyDesignPattern
{
    public class ProxyImage : IImage
    {
        private RealImage realImage;
        private string fileName;
        public ProxyImage(string fileName)
        {
            this.fileName = fileName;
        }
        public void display()
        {
            if(realImage == null)
            {
                realImage = new RealImage(fileName);
            }
            realImage.display();
        }
    }
}
#pragma warning restore CS8618