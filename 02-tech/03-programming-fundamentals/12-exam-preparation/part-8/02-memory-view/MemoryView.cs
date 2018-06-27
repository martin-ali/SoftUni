using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02_memory_view
{
    class MemoryView
    {
        static void Main()
        {
            #if DEBUG
            Console.SetIn(new StreamReader("tests/test2.txt"));
            #endif

            var input = new StringBuilder();

            // Get input
            var currentLine = Console.ReadLine();
            while (currentLine != "Visual Studio crash")
            {
                input.Append(" " + currentLine);
                currentLine = Console.ReadLine();
            }

            // Get strings
            var strings = input.ToString().Split(new[] { "32656 19759 32763" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i < strings.Length; i++)
            {
                var data = strings[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var characterCount = int.Parse(data[1]);
                var characters = string.Concat(data
                                        .Skip(3)
                                        .Take(characterCount)
                                        .Select(x => (char)int.Parse(x.ToString())));
                Console.WriteLine(characters);
            }
        }
    }
}
/*

32656 19759 32763 0 5 0 80 101 115 104 111 0 0 0 0 0 0 0 0 0 0 0
0 32656 19759 32763 0 7 0 83 111 102 116 117 110 105 0 0 0 0 0 0 0 0
Visual Studio crash

0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 32656 19759 32763 0
5 0 80 101 115 104 111 0 0 0 0 0 0 0 0 0 32656 19759 32763 0 4 0
75 105 114 111 0 0 0 0 0 0 0 0 0 0 32656 19759 32763 0 8 0 86 101
114 111 110 105 107 97 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
Visual Studio crash

 */
