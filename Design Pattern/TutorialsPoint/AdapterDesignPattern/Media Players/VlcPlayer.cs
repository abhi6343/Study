namespace AdapterDesignPattern
{
    public class VlcPlayer : IAdvancedMediaPlayer
    {
        public void playMp4(string fileName){ }
        public void playVlc(string fileName)
        {
            Console.WriteLine("Playing mp4 file. Name: " + fileName);
        }
    }
}
