namespace AdapterDesignPattern
{
    public class MediaAdapter : IMediaPlayer
    {
        IAdvancedMediaPlayer advancedMusicPlayer;
        public MediaAdapter(string audioType)
        {
            if (audioType.ToLowerInvariant().Contains("vlc"))
                advancedMusicPlayer = new VlcPlayer();
            else if(audioType.ToLowerInvariant().Contains("mp4"))
                advancedMusicPlayer = new Mp4Player();
        }
        public void play(string audioType, string fileName)
        {
            if(audioType.ToLowerInvariant().Contains("vlc"))  
                advancedMusicPlayer.playVlc(fileName);
            else if(audioType.ToLowerInvariant().Contains("mp4"))
                advancedMusicPlayer.playMp4(fileName);
        }
    }
}
