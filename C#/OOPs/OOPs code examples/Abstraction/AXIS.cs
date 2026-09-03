namespace Abstraction
{
    //internal class AXIS
    //#region Interface
    //internal class AXIS : IBank
    //{
    //    public void BankTransfer()
    //    {
    //        Console.WriteLine("AXIS Bank Bank Transfer");
    //    }
    //    public void CheckBalanace()
    //    {
    //        Console.WriteLine("AXIS Bank Check Balanace");
    //    }
    //    public void MiniStatement()
    //    {
    //        Console.WriteLine("AXIS Bank Mini Statement");
    //    }
    //    public void ValidateCard()
    //    {
    //        Console.WriteLine("AXIS Bank Validate Card");
    //    }
    //    public void WithdrawMoney()
    //    {
    //        Console.WriteLine("AXIS Bank Withdraw Money");
    //    }
    //}
    //#endregion


    #region Abstract class
    internal class AXIS : IBank
    {
        public override void BankTransfer()
        {
            Console.WriteLine("AXIX Bank Bank Transfer");
        }
        public override void CheckBalanace()
        {
            Console.WriteLine("AXIX Bank Check Balanace");
        }
        public override void MiniStatement()
        {
            Console.WriteLine("AXIX Bank Mini Statement");
        }
        public override void ValidateCard()
        {
            Console.WriteLine("AXIX Bank Validate Card");
        }
        public override void WithdrawMoney()
        {
            Console.WriteLine("AXIX Bank Withdraw Money");
        }
    }
    #endregion
}
