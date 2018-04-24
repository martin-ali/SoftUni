using System;

namespace _13_game_of_numbers
{
    class GameOfNumbers
    {
        static void Main()
        {
            short n = short.Parse(Console.ReadLine());
            short m = short.Parse(Console.ReadLine());
            short magicNumber = short.Parse(Console.ReadLine());

            var firstNumber = 0;
            var secondNumber = 0;

            var combinationIsFound = false;
            var numberOfCombinations = 0;

            for (int i = n; i <= m; i++)
            {
                for (int j = n; j <= m; j++)
                {
                    if (i + j == magicNumber)
                    {
                        combinationIsFound = true;
                        firstNumber = i;
                        secondNumber = j;
                    }

                    numberOfCombinations++;
                }
            }

            if (combinationIsFound)
            {
                Console.WriteLine($"Number found! {firstNumber} + {secondNumber} = {magicNumber}");
            }
            else
            {
                Console.WriteLine($"{numberOfCombinations} combinations - neither equals {magicNumber}");
            }
        }
    }
}
