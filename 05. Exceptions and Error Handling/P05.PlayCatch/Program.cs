using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int counterExceptions = 0;
            bool IsThreeExceptions = false;

            while (!IsThreeExceptions)
            {
                string[] cmdArgs = Console.ReadLine().Split();

                string command = cmdArgs[0];

                try
                {
                    if (command == "Replace")
                    {
                        string index = cmdArgs[1];
                        string element = cmdArgs[2];

                        Replace(array, index, element);
                    }
                    else if (command == "Print")
                    {
                        string startIndex = cmdArgs[1];
                        string endIndex = cmdArgs[2];

                        Print(array, startIndex, endIndex);
                    }
                    else if (command == "Show")
                    {
                        string index = cmdArgs[1];

                        Show(array, index);
                    }
                }
                catch (IndexOutOfRangeException ioore)
                {
                    counterExceptions++;
                    Console.WriteLine(ioore.Message);
                }
                catch(FormatException fe)
                {
                    counterExceptions++;
                    Console.WriteLine(fe.Message);
                }
                finally
                {
                    if (counterExceptions == 3)
                    {
                        IsThreeExceptions = true;
                    }
                }
            }

            PrintArray(array);

        }

        private static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }

        private static void Show(int[] array, string index)
        {
            if (!int.TryParse(index, out int resultIndex))
            {
                throw new FormatException("The variable is not in the correct format!");
            }

            if (resultIndex < 0 || resultIndex >= array.Length)
            {
                throw new IndexOutOfRangeException("The index does not exist!");
            }

            Console.WriteLine(array[resultIndex]);
        }

        private static void Print(int[] array, string startIndex, string endIndex)
        {
            ValidateIndeces(array, startIndex, endIndex);

            int start = int.Parse(startIndex);
            int end = int.Parse(endIndex);

            List<int> numbersToPrint = new List<int>();

            for (int i = start; i <= end; i++)
            {
                numbersToPrint.Add(array[i]);
            }

            Console.WriteLine(string.Join(", ", numbersToPrint));

        }

        private static void ValidateIndeces(int[] array, string startIndex, string endIndex)
        {
            if (!int.TryParse(startIndex, out int result) || !int.TryParse(endIndex, out int result2))
            {
                throw new FormatException("The variable is not in the correct format!");
            }
            if (result < 0 || result >= array.Length || result2 < 0 || result2 >= array.Length)
            {
                throw new IndexOutOfRangeException("The index does not exist!");
            }

        }

        private static void Replace(int[] array, string index, string element)
        {
            if (!int.TryParse(index, out int resultIndex) || !int.TryParse(element, out int resultElement))
            {
                throw new FormatException("The variable is not in the correct format!");
            }
            
            if (resultIndex < 0 || resultIndex >= array.Length)
            {
                throw new IndexOutOfRangeException("The index does not exist!");
            }

            array[resultIndex] = resultElement;
        }

    }
}
