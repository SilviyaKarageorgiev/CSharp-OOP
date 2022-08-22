using BookingApp.Models.Rooms.Contracts;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private int bedCapacity;
        private double pricePerNight;

        public Room(int bedCapacity)
        {

        }

        public int BedCapacity => throw new System.NotImplementedException();

        public double PricePerNight => throw new System.NotImplementedException();

        public void SetPrice(double price)
        {
            throw new System.NotImplementedException();
        }
    }
}
