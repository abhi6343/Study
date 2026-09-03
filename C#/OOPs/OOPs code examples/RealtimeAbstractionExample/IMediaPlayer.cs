namespace RealtimeAbstractionExample
{
    //Abstraction Layer
    //First, define an interface representing any media player.
    internal interface IMediaPlayer
    {
        void Play(string filePath);
    }
}
