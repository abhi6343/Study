using LibraryManagementSystem.Entities;

namespace LibraryManagementSystem.Singletons
{
    internal class TransactionService
    {
        static readonly TransactionService instance = new();
        readonly Dictionary<string, Loan> activeLoans = [];

        private TransactionService() { }
        public static TransactionService Instance => instance;

        public void CreateLoan(BookCopy copy, Member member)
        {
            if (activeLoans.ContainsKey(copy.Id))
            {
                throw new InvalidOperationException("This copy is already on loan.");
            }

            var loan = new Loan(copy, member);
            activeLoans[copy.Id] = loan;
            member.AddLoan(loan);
        }

        public void EndLoan(BookCopy copy)
        {
            if (activeLoans.TryGetValue(copy.Id, out var loan))
            {
                activeLoans.Remove(copy.Id);
                loan.Member.RemoveLoan(loan);
            }
        }
    }
}
