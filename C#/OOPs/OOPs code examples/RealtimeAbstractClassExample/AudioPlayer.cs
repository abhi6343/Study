namespace RealtimeAbstractClassExample
{
    //AudioPlayer.cs (Concrete Class)
    internal class AudioPlayer : MediaPlayer
    {
        // Concrete implementations of the abstract methods
        public override void Play()
        {
            Console.WriteLine($"Playing audio: {FileName}");
        }
        public override void Pause()
        {
            Console.WriteLine($"Pausing audio: {FileName}");
        }
        public override void Stop()
        {
            Console.WriteLine($"Stopping audio: {FileName}");
        }
    }
}
