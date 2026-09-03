namespace InterpreterDesignPattern
{
    public class AndExpression: IExpression
    {
        private IExpression exp1;
        private IExpression exp2;
        public AndExpression(IExpression exp1, IExpression exp2)
        {
            this.exp1 = exp1;
            this.exp2 = exp2;
        }

        public bool interpret(string context)
        {
            return exp1.interpret(context) && exp2.interpret(context);
        }
    }
}
