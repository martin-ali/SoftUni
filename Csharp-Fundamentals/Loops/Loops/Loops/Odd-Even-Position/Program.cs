using System;

namespace Odd_Even_Position
{
    class Program
    {
        static void Main()
        {
            var numberOfInputs = int.Parse(Console.ReadLine());

            var evenNumbersSum = 0d;
            var evenNumbersMax = double.MinValue;
            var evenNumbersMin = double.MaxValue;

            var oddNumbersSum = 0d;
            var oddNumbersMax = double.MinValue;
            var oddNumbersMin = double.MaxValue;

            for (int i = 1; i <= numberOfInputs; i++)
            {
                var current = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenNumbersSum += current;

                    if (current > evenNumbersMax)
                    {
                        evenNumbersMax = current;
                    }

                    if (current < evenNumbersMin)
                    {
                        evenNumbersMin = current;
                    }
                }
                else
                {
                    oddNumbersSum += current;

                    if (current > oddNumbersMax)
                    {
                        oddNumbersMax = current;
                    }

                    if (current < oddNumbersMin)
                    {
                        oddNumbersMin = current;
                    }
                }
            }

            Console.WriteLine($"OddSum={oddNumbersSum}," +
                            $"OddMin={ReturnNoIfEqual(oddNumbersMin, double.MaxValue)}," +
                            $"OddMax={ReturnNoIfEqual(oddNumbersMax, double.MinValue)}," +
                            $"EvenSum={evenNumbersSum}," +
                            $"EvenMin={ReturnNoIfEqual(evenNumbersMin, double.MaxValue)}," +
                            $"EvenMax={ReturnNoIfEqual(evenNumbersMax, double.MinValue)}");
        }

        private static string ReturnNoIfEqual(double value, double comparator)
        {
            return value == comparator ? "No" : value.ToString();
        }
    }
}
