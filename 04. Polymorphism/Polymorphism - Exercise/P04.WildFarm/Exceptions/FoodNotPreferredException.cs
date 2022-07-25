using System;

namespace P04.WildFarm.Exceptions
{
    public class FoodNotPreferredException : Exception
    {
        public FoodNotPreferredException(string message)
            : base(message)
        {

        }
    }
}
