namespace AdapterDesignPattern
{
    public class AudioPlayer : IMediaPlayer
    {
        MediaAdapter mediaAdapter;
        public void play(string audioType, string fileName)
        {
            // Inbuilt support to play mp3 music files
            if (audioType.ToLowerInvariant().Contains("mp3"))
                Console.WriteLine("Playing mp3 file. Name: " + fileName);
            // Media Adapter is providing support to play other file formats
            else if (audioType.ToLowerInvariant().Contains("vlc") || audioType.ToLowerInvariant().Contains("mp4"))
            {
                mediaAdapter = new MediaAdapter(audioType);
                mediaAdapter.play(audioType, fileName);
            }
            else
                Console.WriteLine("Invalid media. " + audioType + " format not supported");
        }
    }
}
