namespace Abstraction
{
    internal class BankFactory
    {
        public static IBank GetBankObject(string bankType)
        {
            IBank BankObject = null;
            if (bankType == "SBI")
            {
                BankObject = new SBI();
            }
            else if (bankType == "AXIS")
            {
                BankObject = new AXIS();
            }
            return BankObject;
        }
    }
}
