using System;
using System.IO;
using System.Linq;

namespace _08_radioactive_mutant_vampire_bunnies
{
    class RadioactiveMutantVampireBunnies
    {
        private const char mutantRabbitSpawn = 'b';

        private const char mutantRabbit = 'B';

        private const char player = 'P';

        private const char Up = 'U';

        private const char Down = 'D';

        private const char Left = 'L';

        private const char Right = 'R';

        private static (int row, int col) playerData = (row: 0, col: 0);

        private static (int row, int col) lastPlayerData = (row: 0, col: 0);

        static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("tests/test2.txt"));
#endif

            var lair = CreateLair();

            var directions = Console.ReadLine();
            foreach (var direction in directions)
            {
                lastPlayerData = playerData;
                switch (direction)
                {
                    case Up: { playerData.row--; } break;
                    case Down: { playerData.row++; } break;
                    case Left: { playerData.col--; } break;
                    case Right: { playerData.col++; } break;
                }

                PopulateLairWithMutantRabbitSpawn(lair);

                MatureMutantRabbitSpawn(lair);

                if (PlayerWon(lair, playerData.row, playerData.col))
                {
                    PrintLair(lair);
                    Console.WriteLine($"won: {lastPlayerData.row} {lastPlayerData.col}");
                    return;
                }
                else if (EncounteredMutantRabbit(lair, playerData.row, playerData.col))
                {
                    PrintLair(lair);
                    Console.WriteLine($"dead: {playerData.row} {playerData.col}");
                    return;
                }
            }
        }

        private static bool EncounteredMutantRabbit(char[][] lair, int row, int col)
        {
            return lair[row][col] == mutantRabbit;
        }

        private static bool PlayerWon(char[][] lair, int row, int col)
        {
            return (row < 0 || row >= lair.Length) || (col < 0 || col >= lair[row].Length);
        }

        private static char[][] CreateLair()
        {
            var rowsAndCols = Console.ReadLine()
                                            .Split(' ')
                                            .Select(int.Parse)
                                            .ToArray();

            var rows = rowsAndCols[0];
            var cols = rowsAndCols[1];

            var lair = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine();
                lair[row] = line.Replace('P', '.').ToCharArray();

                var indexOfPLayer = line.IndexOf(player);
                if (indexOfPLayer >= 0)
                {
                    playerData.row = row;
                    playerData.col = indexOfPLayer;
                }
            }

            return lair;
        }

        private static void PrintLair(char[][] lair)
        {
            for (int row = 0; row < lair.Length; row++)
            {
                for (int col = 0; col < lair[row].Length; col++)
                {
                    Console.Write(lair[row][col]);
                }

                Console.WriteLine();
            }
        }

        private static void MatureMutantRabbitSpawn(char[][] lair)
        {
            for (int row = 0; row < lair.Length; row++)
            {
                for (int col = 0; col < lair[row].Length; col++)
                {
                    if (lair[row][col] == mutantRabbitSpawn)
                    {
                        lair[row][col] = mutantRabbit;
                    }
                }
            }
        }

        private static void PopulateLairWithMutantRabbitSpawn(char[][] lair)
        {
            for (int row = 0; row < lair.Length; row++)
            {
                for (int col = 0; col < lair[row].Length; col++)
                {
                    if (lair[row][col] == mutantRabbit)
                    {
                        // Replace with loops
                        if (row > 0 && lair[row - 1][col] != mutantRabbit)
                        {
                            lair[row - 1][col] = mutantRabbitSpawn;
                        }
                        if (row < lair.Length - 1 && lair[row + 1][col] != mutantRabbit)
                        {
                            lair[row + 1][col] = mutantRabbitSpawn;
                        }
                        if (col > 0 && lair[row][col - 1] != mutantRabbit)
                        {
                            lair[row][col - 1] = mutantRabbitSpawn;
                        }
                        if (col < lair[row].Length - 1 && lair[row][col + 1] != mutantRabbit)
                        {
                            lair[row][col + 1] = mutantRabbitSpawn;
                        }
                    }
                }
            }
        }
    }
}