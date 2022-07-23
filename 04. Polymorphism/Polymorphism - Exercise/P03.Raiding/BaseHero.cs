namespace P03.Raiding
{
    public abstract class BaseHero
    {
        
        public BaseHero(string name)
        {
            this.Name = name;
        }

        public string Name { get; protected set; }
        public virtual int Power { get; protected set; }

        public abstract string CastAbility();

    }
}
