namespace ObserverDesignPattern
{
    public class HexaObserver : Observer
    {
        public HexaObserver( Subject subject )
        {
            this.subject = subject;
            this.subject.attach( this );
        }
        public override void update()
        {
            Console.WriteLine( "Hex String: " + Convert.ToString( subject.getState(), 16 ) );
        }
    }
}
