// See https://aka.ms/new-console-template for more information
using DecoratorDesignPattern;

IShape circle = new Circle();
IShape redCircle = new RedShapeDecorator(new Circle());
IShape redRectangle = new RedShapeDecorator(new Rectangle());
Console.WriteLine("Circle with normal border");
circle.draw();
Console.WriteLine("\nCircle with red border");
redCircle.draw();
Console.WriteLine("\nRectangle of red border");
redRectangle.draw();