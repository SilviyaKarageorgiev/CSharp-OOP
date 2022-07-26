using System;

namespace P04.SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            string[] input = Console.ReadLine().Split();

            for (int i = 0; i < input.Length; i++)
            {
                string currElement = input[i];

                try
                {
                    sum += CheckElementIfItIsInt(currElement);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (OverflowException ofe)
                {
                    Console.WriteLine(ofe.Message);
                }
                finally
                {
                    Console.WriteLine($"Element '{currElement}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");

        }

        private static int CheckElementIfItIsInt(string currElement)
        {
            
            if (!long.TryParse(currElement, out long result))
            {
                throw new FormatException($"The element '{currElement}' is in wrong format!");
            }
            else if (result < int.MinValue || result > int.MaxValue)
            {
                throw new OverflowException($"The element '{currElement}' is out of range!");
            }

            return (int)result;
        }
    }
}
