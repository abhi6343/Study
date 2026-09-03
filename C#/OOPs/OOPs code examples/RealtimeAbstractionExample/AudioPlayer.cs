namespace RealtimeAbstractionExample
{
    //Concrete Implementations
    //Implement the interface for different media types.
    internal class AudioPlayer : IMediaPlayer
    {
        public void Play(string filePath)
        {
            Console.WriteLine($"Playing audio from {filePath}");
            // Logic to play audio files
        }
    }
}
