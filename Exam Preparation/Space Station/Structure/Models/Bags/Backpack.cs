using SpaceStation.Models.Bags.Contracts;
using System.Collections.Generic;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        private readonly ICollection<IBag> items;

        public Backpack()
        {
            items = new List<IBag>();
        }

        public ICollection<string> Items => throw new System.NotImplementedException();
    }
}
