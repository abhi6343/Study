#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace PrototypeDesignPattern
{
    public abstract class Shape : ICloneable
    {
        private string id;
        protected string type;
        public abstract void draw();
        public string getType() { return type; }
        public string getId() { return id; }
        public void setId(string id) { this.id = id; }  

        public object Clone() 
        {
            object? clone = null;
            try
            {
                clone = MemberwiseClone();
            }
            catch (Exception ex) 
            {
                throw new Exception("Clone exception",ex);
            }
            return clone;
        }
    }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
