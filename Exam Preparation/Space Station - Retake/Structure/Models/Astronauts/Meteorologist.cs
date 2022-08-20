namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        private const double oxygen = 90;

        public Meteorologist(string name) 
            : base(name, oxygen)
        {
        }
    }
}
