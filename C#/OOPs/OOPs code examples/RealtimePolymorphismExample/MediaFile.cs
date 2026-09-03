namespace RealtimePolymorphismExample
{
    // Base class
    internal abstract class MediaFile
    {
        public string FileName { get; set; }
        public MediaFile(string fileName)
        {
            FileName = fileName;
        }
        public abstract void Play();
    }
}
