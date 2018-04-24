using System;

namespace _05_special_numbers
{
    class SpecialNumbers
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (int current = 1; current <= number; current++)
            {
                var numberIsSpecial = IsSpecial(current);
                Console.WriteLine($"{current} -> {numberIsSpecial}");
            }
        }

        private static bool IsSpecial(int number)
        {
            var result = 0;
            while (number > 0)
            {
                var digit = number % 10;
                result += digit;
                number /= 10;
            }

            var numberIsSpecial = (result == 5 || result == 7 || result == 11);
            return numberIsSpecial;
        }
    }
}
