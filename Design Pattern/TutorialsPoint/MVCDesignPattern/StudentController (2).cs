namespace MVCDesignPattern
{
    public class StudentController
    {
        private Student model;
        private StudentView view;
        public StudentController(Student model, StudentView view)
        {
            this.model = model;
            this.view = view;
        }
        public void setStudentName(string name)
        {
            model.setName(name);
        }
        public string getStudentName()
        { 
            return model.getName(); 
        }
        public void setStudentRollNo(string rollNo)
        {
            model.setRollNo(rollNo);
        }
        public string getStudentRollNo() 
        { 
            return model.getRollNo(); 
        } 
        public void updateView()
        {
            view.printStudentDetails(model.getName(), model.getRollNo());
        }
    }
}
