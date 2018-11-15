using System;
using System.IO;

namespace _02_sneaking
{
    class Sneaking
    {
        private const char Sam = 'S';
        private const char LeftFacingGuard = 'd';
        private const char RightFacingGuard = 'b';
        private const char Dead = 'X';
        private const char Nikoladze = 'N';
        private const char Empty = '.';

        static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("tests/test1.txt"));
#endif

            var sam = (row: 0, col: 0);
            var rowCount = int.Parse(Console.ReadLine());
            var room = new char[rowCount][];
            for (int row = 0; row < rowCount; row++)
            {
                room[row] = Console.ReadLine().ToCharArray();
                var samCol = new string(room[row]).IndexOf(Sam);
                if (samCol >= 0)
                {
                    sam.row = row;
                    sam.col = samCol;
                }
            }
            var commands = Console.ReadLine().ToCharArray();

            foreach (var command in commands)
            {
                MoveGuards(room);

                var scanInformation = ScanForSam(room, sam);
                if (scanInformation.samIsDead)
                {
                    Console.WriteLine($"Sam died at {scanInformation.row}, {scanInformation.col}");
                    break;
                }

                var newCoordinates = MoveSam(room, command, sam);
                sam.row = newCoordinates.row;
                sam.col = newCoordinates.col;

                if (newCoordinates.nikoladzeIsDead)
                {
                    Console.WriteLine("Nikoladze killed!");
                    break;
                }
            }

            Print(room);
        }

        private static (int row, int col, bool nikoladzeIsDead) MoveSam(char[][] room, char command, (int row, int col) sam)
        {
            room[sam.row][sam.col] = Empty;
            var newRow = sam.row;
            var newCol = sam.col;

            switch (command)
            {
                case 'U': newRow--; break;
                case 'D': newRow++; break;
                case 'L': newCol--; break;
                case 'R': newCol++; break;
            }

            room[newRow][newCol] = Sam;

            var indexOfNikoladze = new string(room[newRow]).IndexOf(Nikoladze);
            var nikoladzeIsDead = false;
            if (indexOfNikoladze >= 0)
            {
                room[newRow][indexOfNikoladze] = Dead;
                nikoladzeIsDead = true;
            }

            return (newRow, newCol, nikoladzeIsDead);
        }

        private static (int row, int col, bool samIsDead) ScanForSam(char[][] room, (int row, int col) sam)
        {
            var row = sam.row;

            for (int col = 0; col < room[row].Length; col++)
            {
                if ((room[row][col] == RightFacingGuard && col < sam.col)
                || (room[row][col] == LeftFacingGuard && sam.col < col))
                {
                    room[sam.row][sam.col] = Dead;
                    return (sam.row, sam.col, true);
                }
            }

            return (0, 0, false);
        }

        private static void Print(char[][] room)
        {
            foreach (var line in room)
            {
                Console.WriteLine(new string(line));
            }
        }

        private static bool MoveGuards(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                var guardCol = new string(room[row]).IndexOfAny(new[] { RightFacingGuard, LeftFacingGuard });

                if (guardCol >= 0)
                {
                    var guard = room[row][guardCol];

                    int newCol = guard == RightFacingGuard ? guardCol + 1 : guardCol - 1;
                    MoveGuard(room, row, guardCol, newCol);
                }
            }

            return true;
        }

        private static void MoveGuard(char[][] room, int row, int col, int newCol)
        {
            var guardType = room[row][col];
            if (IsInRoom(row, newCol, room.Length, room[row].Length))
            {
                room[row][col] = Empty;
                room[row][newCol] = guardType;
            }
            else // Rotate
            {
                room[row][col] = guardType == RightFacingGuard
                                ? LeftFacingGuard
                                : RightFacingGuard;
            }
        }

        private static bool IsInRoom(int row, int col, int roomHeight, int roomWidth)
        {
            return (0 <= row && row < roomHeight)
                && (0 <= col && col < roomWidth);
        }
    }
}
