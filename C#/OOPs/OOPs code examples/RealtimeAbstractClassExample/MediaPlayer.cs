namespace RealtimeAbstractClassExample
{
    //MediaPlayer.cs (Abstract Class)
    internal abstract class MediaPlayer
    {
        public string FileName { get; set; }
        // Abstract methods with no body
        public abstract void Play();
        public abstract void Pause();
        public abstract void Stop();
        // Virtual method with a default implementation
        public virtual void LoadFile(string fileName)
        {
            FileName = fileName;
            Console.WriteLine($"Loaded file: {FileName}");
        }
    }
}
