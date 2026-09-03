// See https://aka.ms/new-console-template for more information
using FactoryDesignPattern;

ShapeFcatory shapeFactory = new ShapeFcatory();
// Get an object of Circle and call its draw method.
IShape? shape1 = shapeFactory.getShape("CIRCLE");
shape1?.draw();
// Get an object of Rectangle and call its draw method.
IShape? shape2 = shapeFactory.getShape("RECTANGLE");
shape2?.draw();
// Get an object of Square and call its draw method.
IShape? shape3 = shapeFactory.getShape("SQUARE");
shape3?.draw();  