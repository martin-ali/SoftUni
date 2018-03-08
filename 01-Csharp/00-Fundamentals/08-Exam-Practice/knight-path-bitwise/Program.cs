using System;
using System.Collections.Generic;

namespace knight_path_bitwise
{
    // The bitwise solution took significantly less time and effort than the non-bitwise variant. Live and learn
    class Program
    {
        private static Dictionary<string, (int Row, int Col)> directions = new Dictionary<string, (int row, int col)>
        {
            ["left up"] = (-1, 2),
            ["left down"] = (1, 2),
            ["right up"] = (-1, -2),
            ["right down"] = (1, -2),

            ["up left"] = (-2, 1),
            ["up right"] = (-2, -1),
            ["down left"] = (2, 1),
            ["down right"] = (2, -1),

            // Avoid this?
            ["stop"] = (0, 0)
        };

        static void Main()
        {
            // Whole thing could be done with bitwise operations, but I avoided that on purpose. 
            // I prefer doing things my own way when I'm learning
            // var moves = new List<string>()
            // {
            //     "left down",
            //     "down right",
            //     "right up",
            //     "down right",
            //     "left down",
            //     "left down",
            //     "stop"
            // };

            var board = new int[8];
            var moves = FetchCommandsFromConsole();
            ExecuteMoves(board, moves);
            PrintBoard(board);
        }

        private static void PrintBoard(int[] board)
        {
            bool boardIsEmpty = true;
            foreach (var number in board)
            {
                if (number != 0)
                {
                    Console.WriteLine(number);
                    boardIsEmpty = false;
                }
            }

            if (boardIsEmpty)
            {
                Console.WriteLine("[Board is empty]");
            }
        }

        private static void ExecuteMoves(int[] board, IList<string> moves)
        {
            var knight = (Row: 0, Col: 0);
            foreach (var move in moves)
            {
                var newCoordinates = directions[move];
                var newRow = knight.Row + newCoordinates.Row;
                var newCol = knight.Col + newCoordinates.Col;
                if (CoordinatesAreValid(newRow, newCol, board))
                {
                    board[knight.Row] ^= (1 << knight.Col);
                    knight.Row = newRow;
                    knight.Col = newCol;
                }
            }
        }

        private static bool CoordinatesAreValid(int row, int col, int[] board)
        {
            var coordinatesAreValid = (0 <= row && row < board.Length) && (0 <= col && col < board.Length);
            return coordinatesAreValid;
        }

        private static List<string> FetchCommandsFromConsole()
        {
            var moves = new List<string>();
            while (true)
            {
                var move = Console.ReadLine().ToLower();
                moves.Add(move);

                if (move == "stop") break;
            }

            return moves;
        }
    }
}
