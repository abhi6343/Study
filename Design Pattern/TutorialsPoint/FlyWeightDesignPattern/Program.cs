// See https://aka.ms/new-console-template for more information
using FlyWeightDesignPattern;

string[] colors = new string[] { "Red", "Green", "Blue", "White", "Black" };
for(int i = 0; i < 20; i++)
{
    Circle circle = (Circle)ShapeFactory.getCircle(getRandomColor());
    circle.setX(getRandomX());
    circle.setY(getRandomY());
    circle.setRadius(100);
    circle.draw();
}

int getRandomY()
{
    return (int)(new Random().Next(100));
}

int getRandomX()
{
    return (int)(new Random().Next(100));
}

string getRandomColor()
{
    return colors[(int)(new Random().Next(5))];
}