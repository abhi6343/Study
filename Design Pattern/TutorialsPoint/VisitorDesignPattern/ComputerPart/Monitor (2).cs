namespace VisitorDesignPattern
{
    public class Monitor : IComputerPart
    {
        public void accept(IComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.visit(this);
        }
    }
}
