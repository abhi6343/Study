namespace RealtimeAbstractionExample
{
    internal class VideoPlayer : IMediaPlayer
    {
        public void Play(string filePath)
        {
            Console.WriteLine($"Playing video from {filePath}");
            // Logic to play video files
        }
    }
}
