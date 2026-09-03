namespace RealtimeAbstractionExample
{
    internal abstract class Vehicle
    {
        // These are abstract methods; the derived classes will provide the implementation.
        public abstract void Start();
        public abstract void Stop();
    }
}
