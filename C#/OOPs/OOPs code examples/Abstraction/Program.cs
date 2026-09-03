namespace Abstraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Transaction doing SBI Bank");
            //SBI sbi = new SBI();
            //sbi.ValidateCard();
            //sbi.WithdrawMoney();
            //sbi.CheckBalanace();
            //sbi.BankTransfer();
            //sbi.MiniStatement();

            //Console.WriteLine("\nTransaction doing AXIS Bank");
            //AXIS axis = new AXIS();
            //axis.ValidateCard();
            //axis.WithdrawMoney();
            //axis.CheckBalanace();
            //axis.BankTransfer();
            //axis.MiniStatement();


            #region Abstraction using Interface
            Console.WriteLine("Transaction doing SBI Bank");
            IBank sbi = BankFactory.GetBankObject("SBI");
            sbi.ValidateCard();
            sbi.WithdrawMoney();
            sbi.CheckBalanace();
            sbi.BankTransfer();
            sbi.MiniStatement();

            //Console.WriteLine("\nTransaction doing AXIS Bank");
            //IBank axis = BankFactory.GetBankObject("AXIS");
            //axis.ValidateCard();
            //axis.WithdrawMoney();
            //axis.CheckBalanace();
            //axis.BankTransfer();
            //axis.MiniStatement();
            #endregion


            //#region Abstraction using Abstract class and abstract methods
            //Console.WriteLine("Transaction doing SBI Bank");
            //IBank sbi = BankFactory.GetBankObject("SBI");
            //sbi.ValidateCard();
            //sbi.WithdrawMoney();
            //sbi.CheckBalanace();
            //sbi.BankTransfer();
            //sbi.MiniStatement();

            //Console.WriteLine("\nTransaction doing AXIS Bank");
            //IBank axis = BankFactory.GetBankObject("AXIS");
            //axis.ValidateCard();
            //axis.WithdrawMoney();
            //axis.CheckBalanace();
            //axis.BankTransfer();
            //axis.MiniStatement();
            //#endregion


            Console.Read();
        }
    }
}
