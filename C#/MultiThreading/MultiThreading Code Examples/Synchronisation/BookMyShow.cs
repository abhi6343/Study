namespace Synchronisation
{
    internal class BookMyShow
    {
        private int AvailableTickets = 3;
        private static readonly int i = 1, j = 2, k = 3;
        void BookTicket(string name, int wantedtickets)
        {
            if (wantedtickets <= AvailableTickets)
            {
                Console.WriteLine(wantedtickets + " booked to " + name);
                AvailableTickets -= wantedtickets;
            }
            else
            {
                Console.WriteLine("No tickets Available to book");
            }
        }
        public void TicketBookig()
        {
            var name = Thread.CurrentThread.Name;
            if (name.Equals("Thread1"))
            {
                BookTicket(name, i);
            }
            else if (name.Equals("Thread2"))
            {
                BookTicket(name, j);
            }
            else
            {
                BookTicket(name, k);
            }
        }
    }
}
