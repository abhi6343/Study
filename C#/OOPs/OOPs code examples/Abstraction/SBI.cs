namespace Abstraction
{
    //internal class SBI
    #region Interface
    internal class SBI : IBank
    {
        public override void BankTransfer()
        {
            Console.WriteLine("SBI Bank Bank Transfer");
        }
        public override void CheckBalanace()
        {
            Console.WriteLine("SBI Bank Check Balanace");
        }
        public override void MiniStatement()
        {
            Console.WriteLine("SBI Bank Mini Statement");
        }
        public override void ValidateCard()
        {
            Console.WriteLine("SBI Bank Validate Card");
        }
        public override void WithdrawMoney()
        {
            Console.WriteLine("SBI Bank Withdraw Money");
        }
    }
    #endregion


    //#region Abstract class
    //internal class SBI : IBank
    //{
    //    public override void BankTransfer()
    //    {
    //        Console.WriteLine("SBI Bank Bank Transfer");
    //    }
    //    public override void CheckBalanace()
    //    {
    //        Console.WriteLine("SBI Bank Check Balanace");
    //    }
    //    public override void MiniStatement()
    //    {
    //        Console.WriteLine("SBI Bank Mini Statement");
    //    }
    //    public override void ValidateCard()
    //    {
    //        Console.WriteLine("SBI Bank Validate Card");
    //    }
    //    public override void WithdrawMoney()
    //    {
    //        Console.WriteLine("SBI Bank Withdraw Money");
    //    }
    //}
    //#endregion
}
