using System;
using System.Data;

namespace P04.PizzaCalories
{
    public class Dough
    {
        private const double White = 1.5;
        private const double Wholegrain = 1.0;
        private const double Crispy = 0.9;
        private const double Chewy = 1.1;
        private const double Homemade = 1.0;

        private string flourType;
        private string bakingTechnique;
        private int grams;
        private double calories;

        public Dough(string flourType, string bakingTechnique, int grams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
            this.Calories = calories;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
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
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
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

            if (FlourType.ToLower() == "white")
            {
                calories *= White;
            }
            else if (FlourType.ToLower() == "wholegrain")
            {
                calories *= Wholegrain;
            }

            if (BakingTechnique.ToLower() == "crispy")
            {
                calories *= Crispy;
            }
            else if (BakingTechnique.ToLower() == "chewy")
            {
                calories *= Chewy;
            }
            else if (BakingTechnique.ToLower() == "homemade")
            {
                calories *= Homemade;
            }

            return calories;
        }
    }
}
