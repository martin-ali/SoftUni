using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04_morse_code_upgraded
{
    public class MorseCodeUpgraded
    {
        static void Main()
        {
            var letters = Console
                            .ReadLine()
                            .Split('|')
                            .Select(Decode)
                            .Select(c => (char)c);

            var message = string.Concat(letters);
            Console.WriteLine(message);
        }

        private static int Decode(string binaryDigit)
        {
            var digitValuesSum = binaryDigit.Select(digit => (digit == '0' ? 3 : 5)).Sum();
            var equalSequenceMatches = Regex.Matches(binaryDigit, @"(0{2,}|1{2,})");

            var equalSequencesSum = 0;
            foreach (Match sequence in equalSequenceMatches)
            {
                equalSequencesSum += sequence.Length;
            }

            int sum = equalSequencesSum + digitValuesSum;
            return sum;
        }
    }
}
/*

111000001110000|111111110111111111

01010101010101011|111001111100001111110|111001111100001111110|000011000011111010110|110010011010101011100|11110000000100110011010101|110001100101110101101

 */
