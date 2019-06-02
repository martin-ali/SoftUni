using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _02_line_numbers
{
    class LineNumbers
    {
        static void Main()
        {
            var lines = File.ReadAllLines("text.txt");
            var linesToWrite = new List<string>();

            var index = 1;
            foreach (var line in lines)
            {
                var lettersCount = line.Count(c => Char.IsLetter(c));
                var punctuationMarksCount = line.Count(c => Char.IsPunctuation(c));
                var processedLine = $"Line {index}: {line} ({lettersCount})({punctuationMarksCount})";

                linesToWrite.Add(processedLine);

                index++;
            }

            File.AppendAllLines("output.txt", linesToWrite);
        }
    }
}
