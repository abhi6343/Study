namespace VisitorDesignPattern
{
    public class Computer : IComputerPart
    {
        private IComputerPart[] parts;
        public Computer()
        {
            parts = new IComputerPart[] { new Keyboard(), new Monitor(), new Mouse() };
        }
        public void accept( IComputerPartVisitor computerPartVisitor )
        {
            for( int i = 0; i < parts.Length; i++ )
            {
                parts[ i ].accept( computerPartVisitor );
            }
            computerPartVisitor.visit( this );
        }
    }
}
