namespace Abstraction
{
    //#region Interface
    //internal interface IBank
    //{
    //    void ValidateCard();
    //    void WithdrawMoney();
    //    void CheckBalanace();
    //    void BankTransfer();
    //    void MiniStatement();
    //}
    //#endregion


    #region Abstract class
    internal abstract class IBank
    {
        public abstract void ValidateCard();
        public abstract void WithdrawMoney();
        public abstract void CheckBalanace();
        public abstract void BankTransfer();
        public abstract void MiniStatement();
    }
    #endregion
}
