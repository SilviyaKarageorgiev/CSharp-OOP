using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private int bedCapacity;
        private double pricePerNight = 0;

        public Room(int bedCapacity)
        {
            BedCapacity = bedCapacity;
        }

        public int BedCapacity
        {
            get => bedCapacity;
            protected set
            {
                bedCapacity = value;
            }
        }

        public double PricePerNight
        {
            get => pricePerNight;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }

                pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            this.PricePerNight = price;
        }
    }
}
