namespace DesignDBusingCodeFirst.Entities
{
    public class StudentProxy : Student
    {
        private Branch _branch;

        // Overriding the Branch property to implement lazy loading
        public override Branch Branch
        {
            get
            {
                // Check if the related entity (Branch) has been loaded
                if (_branch == null)
                {
                    // If not loaded, issue a query to load the Branch entity from the database
                    //_branch = LoadBranchFromDatabase();
                }

                // Return the Branch entity
                return _branch;
            }
            set
            {
                _branch = value;
            }
        }

        //private Branch LoadBranchFromDatabase()
        //{
        //    // Logic to load the Branch entity from the database
        //    // This part is managed by EF Core and typically involves issuing a SELECT query
        //    return EFCoreLazyLoadHelper.LoadRelatedEntity<Branch>(this.StudentId);
        //}
    }
}
