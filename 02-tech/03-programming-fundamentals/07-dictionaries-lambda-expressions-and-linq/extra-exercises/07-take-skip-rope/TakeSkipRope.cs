using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07_take_skip_rope
{
    class TakeSkipRope
    {
        static void Main()
        {
            #if DEBUG
            var testNumber = Console.ReadLine();
            Console.SetIn(new StreamReader($"tests/test{testNumber}.txt"));
            #endif

            var encryptedMessage = Console.ReadLine();
            var numbers = encryptedMessage.Where(x => Char.IsDigit(x)).Select(x => (int)x - 48);
            var notNumbers = encryptedMessage.Where(x => !Char.IsDigit(x));

            var takeList = numbers.Where((x, i) => i % 2 == 0).ToList();
            var skipList = numbers.Where((x, i) => i % 2 == 1).ToList();

            var skipCount = 0;
            var decryptedMessage = new List<char>();
            for (int i = 0; i < takeList.Count; i++)
            {
                decryptedMessage.AddRange(notNumbers.Skip(skipCount).Take(takeList[i]));
                skipCount += (skipList[i] + takeList[i]);
            }

            Console.WriteLine(string.Join("", decryptedMessage));
        }
    }
}
