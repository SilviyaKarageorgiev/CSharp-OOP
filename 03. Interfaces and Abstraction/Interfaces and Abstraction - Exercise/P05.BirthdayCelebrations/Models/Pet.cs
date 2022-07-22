using Microsoft.VisualBasic;
using P05.BirthdayCelebrations.Models.Interfaces;

namespace P05.BirthdayCelebrations.Models
{
    public class Pet : IBirthable
    {

        private string name;
        private string birthdate;

        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public string Birthdate { get; private set; }
    }
}
