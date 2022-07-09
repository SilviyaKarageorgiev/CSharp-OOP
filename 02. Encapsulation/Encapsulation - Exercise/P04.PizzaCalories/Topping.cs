using System;

namespace P04.PizzaCalories
{
    public class Topping
    {
        private const double Meat = 1.2;
        private const double Veggies = 0.8;
        private const double Cheese = 1.1;
        private const double Sauce = 0.9;

        private string toppingType;
        private int grams;
        private double calories;


        public Topping(string toppingType, int grams)
        {
            this.ToppingType = toppingType;
            this.Grams = grams;
            this.Calories = calories;
        }


        public string ToppingType
        {
            get
            {
                return this.toppingType;
            }
            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.toppingType = value;
            }
        }


        public int Grams
        {
            get
            {
                return this.grams;
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
                }
                this.grams = value;
            }
        }

        public double Calories
        {
            get
            {
                return this.calories;
            }
            private set
            {
                value = CalculateCalories(this.grams);
                this.calories = value;
            }
        }

        private double CalculateCalories(int grams)
        {

            double calories = grams * 2;

            if (ToppingType.ToLower() == "meat")
            {
                calories *= Meat;
            }
            else if (ToppingType.ToLower() == "veggies")
            {
                calories *= Veggies;
            }
            else if (ToppingType.ToLower() == "cheese")
            {
                calories *= Cheese;
            }
            else if (ToppingType.ToLower() == "sauce")
            {
                calories *= Sauce;
            }

            return calories;
        }
    }
}
