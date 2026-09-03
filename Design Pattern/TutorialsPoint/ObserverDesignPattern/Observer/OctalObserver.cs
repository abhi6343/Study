namespace ObserverDesignPattern
{
    public class OctalObserver : Observer
    {
        public OctalObserver( Subject subject )
        {
            this.subject = subject;
            this.subject.attach( this );
        }
        public override void update()
        {
            Console.WriteLine( "Octal String: " + Convert.ToString( subject.getState(), 8 ) );
        }
    }
}
