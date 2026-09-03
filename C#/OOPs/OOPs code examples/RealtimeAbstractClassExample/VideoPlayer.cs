namespace RealtimeAbstractClassExample
{
    //VideoPlayer.cs (Concrete Class)
    internal class VideoPlayer : MediaPlayer
    {
        // Concrete implementations of the abstract methods
        public override void Play()
        {
            Console.WriteLine($"Playing video: {FileName}");
        }
        public override void Pause()
        {
            Console.WriteLine($"Pausing video: {FileName}");
        }
        public override void Stop()
        {
            Console.WriteLine($"Stopping video: {FileName}");
        }
    }
}
