using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System.Collections.Generic;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> all;

        public HotelRepository()
        {
            all = new List<IHotel>();
        }

        public void AddNew(IHotel model)
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyCollection<IHotel> All()
        {
            throw new System.NotImplementedException();
        }

        public IHotel Select(string criteria)
        {
            throw new System.NotImplementedException();
        }
    }
}
