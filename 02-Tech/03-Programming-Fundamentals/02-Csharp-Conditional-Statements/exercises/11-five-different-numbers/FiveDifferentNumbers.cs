using System;

namespace _11_five_different_numbers
{
    class FiveDifferentNumbers
    {
        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            var numbersFound = false;

            for (int a = firstNumber; a <= secondNumber; a++)
            {
                for (int b = firstNumber; b <= secondNumber; b++)
                {
                    for (int c = firstNumber; c <= secondNumber; c++)
                    {
                        for (int d = firstNumber; d <= secondNumber; d++)
                        {
                            for (int e = firstNumber; e <= secondNumber; e++)
                            {
                                if (firstNumber <= a
                                    && a < b
                                    && b < c
                                    && c < d
                                    && d < e
                                    && e <= secondNumber)
                                {
                                    Console.WriteLine($"{a} {b} {c} {d} {e}");
                                    numbersFound = true;
                                }
                            }
                        }
                    }
                }
            }

            if (numbersFound == false)
            {
                Console.WriteLine("No");
            }
        }
    }
}
