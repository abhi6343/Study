// See https://aka.ms/new-console-template for more information
using ProxyDesignPattern;

IImage image = new ProxyImage("test_10mb.jpg");
// Image will be loaded from disk
image.display();
Console.WriteLine("");
// Image will not be loaded from disk
image.display();