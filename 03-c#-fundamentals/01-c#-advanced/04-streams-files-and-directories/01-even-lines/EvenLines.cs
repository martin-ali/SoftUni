using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01_even_lines
{
    class EvenLines
    {
        static void Main()
        {
            using (var reader = new StreamReader("text.txt"))
            {
                while (reader.EndOfStream == false)
                {
                    var value = Regex
                                .Replace(reader.ReadLine(), "[-,.!?]", "@")
                                .Split()
                                .Reverse();

                    Console.WriteLine(string.Join(" ", value));

                    if (reader.EndOfStream == false) reader.ReadLine();
                }
            }
        }
    }
}
