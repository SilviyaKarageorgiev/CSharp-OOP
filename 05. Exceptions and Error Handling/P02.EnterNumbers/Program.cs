using System;
using System.Collections.Generic;

namespace P02.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;

            List<int> numbers = new List<int>();

            while (numbers.Count < 10)
            {
                try
                {
                    start = ReadNumber(start, end);
                    numbers.Add(start);
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            PrintNumbers(numbers);
        }

        private static void PrintNumbers(List<int> numbers)
        {
            Console.WriteLine(String.Join(", ", numbers));
        }

        public static int ReadNumber(int start, int end)
        {
            var curr = Console.ReadLine();
            if (!int.TryParse(curr, out int result))
            {
                throw new ArgumentException("Invalid Number!");
            }
            else if (int.Parse(curr) <= start || int.Parse(curr) >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - 100!");
            }
            return int.Parse(curr);
        }

    }
}
