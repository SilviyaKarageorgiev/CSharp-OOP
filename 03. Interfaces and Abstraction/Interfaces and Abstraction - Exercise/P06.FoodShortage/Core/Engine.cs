using P06.FoodShortage.Models;
using P06.FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.FoodShortage.Core
{
    public class Engine : IEngine
    {
        public void Start()
        {
            List<IBuyer> buyers = new List<IBuyer>();
            int food = 0;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input.Length == 3)
                {
                    Rebel rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    buyers.Add(rebel);
                }

                else if (input.Length == 4)
                {
                    Citizen citizen = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                    buyers.Add(citizen);
                }
            }

            string nameOfBuyer;
            while ((nameOfBuyer = Console.ReadLine()) != "End")
            {
                if (buyers.FirstOrDefault(b => b.Name == nameOfBuyer) != null)
                {
                    var buyer = buyers.First(b => b.Name == nameOfBuyer);
                    buyer.BuyFood();
                }
            }

            food = buyers.Sum(b => b.Food);
            Console.WriteLine(food);
        }
    }
}
