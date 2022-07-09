using System.Collections.Generic;
using System;

namespace P04.PizzaCalories
{
    public class Pizza
    {

        private string name;
        private readonly List<Topping> toppings;
        private Dough dough;
        //private double totalCalories;

        public Pizza()
        {
            toppings = new List<Topping>();
        }


        public string Name
        {
            get
            {
                return this.name;
            }
            internal set
            {
                if (value.Length < 1 || value.Length > 15 || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public IReadOnlyCollection<Topping> Toppings
        {
            get
            {
                return this.toppings;
            }
        }

        public Dough Dough
        {
            get
            {
                return this.dough;
            }
            internal set
            {
                this.dough = value;
            }
        }

        //public double TotalCalories
        //{
        //    get
        //    {
        //        return this.totalCalories;
        //    }
        //    internal set
        //    {
        //        value = CalculateTotalCalories(dough, toppings);
        //        this.totalCalories = value;
        //    }
        //}

        private double CalculateTotalCalories(Dough dough, List<Topping> toppings)
        {
            double calories = dough.Calories;

            foreach (var item in toppings)
            {
                calories += item.Calories;
            }

            return calories;
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {CalculateTotalCalories(dough, toppings):f2} Calories.";
        }
    }
}
