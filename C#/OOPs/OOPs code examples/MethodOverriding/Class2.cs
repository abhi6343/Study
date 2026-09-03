namespace MethodOverriding
{
    internal class Class2 : Class1
    {
        ////Overriding Method
        //public override void Show()
        //{
        //    //Child Class Reimplementing the Logic
        //    Console.WriteLine("Child Class Show Method");
        //}


        //#region Parent method call from child class
        ////Overriding Method
        //public override void Show()
        //{
        //    base.Show(); //Calling Parent Class Show method
        //    Console.WriteLine("Child Class Show Method");
        //}
        //#endregion


        #region Calling Parent Class Methods by creating the Parent Class Object under the Child Class
        public override void Show()
        {
            //Creating an instance of Parent Class
            Class1 class1 = new Class1();
            //Calling Parent Class Show method
            class1.Show();
            Console.WriteLine("Child Class Show Method");
        }
        #endregion
    }
}
