using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private double turnover;
        private IRepository<IRoom> rooms;
        private IRepository<IBooking> bookings;

        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
            rooms = new RoomRepository();
            bookings = new BookingRepository();
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                }

                fullName = value;
            }
        }

        public int Category
        {
            get => category;
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }

                category = value;
            }
        }

        public double Turnover => CalculateTurnover();

        private double CalculateTurnover()
        {
            double sum = 0;

            foreach (var booking in bookings.All())
            {
                sum += booking.ResidenceDuration * booking.Room.PricePerNight;
            }

            return Math.Round(sum, 2);
        }

        public IRepository<IRoom> Rooms
        {
            get => rooms;
            set => rooms = value;
        }
        public IRepository<IBooking> Bookings
        {
            get => bookings;
            set => bookings = value; 
        }
    }
}
