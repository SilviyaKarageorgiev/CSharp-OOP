using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace P03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>();
            var products = new List<Product>();

            try
            {
                string[] inputPeople = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < inputPeople.Length; i++)
                {
                    string[] currPerson = inputPeople[i].Split("=", StringSplitOptions.RemoveEmptyEntries);

                    string name = currPerson[0];
                    decimal money = decimal.Parse(currPerson[1]);

                    Person person = new Person(name, money);
                    persons.Add(person);
                }

                string[] inputProducts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                for (int k = 0; k < inputProducts.Length; k++)
                {
                    string[] currProduct = inputProducts[k].Split("=", StringSplitOptions.RemoveEmptyEntries);

                    string name = currProduct[0];
                    decimal cost = decimal.Parse(currProduct[1]);

                    Product product = new Product(name, cost);
                    products.Add(product);
                }

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string name = command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
                    string itemName = command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];

                    Person currPers;
                    Product currItem;

                    if (persons.Any(p => p.Name == name))
                    {
                        currPers = persons.Find(p => p.Name == name);
                    }
                    else
                    {
                        continue;
                    }

                    if (products.Any(p => p.Name == itemName))
                    {
                        currItem = products.Find(p => p.Name == itemName);
                    }
                    else
                    {
                        continue;
                    }

                    currPers.AddProduct(currItem);
                }

                foreach (var person in persons)
                {
                    Console.WriteLine(person);
                }
            }

            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

        }
    }
}
