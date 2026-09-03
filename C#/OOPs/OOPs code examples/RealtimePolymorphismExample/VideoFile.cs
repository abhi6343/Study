namespace RealtimePolymorphismExample
{
    // Derived class: VideoFile
    internal class VideoFile : MediaFile
    {
        public VideoFile(string fileName) : base(fileName) { }
        public override void Play()
        {
            Console.WriteLine($"Playing video file: {FileName}.");
        }
    }
}
