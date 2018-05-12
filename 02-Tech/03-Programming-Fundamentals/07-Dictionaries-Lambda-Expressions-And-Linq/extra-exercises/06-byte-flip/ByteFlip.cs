using System;
using System.IO;
using System.Linq;

namespace _06_byte_flip
{
    class ByteFlip
    {
        static void Main()
        {

            #if DEBUG
            var testNumber = Console.ReadLine();
            Console.SetIn(new StreamReader($"tests/test{testNumber}.txt"));
            #endif

            var message = Console
                        .ReadLine()
                        .Split(' ')
                        .Where(x => x.Length == 2)
                        .Select(x => $"{x[1]}{x[0]}")
                        .Reverse()
                        .Select(x => Convert.ToInt32(x, 16))
                        .Select(x => (char)x);

            Console.WriteLine(string.Join("", message));
        }
    }
}
