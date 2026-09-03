namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //B obj = new B();
            //obj.Method1();
            //obj.Method2();
            //obj.Method3();


            //#region Parent NOT access to child member
            //A obj = new A();
            //obj.Method1();
            //obj.Method2();
            ////The following line of code gives you compile time error
            //obj.Method3();
            //#endregion


            //#region Unassigned local variable
            //A p; //p is a variable of class A
            //p.Method1();
            //p.Method2();
            //#endregion


            //#region Parent reference assign child instance
            //A p; //p is a variable of class A
            //B q = new B(); //q is an instance of Class B 
            ////We can initialize a Parent class variable using child class instance as follows
            //p = q; //now, p is a reference of parent class created by using child class instance
            ////Now you can call members of A class as follows
            //p.Method1();
            //p.Method2();
            ////We cannot call any pure child class members using the reference p
            ////p.Method3();
            //#endregion


            //Object obj = new object();
            //obj.
            //A obj = new A();
            //obj.


            //#region Object base class of all classes
            //Object obj1 = new Object();
            //Console.WriteLine($"obj1 type: {obj1.GetType()}");
            //A obj2 = new A();
            //Console.WriteLine($"obj2 type: {obj2.GetType()}");
            //B obj3 = new B();
            //Console.WriteLine($"obj3 type: {obj3.GetType()}");
            //Console.ReadKey();
            //#endregion


            #region Parent having explicit constructor
            B obj = new B();

            B obj1 = new B(10);
            B obj2 = new B(20);
            B obj3 = new B(30);
            #endregion

            Console.ReadKey();
        }
    }
}
