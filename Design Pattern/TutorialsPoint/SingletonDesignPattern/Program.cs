// See https://aka.ms/new-console-template for more information

using SingletonDesignPattern;

// Illegal construct
// Compile Time error: The constructor SingletonObject.SingletonObject() is inaccessible due to its protection level
// SingletonObject object1 = new SingletonObject();
SingletonObject object2 = SingletonObject.getInstance();
// Show the message
object2.ShowMessage();