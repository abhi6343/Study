namespace RealtimePolymorphismExample
{
    // Derived class: AudioFile
    internal class AudioFile : MediaFile
    {
        public AudioFile(string fileName) : base(fileName) { }
        public override void Play()
        {
            Console.WriteLine($"Playing audio file: {FileName}.");
        }
    }
}
