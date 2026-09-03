namespace LibraryManagementSystem.Entities
{
    internal class Loan(BookCopy copy, Member member)
    {
        readonly DateTime checkoutDate = DateTime.Now;

        public BookCopy Copy => copy;
        public Member Member => member;
    }
}
