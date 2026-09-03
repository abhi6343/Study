namespace CommandDesignPattern
{
    public class BuyStock_Command : IOrder_Command
    {
        private Stock_Request abcStock;
        public BuyStock_Command(Stock_Request abcStock)
        {
            this.abcStock = abcStock;
        }
        public void execute()
        {
            abcStock.buy();
        }
    }
}
