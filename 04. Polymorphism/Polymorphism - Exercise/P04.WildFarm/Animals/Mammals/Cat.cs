using P04.WildFarm.Foods;
using System;
using System.Collections.Generic;

namespace P04.WildFarm.Animals.Mammals
{
    public class Cat : Feline
    {
        private const double CatWeightMultiplier = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override IReadOnlyCollection<Type> PreferedFoods
            => new List<Type> { typeof(Vegetable), typeof(Meat) }.AsReadOnly();

        protected override double WeightMultiplier
            => CatWeightMultiplier;

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
