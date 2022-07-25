using P04.WildFarm.Exceptions;
using P04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.WildFarm.Animals
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        protected abstract IReadOnlyCollection<Type> PreferedFoods { get; }

        protected abstract double WeightMultiplier { get; }

        public abstract string ProduceSound();

        public virtual void Eat(Food food)
        {
            if (!this.PreferedFoods.Contains(food.GetType()))
            {
                throw new FoodNotPreferredException(string.Format(ExceptionMessages.FoodNotPreferred, this.GetType().Name, food.GetType().Name));
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightMultiplier;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
