using System;
using System.IO;

namespace _01_odd_lines
{
    class OddLines
    {
        static void Main()
        {
            var reader = new StreamReader("text.txt");

            using (reader)
            {
                for (int i = 0; reader.EndOfStream == false; i++)
                {
                    var line = reader.ReadLine();
                    if (i % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }
}
