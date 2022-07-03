namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string animalType;
            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    string[] animalInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string name = animalInfo[0];
                    int age = int.Parse(animalInfo[1]);

                    Animal animal = null;

                    if (animalType == "Dog")
                    {
                        string gender = animalInfo[2];
                        animal = new Dog(name, age, gender);
                    }
                    else if (animalType == "Frog")
                    {
                        string gender = animalInfo[2];
                        animal = new Frog(name, age, gender);
                    }
                    else if (animalType == "Cat")
                    {
                        string gender = animalInfo[2];
                        animal = new Cat(name, age, gender);
                    }
                    else if (animalType == "Kitten")
                    {
                        animal = new Kitten(name, age);
                    }
                    else if (animalType == "Tomcat")
                    {
                        animal = new Tomcat(name, age);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid input!");
                    }

                    animals.Add(animal);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            foreach (Animal an in animals)
            {
                Console.WriteLine(an.ToString());
            }
        }
    }
}
