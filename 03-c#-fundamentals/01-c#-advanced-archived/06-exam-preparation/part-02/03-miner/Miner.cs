using System;
using System.Linq;

namespace _03_miner
{
    class Miner
    {
        private const char Coal = 'c';
        private const char EndOfRoute = 'e';
        private const char CoalCollected = '*';

        static void Main()
        {
            var fieldSize = int.Parse(Console.ReadLine());
            var commands = Console.ReadLine().Split();
            var field = new char[fieldSize][];

            var coalPiecesCount = 0;
            var miner = (row: 0, col: 0);
            for (int i = 0; i < fieldSize; i++)
            {
                var row = Console.ReadLine().Replace(" ", "");
                field[i] = row.ToCharArray();

                coalPiecesCount += row.Count(x => x == Coal);

                var minerCol = row.IndexOf('s');
                if (minerCol >= 0)
                {
                    miner.row = i;
                    miner.col = minerCol;
                }
            }

            var coalPiecesCollected = 0;
            foreach (var command in commands)
            {
                var newCoordinates = GetNewCoordinates(command, miner.row, miner.col);
                if (IsInside(newCoordinates.row, newCoordinates.col, fieldSize))
                {
                    miner = newCoordinates;

                    if (field[miner.row][miner.col] == Coal)
                    {
                        coalPiecesCollected++;
                        field[miner.row][miner.col] = CoalCollected;

                        if (coalPiecesCollected == coalPiecesCount)
                        {
                            Console.WriteLine($"You collected all coals! ({miner.row}, {miner.col})");
                            return;
                        }
                    }
                    else if (field[miner.row][miner.col] == EndOfRoute)
                    {
                        Console.WriteLine($"Game over! ({miner.row}, {miner.col})");
                        return;
                    }
                }
            }

            int coalPiecesLeft = coalPiecesCount - coalPiecesCollected;
            Console.WriteLine($"{coalPiecesLeft} coals left. ({miner.row}, {miner.col})");
        }

        private static (int row, int col) GetNewCoordinates(string command, int row, int col)
        {
            if (command == "up")
            {
                row--;
            }
            else if (command == "down")
            {
                row++;
            }
            else if (command == "left")
            {
                col--;
            }
            else if (command == "right")
            {
                col++;
            }

            return (row, col);
        }

        private static bool IsInside(int row, int col, int size)
        {
            return (0 <= row && row < size)
                && (0 <= col && col < size);
        }
    }
}