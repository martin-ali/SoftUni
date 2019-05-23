using System;
using System.Linq;

namespace _09_miner
{
    class Miner
    {
        private const char COAL = 'c';

        private const char MINER_START = 's';

        private const char COAL_COLLECTED = '*';

        private const char END_OF_ROUTE = 'e';

        static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            var moves = Console.ReadLine().Split();
            var field = new char[size, size];
            var miner = (row: 0, col: 0);
            var totalCoalPieces = 0;
            var coalPiecesCollected = 0;

            // Generate field
            for (int row = 0; row < size; row++)
            {
                var items = Console.ReadLine().Replace(" ", string.Empty).ToCharArray();
                for (int col = 0; col < items.Length; col++)
                {
                    field[row, col] = items[col];

                    if (items[col] == MINER_START)
                    {
                        miner.row = row;
                        miner.col = col;
                    }
                    else if (items[col] == COAL)
                    {
                        totalCoalPieces++;
                    }
                }
            }

            foreach (var move in moves)
            {
                if (move == "up" && IsInField(field, miner.row - 1, miner.col))
                {
                    miner.row -= 1;
                }
                else if (move == "down" && IsInField(field, miner.row + 1, miner.col))
                {
                    miner.row += 1;
                }
                else if (move == "left" && IsInField(field, miner.row, miner.col - 1))
                {
                    miner.col -= 1;
                }
                else if (move == "right" && IsInField(field, miner.row, miner.col + 1))
                {
                    miner.col += 1;
                }

                if (field[miner.row, miner.col] == COAL)
                {
                    field[miner.row, miner.col] = COAL_COLLECTED;
                    coalPiecesCollected++;
                }
                else if (field[miner.row, miner.col] == END_OF_ROUTE)
                {
                    Console.WriteLine($"Game over! ({miner.row}, {miner.col})");
                    return;
                }

                if (coalPiecesCollected == totalCoalPieces)
                {
                    Console.WriteLine($"You collected all coals! ({miner.row}, {miner.col})");
                    return;
                }
            }

            Console.WriteLine($"{totalCoalPieces - coalPiecesCollected} coals left. ({miner.row}, {miner.col})");
        }

        private static bool IsInField<G>(G[,] matrix, int row, int col)
        {
            return 0 <= row && row < matrix.GetLength(0)
                && 0 <= col && col < matrix.GetLength(1);
        }
    }
}

/*
5
up right right up right
* * * c *
* * * e *
* * c * *
s * * c *
* * c * *

4
up right right right down
* * * e
* * c *
* s * c
* * * *

6
left left down right up left left down down down
* * * * * *
e * * * c *
* * c s * *
* * * * * *
c * * * c *
* * c * * *
*/
