#pragma warning disable CS8603
namespace IteratorDesignPattern
{
    public class NameRepository : IContainer
    {
        public static string[] names = { "Robert", "John", "Julie", "Lora" };
        public IIterator getIterator()
        {
            return new NameIterator();
        }
        
        private class NameIterator : IIterator
        {
            int index = 0;
            public bool hasNext()
            {
                if (index < names.Length)
                {
                    return true;
                }
                return false;
            }

            public object next()
            {
                if(this.hasNext())
                {
                    return names[index++];
                }
                return null;
            }
        } 
    }
}
#pragma warning restore CS8603