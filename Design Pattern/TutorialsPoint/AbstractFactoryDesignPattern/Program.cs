// See https://aka.ms/new-console-template for more information
using AbstractFactoryDesignPattern;

// Get shape factory
AbstractFactory? shapeFactory = FactoryProducer.getFactory("SHAPE");
// Get an object of IShape Circle
IShape? shape1 = shapeFactory?.getShape("CIRCLE");
// Call draw method of IShape Circle
shape1?.draw();
// Get an object of IShape Rectangle
IShape? shape2 = shapeFactory?.getShape("RECTANGLE");
// Call draw method of IShape Rectangle
shape2?.draw();
// Get an object of IShape Square
IShape? shape3 = shapeFactory?.getShape("SQUARE");
// Call draw method of IShape Square
shape3?.draw();
Console.WriteLine("\n");


// Get color factory
AbstractFactory? colorFactory = FactoryProducer.getFactory("COLOR");
// Get an object of IColor Red
IColor? color1 = colorFactory?.getColor("RED");
// Call fill method of Red
color1?.fill();
// Get an object of IColor Green
IColor? color2 = colorFactory?.getColor("GREEN");
// Call fill method of Green
color2?.fill();
// Get an object of IColor Blue
IColor? color3 = colorFactory?.getColor("BLUE");
// Call fill method of Blue
color3?.fill();
