namespace RealtimeAbstractionExample
{
    //Using the Abstraction
    //You can now handle room bookings in a unified manner
    internal class HotelBooking
    {
        public void BookRoom(IRoom room)
        {
            room.DisplayRoomDetails();
            Console.WriteLine("Room booked successfully!\n");
        }
    }
}
