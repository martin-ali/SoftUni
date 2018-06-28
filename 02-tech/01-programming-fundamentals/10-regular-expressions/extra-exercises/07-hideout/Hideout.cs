using System;
using System.Text.RegularExpressions;

namespace _07_hideout
{
    class Hideout
    {
        static void Main()
        {
            var map = Console.ReadLine();
            while (true)
            {
                var clue = Console.ReadLine().Split();

                var element = Regex.Escape(clue[0]);
                var size = int.Parse(clue[1]);

                var pattern = new Regex($@"{element}{{{size},}}");
                var match = pattern.Match(map);
                if (match.Success)
                {
                    Console.WriteLine($"Hideout found at index {match.Index} and it is with size {match.Length}!");
                    break;
                }
            }
        }
    }
}
/*

asd@@asdasd@@@@@@@asdasd asdsad
@ 5

asd@@asd***asdasdsad123%4521Asdsad************ASssda
&amp; 3
* 20
* 10
* 2

 */
