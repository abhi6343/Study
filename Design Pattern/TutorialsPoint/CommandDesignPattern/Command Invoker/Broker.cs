namespace CommandDesignPattern
{
    public class Broker_CommandInvoker
    {
        private List<IOrder_Command> orderList = new List<IOrder_Command>();    
        public void takeOrder(IOrder_Command order)
        {
            orderList.Add(order);
        }
        public void placeOrders()
        {
            foreach (IOrder_Command order in orderList)
            {
                order.execute();
            }
            orderList.Clear();
        }
    }
}
