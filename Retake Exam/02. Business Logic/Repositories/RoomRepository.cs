using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

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
            all.Add(model);
        }

        public IReadOnlyCollection<IRoom> All() => all;

        public IRoom Select(string criteria)
        {
            return all.FirstOrDefault(x => x.GetType().Name == criteria);
        }

    }
}
