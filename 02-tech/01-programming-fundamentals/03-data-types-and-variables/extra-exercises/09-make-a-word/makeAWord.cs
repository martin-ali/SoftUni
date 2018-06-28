using System;
using System.Text;

namespace _09_make_a_word
{
    class makeAWord
    {
        static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            var wordBuilder = new StringBuilder();
            for (int i = 0; i < numberOfLines; i++)
            {
                var character = Console.ReadLine();
                wordBuilder.Append(character);
            }

            Console.WriteLine($"The word is: {wordBuilder}");
        }
    }
}
