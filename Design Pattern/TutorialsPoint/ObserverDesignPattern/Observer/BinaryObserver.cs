namespace ObserverDesignPattern
{
    public class BinaryObserver : Observer
    {
        public BinaryObserver( Subject subject ) 
        {
            this.subject = subject;
            this.subject.attach( this );
        }
        public override void update()
        {
            Console.WriteLine( "Binary String: " + Convert.ToString( subject.getState(), 2 ) );
        }
    }
}
