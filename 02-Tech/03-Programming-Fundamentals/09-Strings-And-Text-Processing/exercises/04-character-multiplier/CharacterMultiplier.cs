using System;
using System.Numerics;

namespace _04_character_multiplier
{
    class CharacterMultiplier
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ');
            var first = input[0];
            var second = input[1];
            var length = Math.Max(first.Length, second.Length);
            BigInteger sum = 0;
            for (int i = 0; i < length; i++)
            {
                var firstNumber = i < first.Length ? first[i] : 1;
                var secondNumber = i < second.Length ? second[i] : 1;

                sum += firstNumber * secondNumber;
            }

            Console.WriteLine(sum);
        }
    }
}
