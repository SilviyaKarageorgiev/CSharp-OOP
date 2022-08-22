using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels;
        private BookingRepository bookings;

        public Controller()
        {
            hotels = new HotelRepository();
            bookings = new BookingRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = hotels.Select(hotelName);

            if (hotel != null)
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            hotel = new Hotel(hotelName, category);
            hotels.AddNew(hotel);

            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = hotels.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (hotel.Rooms.Select(roomTypeName) != null)
            {
                return OutputMessages.RoomTypeAlreadyCreated;
            }

            IRoom room = null;

            if (roomTypeName == nameof(DoubleBed))
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == nameof(Studio))
            {
                room = new Studio();
            }
            else if (roomTypeName == nameof(Apartment))
            {
                room = new Apartment();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            hotel.Rooms.AddNew(room);

            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = hotels.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (roomTypeName != nameof(DoubleBed) && roomTypeName != nameof(Studio) && roomTypeName != nameof(Apartment))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            if (hotel.Rooms.Select(roomTypeName) == null)
            {
                return OutputMessages.RoomTypeNotCreated;
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);

            if (room.PricePerNight != 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }

            room.SetPrice(price);

            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {

            //var hotelsWithWantedCategory = hotels.All().Where(x => x.Category == category);

            //if (hotelsWithWantedCategory.Count() == 0)
            //{
            //    return string.Format(OutputMessages.CategoryInvalid, category);
            //}

            //var orderedHotels = hotels.All().OrderBy(x => x.FullName)
            //    .ThenBy(x => x.Category == category);

            //Dictionary<string, List<IRoom>> roomsTake = null;

            //foreach (var hotel in hotels.All())
            //{
            //    roomsTake.Add(hotel.FullName, new List<IRoom>());

            //    foreach (var room in hotel.Rooms.All())
            //    {
            //        if (room.PricePerNight > 0)
            //        {
            //            roomsTake[hotel.FullName].Add(room);

            //        }
            //    }
            //}

            //roomsTake.

            //var orderedRooms = roomsTake.OrderBy(x => x.BedCapacity);
            //IRoom wantedRoom = null;
            //string nameOfHotel = string.Empty;

            //foreach (var room in orderedRooms)
            //{
            //    if (room.BedCapacity >= adults + children)
            //    {
            //        wantedRoom = room;
            //    }
            //}

            //if (wantedRoom == null)
            //{
            //    return OutputMessages.RoomNotAppropriate;
            //}

            //IBooking booking = new Booking(wantedRoom, duration, adults, children, );

            var orderedHotels = this.hotels.All()
                .OrderBy(x => x.FullName);

            if (orderedHotels.FirstOrDefault(h => h.Category == category) == null)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            List<IRoom> listOfAllRooms = new List<IRoom>();

            foreach (var hotel in orderedHotels)
            {
                listOfAllRooms.AddRange(hotel.Rooms.All().Where(x => x.PricePerNight > 0));
            }

            var orderedRooms = listOfAllRooms.OrderBy(r => r.BedCapacity).ToList();
            IRoom roomExists = orderedRooms.FirstOrDefault(r => r.BedCapacity >= adults + children);
            if (roomExists == null)
            {
                return OutputMessages.RoomNotAppropriate;
            }

            IHotel targetHotel = null;
            foreach (var hotel in orderedHotels)
            {
                if (hotel.Rooms.Select(roomExists.GetType().Name) != null)
                {
                    targetHotel = hotel;
                    break;
                }
            }

            int bookingNumber = targetHotel.Bookings.All().Count + 1;

            IBooking booking = new Booking(roomExists, duration, adults, children, bookingNumber);
            targetHotel.Bookings.AddNew(booking);

            return string.Format(OutputMessages.BookingSuccessful, bookingNumber, targetHotel.FullName);
        }

        public string HotelReport(string hotelName)
        {
            if (hotels.Select(hotelName) == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            IHotel hotel = hotels.Select(hotelName);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Hotel name: {hotel.FullName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");


            sb.AppendLine("--Bookings:");
            sb.AppendLine();

            if (hotel.Bookings.All().Count() == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                foreach (var booking in hotel.Bookings.All())
                {
                    sb.AppendLine(booking.BookingSummary());
                    sb.AppendLine();
                }
            }

            return sb.ToString().TrimEnd();
        }


    }
}
