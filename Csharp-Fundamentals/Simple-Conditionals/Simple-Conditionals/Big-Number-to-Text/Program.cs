using System;
using System.Collections.Generic;

namespace Big_Number_to_Text
{
    class Program
    {
        private static Dictionary<int, string> numberToTextMap = new Dictionary<int, string>()
        {
            [0] = "zero",
            [1] = "one",
            [2] = "two",
            [3] = "three",
            [4] = "four",
            [5] = "five",
            [6] = "six",
            [7] = "seven",
            [8] = "eight",
            [9] = "nine",
            [10] = "ten",
            [11] = "eleven",
            [12] = "twelve",
            [13] = "thirteen",
            [14] = "fourteen",
            [15] = "fifteen",
            [16] = "sixteen",
            [17] = "seventeen",
            [18] = "eighteen",
            [19] = "nineteen",
            [20] = "twenty",
            [30] = "thirty",
            [40] = "forty",
            [50] = "fifty",
            [60] = "sixty",
            [70] = "seventy",
            [80] = "eighty",
            [90] = "ninety",
            [100] = "one hundred"
        };

        static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            if (number == 100 || (number >= 0 && number <= 19) || (number % 10) == 0)
            {
                var result = numberToTextMap[number];
                Console.WriteLine(result);
            }
            else if (number >= 20 && number <= 99)
            {
                int wholePart = number - (number % 10);
                int smallPart = number - wholePart;

                string wholePartText = numberToTextMap[wholePart];
                string smallPartText = numberToTextMap[smallPart];

                Console.WriteLine($"{wholePartText} {smallPartText}");
            }
            else
            {
                Console.WriteLine("invalid number");
            }
        }
    }
}
