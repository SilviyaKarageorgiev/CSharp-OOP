using System;

namespace P01.SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double number = double.Parse(Console.ReadLine());

                if (number < 0)
                {
                    throw new ArgumentException("Invalid number.");
                }

                Console.WriteLine(CalculateSquareRoot(number));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
            
        }

        private static double CalculateSquareRoot(double number)
        {
            return Math.Sqrt(number);
        }
    }
}
