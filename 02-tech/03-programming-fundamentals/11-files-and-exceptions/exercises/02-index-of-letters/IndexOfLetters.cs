using System;
using System.IO;

namespace _02_index_of_letters
{
    class IndexOfLetters
    {
        static void Main()
        {
            var letters = File.ReadAllText("input.txt");
            for (int i = 0; i < letters.Length; i++)
            {
                string letterAndIndex = $"{letters[i]} -> {letters[i] - 97}";
                File.AppendAllText("output.txt", letterAndIndex + Environment.NewLine);
            }
        }
    }
}
