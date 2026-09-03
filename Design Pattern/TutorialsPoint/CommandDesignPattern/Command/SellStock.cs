namespace CommandDesignPattern
{
    public class SellStock_Command : IOrder_Command
    {
        private Stock_Request abcStock;
        public SellStock_Command(Stock_Request abcStock)
        {
            this.abcStock = abcStock;
        }
        public void execute()
        {
            abcStock.sell();
        }
    }
}
