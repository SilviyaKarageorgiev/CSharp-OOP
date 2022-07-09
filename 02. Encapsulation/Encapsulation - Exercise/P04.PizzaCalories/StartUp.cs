using System;

namespace P04.PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Pizza pizza = new Pizza();

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (cmdArgs.Length <= 1)
                    {

                        throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");

                    }
                    else if (cmdArgs[0].ToLower() == "pizza")
                    {
                        pizza.Name = cmdArgs[1];
                    }

                    else if (cmdArgs[0].ToLower() == "dough")
                    {
                        Dough dough = new Dough(cmdArgs[1], cmdArgs[2], int.Parse(cmdArgs[3]));
                        pizza.Dough = dough;
                    }

                    else if (cmdArgs[0].ToLower() == "topping")
                    {
                        Topping topping = new Topping(cmdArgs[1], int.Parse(cmdArgs[2]));
                        pizza.AddTopping(topping);
                    }

                }

                Console.WriteLine(pizza);

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

        }
    }
}
