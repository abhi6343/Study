// See https://aka.ms/new-console-template for more information
#pragma warning disable CS8600, CS8602
using PrototypeDesignPattern;
using System.IO;
using System.Text;

ShapeCache.loadCache();
Shape clonedShape = ShapeCache.GetShape("1");
Console.WriteLine("Shape: "+clonedShape.getType());
Shape clonedShape2 = ShapeCache.GetShape("2") as Shape;
Console.WriteLine("Shape: " + clonedShape2.getType());
Shape clonedShape3 = (Shape)ShapeCache.GetShape("3");
Console.WriteLine("Shape: " + clonedShape3.getType());
#pragma warning restore CS8600, CS8602


//for (int i = 0; i < 100000; i++)
//{
//    string filename = @"d:\temp\" + i + ".txt";
//    using (filestream fs = file.create(filename))
//    {
//        // add some text to file    
//        byte[] title = new utf8encoding(true).getbytes("new text file");
//        fs.write(title, 0, title.length);
//        byte[] author = new utf8encoding(true).getbytes("idrive");
//        fs.write(author, 0, author.length);
//    }
//}
string sourcefilename = @"d:\quelogo.png";
for (int i = 0; i < 100000; i++)
{
    string destinationfilename = @"d:\temp\100k images\" + i + ".png";
    File.Copy(sourcefilename, destinationfilename, true);
}