namespace Encapsulation
{
    //internal class Bank
    //{
    //    public long AccountNumber;
    //    public string Name;
    //    public int Balance;
    //    public void GetBalance()
    //    {
    //    }
    //    public void WithdrawAmount()
    //    {
    //    }
    //    public void Deposit()
    //    {
    //    }
    //}



    //#region Emcapsulation
    //public class Bank
    //{
    //    //Hiding class data by declaring the variable as private
    //    private double balance;
    //    //Creating public Setter and Getter methods

    //    //Public Getter Method
    //    //This method is used to return the data stored in the balance variabl
    //    public double GetBalance()
    //    {
    //        //add validation logic if needed
    //        return balance;
    //    }

    //    //Public Setter Method
    //    //This method is used to stored the data in the balance variable
    //    public void SetBalance(double balance)
    //    {
    //        // add validation logic to check whether data is correct or not
    //        this.balance = balance;
    //    }
    //}
    //#endregion


    //public class Bank
    //{
    //    public int Amount;
    //}


    //#region Data validation
    //public class Bank
    //{
    //    private int Amount;
    //    public int GetAmount()
    //    {
    //        return Amount;
    //    }
    //    public void SetAmount(int Amount)
    //    {
    //        if (Amount > 0)
    //        {
    //            this.Amount = Amount;
    //        }
    //        else
    //        {
    //            throw new Exception("Please Pass a Positive Value");
    //        }
    //    }
    //}
    //#endregion


    #region Properties
    public class Bank
    {
        private double _Amount;
        public double Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                // Validate the value before storing it in the _Amount variabl
                if (value < 0)
                {
                    throw new Exception("Please Pass a Positive Value");
                }
                else
                {
                    _Amount = value;
                }
            }
        }
    }
    #endregion
}
