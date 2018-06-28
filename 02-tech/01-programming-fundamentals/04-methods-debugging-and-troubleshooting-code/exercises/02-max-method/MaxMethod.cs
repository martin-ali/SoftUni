using System;

namespace _02_max_method
{
    class MaxMethod
    {
        static void Main()
        {
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());
            var thirdNumber = int.Parse(Console.ReadLine());

            var biggestOfFirstTwo = GetMax(firstNumber, secondNumber);
            var max = GetMax(biggestOfFirstTwo, thirdNumber);

            Console.WriteLine(max);
        }

        private static int GetMax(int firstNumber, int secondNumber)
        {
            return firstNumber > secondNumber ? firstNumber : secondNumber;
        }
    }
}
