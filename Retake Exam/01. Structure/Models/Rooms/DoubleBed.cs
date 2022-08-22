namespace BookingApp.Models.Rooms
{
    public class DoubleBed : Room
    {
        private const int bedCapacity = 2;

        public DoubleBed()
            : base(bedCapacity)
        {
        }
    }
}
