namespace VisitorDesignPattern
{
    public interface IComputerPart
    {
        void accept(IComputerPartVisitor computerPartVisitor);
    }
}
