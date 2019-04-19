dusing System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03_crypto_blockchain
{
    class CryptoBlockchain
    {
        static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("tests/test3.txt"));
#endif

            var lineCount = int.Parse(Console.ReadLine());
            var lines = new string[lineCount];
            for (int current = 0; current < lineCount; current++)
            {
                lines[current] = Console.ReadLine();
            }

            var blockchain = string.Join("", lines);
            var blocks = Regex.Matches(blockchain, @"\[.+?\]|{.+?}");

            var threeDigitMatcher = new Regex(@"\d{3}");
            var mixedBracketMatcher = new Regex(@"{.*\]|\[.*}");

            foreach (Match block in blocks)
            {
                var digitTriples = threeDigitMatcher.Matches(block.Value);
                var mixedBrackets = mixedBracketMatcher.IsMatch(block.Value);

                if (digitTriples.Count == 0
                || block.Value.Count(c => char.IsDigit(c)) % 3 != 0
                || mixedBrackets)
                {
                    continue;
                }

                var characters = digitTriples.Select(m => (char)(int.Parse(m.Value) - block.Length));
                Console.Write(string.Join("", characters));
            }
        }
    }
}
