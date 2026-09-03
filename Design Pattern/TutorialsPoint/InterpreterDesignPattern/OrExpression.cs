#pragma warning disable CS8625
namespace InterpreterDesignPattern
{
    public class OrExpression: IExpression
    {
        private IExpression exp1 = null;
        private IExpression exp2 = null;
        public OrExpression(IExpression exp1, IExpression exp2) 
        { 
            this.exp1 = exp1;
            this.exp2 = exp2;
        }

        public bool interpret(string context)
        {
            return exp1.interpret(context) || exp2.interpret(context);
        }
    }
}
#pragma warning restore CS8625