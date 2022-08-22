using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> all;

        public BookingRepository()
        {
            all = new List<IBooking>();
        }

        public void AddNew(IBooking model)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<IBooking> All()
        {
            throw new NotImplementedException();
        }

        public IBooking Select(string criteria)
        {
            throw new NotImplementedException();
        }
    }
}
