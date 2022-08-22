using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
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
            all.Add(model);
        }

        public IReadOnlyCollection<IBooking> All() => all;

        public IBooking Select(string criteria)
        {
            return all.FirstOrDefault(x => x.BookingNumber.ToString() == criteria);
        }
    }
}
