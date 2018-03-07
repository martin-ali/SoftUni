using System;
using System.Collections.Generic;

namespace knight_path
{
    class Program
    {
        // Tuples da shit, mun!
        // Should be careful and avoid turning my code into JavaScript with Anonymous Types and Tuples
        // Dynamic remains useless
        private static Dictionary<string, (int row, int col)> directions = new Dictionary<string, (int row, int col)>
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
            // I just like doing things my own way when I'm learning
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

            var board = new bool[8, 8];
            var moves = FetchCommandsFromConsole();
            ExecuteCommands(moves, board);
            PrintGameBoard(board);
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

        private static void ExecuteCommands(List<string> moves, bool[,] board)
        {
            var currentKnightRow = 0;
            var currentKnightCol = 0;

            foreach (string move in moves)
            {
                var newCoordinates = ExecuteCommand(board, move, currentKnightRow, currentKnightCol);
                currentKnightRow = newCoordinates.x;
                currentKnightCol = newCoordinates.y;
            }
        }

        // The board is technically inverted on its horizontal axis, but I can't find a reason to fix it
        private static void PrintGameBoard(bool[,] board)
        {
            var boardIsEmpty = true;
            for (int row = 0; row < 8; row++)
            {
                double num = 0;
                for (int col = 0; col < 8; col++)
                {
                    // Console.Write((board[row, col] ? "x" : "_") + " ");
                    if (board[row, col])
                    {
                        num += Math.Pow(2, col);
                    }
                }

                if (num != 0)
                {
                    Console.WriteLine(num);
                    boardIsEmpty = false;
                }
            }

            if (boardIsEmpty)
            {
                Console.WriteLine("[Board is empty]");
            }
        }

        static (int x, int y) ExecuteCommand(bool[,] board, string command, int currentRow, int currentCol)
        {
            var nextMove = directions[command];
            var newRow = currentRow + nextMove.row;
            var newCol = currentCol + nextMove.col;

            var newCoordinates = (currentRow, currentCol);
            bool movementIsValid = (0 <= newRow && newRow < board.GetLength(0)) && (0 <= newCol && newCol < board.GetLength(0));
            if (movementIsValid)
            {
                board[currentRow, currentCol] = !board[currentRow, currentCol];
                newCoordinates = (newRow, newCol);
            }

            return newCoordinates;
        }
    }
}