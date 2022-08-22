using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System.Collections.Generic;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> all;

        public RoomRepository()
        {
            all = new List<IRoom>();
        }

        public void AddNew(IRoom model)
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyCollection<IRoom> All()
        {
            throw new System.NotImplementedException();
        }

        public IRoom Select(string criteria)
        {
            throw new System.NotImplementedException();
        }
    }
}
