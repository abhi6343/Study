namespace StrategyDesignPattern
{
    public class OperationSubtract : IStrategy
    {
        public int doOperation(int num1, int num2)
        {
            return num1 - num2;
        }
    }
}
