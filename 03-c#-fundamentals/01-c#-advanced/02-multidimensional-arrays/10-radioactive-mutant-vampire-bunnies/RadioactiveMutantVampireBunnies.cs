using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_radioactive_mutant_vampire_bunnies
{
    class RadioactiveMutantVampireBunnies
    {
        private const char PLAYER_START = 'P';

        private const char EMPTY = '.';

        private const char BUNNY = 'B';

        private enum PlayerStatus { Alive, Dead, Escaped };

        static void Main()
        {
            var lairDimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = lairDimensions[0];
            var cols = lairDimensions[1];
            var lair = new char[rows, cols];
            var player = (row: 0, col: 0, status: PlayerStatus.Alive);

            // Create lair
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                var items = Console.ReadLine().ToCharArray();
                for (int col = 0; col < items.Length; col++)
                {
                    lair[row, col] = items[col];

                    if (items[col] == PLAYER_START)
                    {
                        lair[row, col] = EMPTY;
                        player.row = row;
                        player.col = col;
                    }
                }
            }

            var moves = new Queue<char>(Console.ReadLine());
            while (moves.Count > 0 && player.status == PlayerStatus.Alive)
            {
                var playerPreviousState = player;
                var move = moves.Dequeue();
                player = GetNewPlayerData(player, move);

                if (IsInLair(lair, player.row, player.col) == false)
                {
                    player.status = PlayerStatus.Escaped;
                    player.row = playerPreviousState.row;
                    player.col = playerPreviousState.col;
                }

                SpreadBunnies(lair);

                if (IsInLair(lair, player.row, player.col)
                    && lair[player.row, player.col] == BUNNY
                    && player.status != PlayerStatus.Escaped)
                {
                    player.status = PlayerStatus.Dead;
                }
            }

            PrintLair(lair);

            if (player.status == PlayerStatus.Escaped)
            {
                Console.WriteLine($"won: {player.row} {player.col}");
            }
            else
            {
                Console.WriteLine($"dead: {player.row} {player.col}");
            }

        }

        private static (int row, int col, PlayerStatus status) GetNewPlayerData((int row, int col, PlayerStatus status) player, char move)
        {
            if (move == 'U')
            {
                player.row -= 1;
            }
            else if (move == 'D')
            {
                player.row += 1;
            }
            else if (move == 'L')
            {
                player.col -= 1;
            }
            else if (move == 'R')
            {
                player.col += 1;
            }

            return player;
        }

        private static void SpreadBunnies(char[,] lair)
        {
            var lairInitialStatus = CloneLair(lair);
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lairInitialStatus[row, col] == BUNNY)
                    {
                        MultiplyBunny(lair, row, col);
                    }
                }
            }
        }

        private static char[,] CloneLair(char[,] lair)
        {
            var newLair = new char[lair.GetLength(0), lair.GetLength(1)];
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    newLair[row, col] = lair[row, col];
                }
            }

            return newLair;
        }

        private static void MultiplyBunny(char[,] lair, int startRow, int startCol)
        {
            for (int row = startRow - 1; row <= startRow + 1; row++)
            {
                if (IsInLair(lair, row, startCol))
                {
                    lair[row, startCol] = BUNNY;
                }
            }

            for (int col = startCol - 1; col <= startCol + 1; col++)
            {
                if (IsInLair(lair, startRow, col))
                {
                    lair[startRow, col] = BUNNY;
                }
            }
        }

        private static bool IsInLair<G>(G[,] matrix, int row, int col)
        {
            return 0 <= row && row < matrix.GetLength(0)
                && 0 <= col && col < matrix.GetLength(1);
        }

        private static void PrintLair(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}

/*
5 8
.......B
...B....
....B..B
........
..P.....
ULLL

4 5
.....
.....
.B...
...P.
LLLLLLLL
*/
