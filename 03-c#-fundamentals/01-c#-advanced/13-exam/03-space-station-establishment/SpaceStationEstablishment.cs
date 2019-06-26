using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_space_station_establishment
{
    class SpaceStationEstablishment
    {
        private const char StephenMarker = 'S';

        private const char BlackHoleMarker = 'O';

        private const char Empty = '-';

        static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            var galaxy = new List<List<char>>();
            var blackHoles = new Stack<(int row, int col)>();

            var stephen = (row: 0, col: 0, energy: 0);

            for (int row = 0; row < size; row++)
            {
                var line = Console.ReadLine().ToCharArray().ToList();

                for (int character = 0; character < line.Count; character++)
                {
                    if (line[character] == BlackHoleMarker)
                    {
                        blackHoles.Push((row, character));
                    }
                }

                var stephenCol = line.IndexOf(StephenMarker);
                if (stephenCol >= 0)
                {
                    stephen.row = row;
                    stephen.col = stephenCol;
                }

                galaxy.Add(line);
            }

            galaxy[stephen.row][stephen.col] = Empty;

            while (stephen.energy < 50)
            {
                var direction = Console.ReadLine();
                var newCoordinates = GetNewCoordinates(stephen.row, stephen.col, direction);
                stephen.row = newCoordinates.row;
                stephen.col = newCoordinates.col;

                if (IsWithinGalaxyBounds(size, stephen.row, stephen.col) == false)
                {
                    Console.WriteLine("Bad news, the spaceship went to the void.");
                    break;
                }

                if (char.IsDigit(galaxy[stephen.row][stephen.col]))
                {
                    var energy = galaxy[stephen.row][stephen.col] - '0';
                    stephen.energy += energy;

                    galaxy[stephen.row][stephen.col] = Empty;
                }
                else if (galaxy[stephen.row][stephen.col] == BlackHoleMarker)
                {
                    foreach (var blackHoleCoordinates in blackHoles)
                    {
                        galaxy[blackHoleCoordinates.row][blackHoleCoordinates.col] = Empty;
                    }

                    var firstBlackHole = blackHoles.Pop();
                    var secondBlackHole = blackHoles.Pop();

                    if (stephen.row == firstBlackHole.row
                    && stephen.col == firstBlackHole.col)
                    {
                        stephen.row = secondBlackHole.row;
                        stephen.col = secondBlackHole.col;
                    }
                    else
                    {
                        stephen.row = firstBlackHole.row;
                        stephen.col = firstBlackHole.col;
                    }
                }
            }

            if (stephen.energy >= 50)
            {
                galaxy[stephen.row][stephen.col] = StephenMarker;
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            }

            Console.WriteLine($"Star power collected: {stephen.energy}");

            PrintGalaxy(galaxy);
        }

        private static void PrintGalaxy(List<List<char>> galaxy)
        {
            foreach (var row in galaxy)
            {
                Console.WriteLine(new string(row.ToArray()));
            }
        }

        private static (int row, int col) GetNewCoordinates(int row, int col, string direction)
        {
            switch (direction)
            {
                case "up": row--; break;
                case "down": row++; break;
                case "left": col--; break;
                case "right": col++; break;
            }

            return (row, col);
        }

        private static bool IsWithinGalaxyBounds(int size, int row, int col)
        {
            return 0 <= row && row < size
                && 0 <= col && col < size;
        }
    }
}
/*

5
SO---
-----
-----
-----
----O
right
right

6
S98---
99----
555555
------
--77--
-6-6-6
right
right
down
left
left
down
right
right

*/
