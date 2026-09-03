namespace StateDesignPattern
{
    public class StopState : IState
    {
        public void doAction(Context context)
        {
            Console.WriteLine("Player is in stop state");
            context.setState(this);
        }
        public override string ToString()
        {
            return "Stop State";
        }
    }
}
