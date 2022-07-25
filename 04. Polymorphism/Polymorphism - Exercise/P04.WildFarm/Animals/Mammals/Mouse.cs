﻿using P04.WildFarm.Foods;
using System;
using System.Collections.Generic;

namespace P04.WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double MouseWeightMultiplier = 0.10;

        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        protected override IReadOnlyCollection<Type> PreferedFoods
            => new List<Type> { typeof(Fruit), typeof(Vegetable) }.AsReadOnly();

        protected override double WeightMultiplier
            => MouseWeightMultiplier;

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
