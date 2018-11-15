using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01_data_transfer
{
    class DataTransfer
    {
        static void Main()
        {
            var senderPattern = @"[^;]*";
            var receiverPattern = @"[^;]*";
            var messagePattern = @"[A-Za-z ]*";
            var validLineMatcher = new Regex($@"s:({senderPattern});r:({receiverPattern});m--""({messagePattern})""");

            var dataTransferred = 0;
            var lineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < lineCount; i++)
            {
                var line = Console.ReadLine();
                var match = validLineMatcher.Match(line);

                if (match.Success == false)
                {
                    continue;
                }

                var sender = match.Groups[1];
                var receiver = match.Groups[2];
                var message = match.Groups[3];

                var senderFiltered = string.Join("", sender.Value.Where(x => Char.IsWhiteSpace(x) || Char.IsLetter(x)));
                var receiverFiltered = string.Join("", receiver.Value.Where(x => Char.IsWhiteSpace(x) || Char.IsLetter(x)));
                dataTransferred += sender.Value.Where(char.IsDigit).Sum(x => int.Parse(x.ToString()))
                                    + receiver.Value.Where(char.IsDigit).Sum(x => int.Parse(x.ToString()));

                Console.WriteLine($"{senderFiltered} says \"{message}\" to {receiverFiltered}");
            }

            Console.WriteLine($"Total data transferred: {dataTransferred}MB");
        }
    }
}
