using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private IRoom room;
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        private int bookingNumber;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {

        }


        public IRoom Room => throw new System.NotImplementedException();

        public int ResidenceDuration => throw new System.NotImplementedException();

        public int AdultsCount => throw new System.NotImplementedException();

        public int ChildrenCount => throw new System.NotImplementedException();

        public int BookingNumber => throw new System.NotImplementedException();

        public string BookingSummary()
        {
            throw new System.NotImplementedException();
        }
    }
}
