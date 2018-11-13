using System;
using System.Collections.Generic;
using System.IO;

namespace _02_line_numbers
{
    class LineNumbers
    {
        static void Main()
        {
            var reader = new StreamReader("text.txt");
            var writer = new StreamWriter("numbered-lines-text.txt");

            var lines = new List<string>();
            using (reader)
            {
                while (reader.EndOfStream == false)
                {
                    lines.Add(reader.ReadLine());
                }
            }

            using (writer)
            {
                for (int index = 0; index < lines.Count; index++)
                {
                    writer.WriteLine($"Line {index + 1}: {lines[index]}");
                }
            }
        }
    }
}
