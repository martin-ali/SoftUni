using System;

namespace _06_triples_of_latin_letters
{
    class TriplesOfLatinLetters
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var end = n + 'a';
            for (int first = 'a'; first < end; first++)
            {
                for (int second = 'a'; second < end; second++)
                {
                    for (int third = 'a'; third < end; third++)
                    {
                        Console.WriteLine($"{(char)first}{(char)second}{(char)third}");
                    }
                }
            }
        }
    }
}
