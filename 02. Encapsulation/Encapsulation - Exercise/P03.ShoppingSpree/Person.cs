using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.ShoppingSpree
{
    public class Person
    {

        private string name;
        private decimal money;
        private readonly List<Product> bag;

        public Person()
        {
            bag = new List<Product>();
        }

        public Person(string name, decimal money)
            : this()
        {
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Name cannot be empty");
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Money cannot be negative");
                }
                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag
        {
            get
            {
                return this.bag;
            }
        }

        public void AddProduct(Product product)
        {
            if (this.Money >= product.Cost)
            {
                this.bag.Add(product);
                this.Money -= product.Cost;
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            if (this.Bag.Count == 0)
            {
                return $"{this.Name} - Nothing bought".ToString().TrimEnd();
            }
            else
            {
                return $"{this.Name} - {string.Join(", ", this.Bag.Select(p => p.Name))}".ToString().TrimEnd();
            }
        }
    }
}
