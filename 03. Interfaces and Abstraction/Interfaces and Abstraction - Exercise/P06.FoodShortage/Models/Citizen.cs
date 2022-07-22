using P06.FoodShortage.Models.Interfaces;

namespace P06.FoodShortage.Models
{
    public class Citizen : IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; set; }

        public string Birthdate { get; set; }

        public int Food { get; private set; } = 0;

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
