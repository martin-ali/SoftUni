using System;

namespace two_numbers_sum
{
    class Program
    {
        static void Main()
        {
            int intervalStart = int.Parse(Console.ReadLine());
            int intervalEnd = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            // int intervalStart = 10;
            // int intervalEnd = 2;
            // int magicNumber = 2000;

            int maxComboCount = intervalStart - intervalEnd + 1;
            maxComboCount *= maxComboCount;

            int currentCombination = 0;
            bool CombinationIsFound = false;

            for (int i = intervalStart; i >= intervalEnd; i--)
            {
                for (int j = intervalStart; j >= intervalEnd; j--)
                {
                    currentCombination++;
                    if (i + j == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{currentCombination} ({i} + {j} = {magicNumber})");
                        i = intervalEnd - 1; // Break outer loop as well
                        CombinationIsFound = true;
                        break;
                    }
                }
            }

            // This isn't tested against?
            if (CombinationIsFound == false)
            {
                Console.WriteLine($"{maxComboCount} combinations - neither equals {magicNumber}");
            }
        }
    }
}
