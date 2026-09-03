namespace Encapsulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Bank bank = new Bank();
            //bank.AccountNumber = 12345678;
            //bank.Name = "Pranata";
            //bank.GetBalance();
            //bank.WithdrawAmount();

            //#region Encapsulation
            //Bank bank = new Bank();
            ////You cannot access the Private Variable
            ////bank.balance; //Compile Time Error
            ////You can access the private variable via public setter and getter
            //bank.SetBalance(500);
            //Console.WriteLine(bank.GetBalance());
            //#endregion


            //Bank bank = new Bank();
            ////We can access the Amount Variable directly
            ////Setting positive amount
            //bank.Amount = 50;
            //Console.WriteLine(bank.Amount);
            ////Setting negative amount
            //bank.Amount = -150;
            //Console.WriteLine(bank.Amount);


            //#region Data Validation
            //try
            //{
            //    Bank bank = new Bank();
            //    //We cannot access the Amount Variable directly
            //    //bank.Amount = 50; //Compile Time Error
            //    //Console.WriteLine(bank.Amount); //Compile Time Error
            //    //Setting Positive Value
            //    bank.SetAmount(10);
            //    Console.WriteLine(bank.GetAmount());
            //    //Setting Negative Value
            //    bank.SetAmount(-150);
            //    Console.WriteLine(bank.GetAmount());
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //#endregion


            #region Properties
            try
            {
                Bank bank = new Bank();
                //We cannot access the _Amount Variable directly
                //bank._Amount = 50; //Compile Time Error
                //Console.WriteLine(bank._Amount); //Compile Time Error
                //Setting Positive Value using public Amount Property
                bank.Amount = 10;
                //Setting the Value using public Amount Property
                Console.WriteLine(bank.Amount);
                //Setting Negative Value
                bank.Amount = -150;
                Console.WriteLine(bank.Amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion


            Console.ReadKey();
        }
    }
}
