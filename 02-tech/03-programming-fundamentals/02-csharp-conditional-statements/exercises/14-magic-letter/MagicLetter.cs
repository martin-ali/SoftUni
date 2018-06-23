using System;

namespace _14_magic_letter
{
    class MagicLetter
    {
        static void Main()
        {
            char startChar = char.Parse(Console.ReadLine());
            char endChar = char.Parse(Console.ReadLine());
            char magicLetter = char.Parse(Console.ReadLine());

            for (int first = startChar; first <= endChar; first++)
            {
                for (int second = startChar; second <= endChar; second++)
                {
                    for (int third = startChar; third <= endChar; third++)
                    {
                        var magicLetterContained =
                        (
                            first == magicLetter
                            || second == magicLetter
                            || third == magicLetter
                        );

                        if (magicLetterContained == false)
                        {
                            Console.Write($"{(char)first}{(char)second}{(char)third} ");
                        }
                    }
                }
            }
        }
    }
}
