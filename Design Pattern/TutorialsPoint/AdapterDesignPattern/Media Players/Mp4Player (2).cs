namespace AdapterDesignPattern
{
    public class Mp4Player : IAdvancedMediaPlayer
    {
        public void playVlc(string fileName){ }
        public void playMp4(string fileName)
        {
            Console.WriteLine("Playing vlc file. Name: " + fileName);
        }
    }
}
