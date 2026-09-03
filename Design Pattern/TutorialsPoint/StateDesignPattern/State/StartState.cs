namespace StateDesignPattern
{
    public class StartState : IState
    {
        public void doAction(Context context)
        {
            Console.WriteLine("Player is in start state");
            context.setState(this);
        }
        public override string ToString()
        {
            return "Start State";
        }
    }
}
