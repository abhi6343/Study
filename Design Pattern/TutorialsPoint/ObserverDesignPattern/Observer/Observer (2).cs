#pragma warning disable CS8618

namespace ObserverDesignPattern
{
    public abstract class Observer
    {
        protected Subject subject;
        public abstract void update();
    }
}
#pragma warning restore CS8618