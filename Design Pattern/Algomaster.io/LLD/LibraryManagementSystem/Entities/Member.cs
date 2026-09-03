namespace LibraryManagementSystem.Entities
{
    internal class Member(string id, string name)
    {
        readonly List<Loan> loans = [];

        public void Update(LibraryItem item)
        {
            Console.WriteLine($"NOTIFICATION for {name}: The book '{item.Title}' you placed a hold on is now available!");
        }

        public void AddLoan(Loan loan) => loans.Add(loan);
        public void RemoveLoan(Loan loan) => loans.Remove(loan);
        public string Id => id;
        public string Name => name;
        public List<Loan> Loans => loans;
    }
}
