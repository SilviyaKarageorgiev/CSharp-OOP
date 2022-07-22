using Microsoft.VisualBasic;
using P05.BirthdayCelebrations.Models.Interfaces;

namespace P05.BirthdayCelebrations.Models
{
    public class Citizen : IIdentifiable, IBirthable
    {
        private string name;
        private int age;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            Birthdate = birthdate;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Birthdate { get; private set; }

    }
}
