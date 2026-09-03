namespace MVCDesignPattern
{
    public class Student
    {
        private string rollNO;
        private string name;

        public string getRollNo()
        { 
            return rollNO; 
        }
        public string getName() 
        { 
            return name;
        }
        public void setRollNo(string rollNO) 
        { 
            this.rollNO = rollNO; 
        }  
        public void setName(string name) 
        { 
            this.name = name;
        }
    }
}
