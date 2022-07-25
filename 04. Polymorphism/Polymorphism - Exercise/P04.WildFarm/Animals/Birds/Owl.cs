using P04.WildFarm.Foods;
using System;
using System.Collections.Generic;

namespace P04.WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        private const double OwlWeightMultiplier = 0.25;

        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        protected override IReadOnlyCollection<Type> PreferedFoods
            => new List<Type> { typeof(Meat) }.AsReadOnly();

        protected override double WeightMultiplier 
            => OwlWeightMultiplier;

        public override string ProduceSound()
        {
            return $"Hoot Hoot";
        }
    }
}
