using System;

namespace _03_english_name_of_the_last_digit
{
    class EnglishNameOfLastDigit
    {
        static void Main()
        {
            var numberString = Console.ReadLine();

            var lastDigit = int.Parse(numberString[numberString.Length - 1].ToString());
            var digitInEnglish = GetDigitInEnglish(lastDigit);

            Console.WriteLine(digitInEnglish);
        }

        private static string GetDigitInEnglish(int digit)
        {
            var digitNames = new string[]
            {
                "zero",
                "one",
                "two",
                "three",
                "four",
                "five",
                "six",
                "seven",
                "eight",
                "nine"
            };

            return digitNames[digit];
        }
    }
}
