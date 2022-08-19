namespace Gym.Models.Gyms
{
    public class BoxingGym : Gym
    {
        private const int capacity = 15;

        public BoxingGym(string name)
            : base(name, capacity)
        {
        }
    }
}
