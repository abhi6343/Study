namespace DecoratorDesignPattern
{
    public abstract class ShapeDecorator : IShape
    {
        protected IShape decoratedShape;
        public ShapeDecorator(IShape decoratedShape)
        {
            this.decoratedShape = decoratedShape;
        }
        public virtual void draw()
        {
            decoratedShape.draw();
        }
    }
}
