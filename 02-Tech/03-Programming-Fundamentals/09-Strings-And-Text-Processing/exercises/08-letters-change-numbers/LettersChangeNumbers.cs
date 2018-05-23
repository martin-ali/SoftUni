using System;

namespace _08_letters_change_numbers
{
    class LettersChangeNumbers
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var result = 0.0;

            foreach (var item in input)
            {
                result += ProcessString(item);
            }

            Console.WriteLine($"{result:0.00}");
        }

        private static double ProcessString(string input)
        {
            var firstLetter = input[0];
            var lastLetter = input[input.Length - 1];
            var number = double.Parse(input.Substring(1, input.Length - 2));

            var result = number;
            var firstLetterPosition = Char.ToLower(firstLetter) - 96;
            var lastLetterPosition = Char.ToLower(lastLetter) - 96;
            if (Char.IsUpper(firstLetter))
            {
                result /= firstLetterPosition;
            }
            else
            {
                result *= firstLetterPosition;
            }

            if (Char.IsUpper(lastLetter))
            {
                result -= lastLetterPosition;
            }
            else
            {
                result += lastLetterPosition;
            }

            return result;
        }
    }
}
