namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double oxygen = 70;

        public Biologist(string name)
            : base(name, oxygen)
        {
        }

        public override void Breath()
        {
            Oxygen -= 5;

            if (Oxygen < 0)
            {
                Oxygen = 0;
            }
        }
    }
}
