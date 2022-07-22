using P04.BorderControl.Models.Interfaces;
using System.Collections.Generic;

namespace P04.BorderControl.Models
{
    public class Detained : IIdentifiable
    {
        List<IIdentifiable> detained;

        public string Id { get; }

        public Detained()
        {
            detained = new List<IIdentifiable>();
        }

    }
}
