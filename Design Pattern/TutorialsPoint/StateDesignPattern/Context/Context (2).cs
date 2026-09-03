#pragma warning disable 
namespace StateDesignPattern
{
    public class Context
    {
        private IState state;
        public Context()
        {
            state = null;
        }
        public void setState(IState state)
        {
            this.state = state;
        }
        public IState getState()
        {
            return state;
        }
    }
}
#pragma warning restore