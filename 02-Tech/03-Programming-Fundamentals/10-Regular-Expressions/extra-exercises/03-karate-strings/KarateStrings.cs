using System;
using System.Collections.Generic;

namespace _03_karate_strings
{
    class KarateStrings
    {
        static void Main()
        {
            var moves = Console.ReadLine();
            var result = new List<char>();
            int momentum = 0;

            for (int i = 0; i < moves.Length; i++)
            {
                if (int.TryParse(moves[i].ToString(), out int power))
                {
                    momentum += power;
                }

                if (moves[i] != '>' && momentum > 0)
                {
                    moves = moves.Remove(i, 1);
                    momentum--;
                    i--;
                }
            }

            Console.WriteLine(moves);
        }
    }
}
/*

abv>1>1>2>2asdasd

pesho>2sis>1a>2akarate>4hexmaster

 */
