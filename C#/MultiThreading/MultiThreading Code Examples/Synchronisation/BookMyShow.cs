namespace Synchronisation
{
    internal class BookMyShow
    {
        int AvailableTickets = 3;
        static int i = 1, j = 2, k = 3;
        public void BookTicket(string name, int wantedtickets)
        {
            if (wantedtickets <= AvailableTickets)
            {
                Console.WriteLine(wantedtickets + " booked to " + name);
                AvailableTickets = AvailableTickets - wantedtickets;
            }
            else
            {
                Console.WriteLine("No tickets Available to book");
            }
        }
        public void TicketBookig()
        {
            string name = Thread.CurrentThread.Name;
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
