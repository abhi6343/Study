namespace DecoratorDesignPattern
{
    public class RedShapeDecorator: ShapeDecorator
    {
        public RedShapeDecorator(IShape decoratedShape): base(decoratedShape) { }
        public override void draw()
        {
            decoratedShape.draw();
            setRedBorder(decoratedShape);
        }
        private void setRedBorder(IShape decoratedShape)
        {
            Console.WriteLine("Border Color: Red");
        }
    }
}
