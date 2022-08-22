using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

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
            all.Add(model);
        }

        public IReadOnlyCollection<IHotel> All() => all;

        public IHotel Select(string criteria)
        {
            return all.FirstOrDefault(x => x.FullName == criteria);
        }
    }
}
